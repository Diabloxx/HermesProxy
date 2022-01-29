﻿/*
 * Copyright (C) 2012-2020 CypherCore <http://github.com/CypherCore>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Framework.Constants;
using Framework.Web;
using Framework.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Timers;
using System.Collections.Concurrent;
using Framework.Realm;
using HermesProxy.Auth;

public class RealmManager : Singleton<RealmManager>
{
    RealmManager() { }

    public void Initialize()
    {
        LoadBuildInfo();

        UpdateRealms(null);
    }

    void LoadBuildInfo()
    {
        RealmBuildInfo build = new RealmBuildInfo();
        build.MajorVersion = Framework.Settings.GetClientExpansionVersion();
        build.MinorVersion = Framework.Settings.GetClientMajorPatchVersion();
        build.BugfixVersion = Framework.Settings.GetClientMinorPatchVersion();
        string hotfixVersion = "";
        if (!hotfixVersion.IsEmpty() && hotfixVersion.Length < build.HotfixVersion.Length)
            build.HotfixVersion = hotfixVersion.ToCharArray();

        build.Build = (uint)Framework.Settings.ClientBuild;
        string win64AuthSeedHexStr = "";
        if (!win64AuthSeedHexStr.IsEmpty() && win64AuthSeedHexStr.Length == build.Win64AuthSeed.Length * 2)
            build.Win64AuthSeed = win64AuthSeedHexStr.ToByteArray();

        string mac64AuthSeedHexStr = "";
        if (!mac64AuthSeedHexStr.IsEmpty() && mac64AuthSeedHexStr.Length == build.Mac64AuthSeed.Length * 2)
            build.Mac64AuthSeed = mac64AuthSeedHexStr.ToByteArray();

        _builds.Add(build);
    }

    public void Close()
    {
        
    }

    void UpdateRealm(Realm realm)
    {
        var oldRealm = _realms.LookupByKey(realm.Id);
        if (oldRealm != null && oldRealm == realm)
                return;

        _realms[realm.Id] = realm;
    }

    public void UpdateRealms(List<RealmInfo> authRealmList)
    {
        Dictionary<RealmId, string> existingRealms = new Dictionary<RealmId, string>();
        foreach (var p in _realms)
            existingRealms[p.Key] = p.Value.Name;

        _realms.Clear();

        // Circle through results and add them to the realm map
        if (authRealmList != null)
        {
            foreach (var authRealmEntry in authRealmList)
            {
                var realm = new Realm();
                uint realmId = authRealmEntry.ID;
                realm.Name = authRealmEntry.Name;
                realm.ExternalAddress = IPAddress.Parse("127.0.0.1");
                realm.LocalAddress = IPAddress.Parse("127.0.0.1");
                realm.LocalSubnetMask = IPAddress.Parse("255.255.255.0");
                realm.Port = 8085;
                RealmType realmType = (RealmType)authRealmEntry.Type;
                if (realmType == RealmType.FFAPVP)
                    realmType = RealmType.PVP;
                if (realmType >= RealmType.MaxType)
                    realmType = RealmType.Normal;

                realm.Type = (byte)realmType;
                realm.Flags = authRealmEntry.Flags;
                realm.Timezone = authRealmEntry.Timezone;
                AccountTypes allowedSecurityLevel = AccountTypes.Player;
                realm.AllowedSecurityLevel = (allowedSecurityLevel <= AccountTypes.Administrator ? allowedSecurityLevel : AccountTypes.Administrator);
                realm.PopulationLevel = authRealmEntry.Population;
                realm.Build = (uint)Framework.Settings.ClientBuild;
                byte region = 1;
                byte battlegroup = 1;

                realm.Id = new RealmId(region, battlegroup, realmId);

                UpdateRealm(realm);

                var subRegion = new RealmId(region, battlegroup, 0).GetAddressString();
                if (!_subRegions.Contains(subRegion))
                    _subRegions.Add(subRegion);

                if (!existingRealms.ContainsKey(realm.Id))
                    Log.outInfo(LogFilter.Realmlist, "Added realm \"{0}\" at {1}:{2}", realm.Name, realm.ExternalAddress.ToString(), realm.Port);
                else
                    Log.outDebug(LogFilter.Realmlist, "Updating realm \"{0}\" at {1}:{2}", realm.Name, realm.ExternalAddress.ToString(), realm.Port);

                existingRealms.Remove(realm.Id);
            }
        }

        foreach (var pair in existingRealms)
            Log.outInfo(LogFilter.Realmlist, "Removed realm \"{0}\".", pair.Value);
    }

    public Realm GetRealm(RealmId id)
    {
        return _realms.LookupByKey(id);
    }

    public RealmBuildInfo GetBuildInfo(uint build)
    {
        foreach (var clientBuild in _builds)
            if (clientBuild.Build == build)
                return clientBuild;

        return null;
    }

    public uint GetMinorMajorBugfixVersionForBuild(uint build)
    {
        RealmBuildInfo buildInfo = _builds.FirstOrDefault(p => p.Build < build);
        return buildInfo != null ? (buildInfo.MajorVersion * 10000 + buildInfo.MinorVersion * 100 + buildInfo.BugfixVersion) : 0;
    }

    public void WriteSubRegions(Bgs.Protocol.GameUtilities.V1.GetAllValuesForAttributeResponse response)
    {
        foreach (string subRegion in GetSubRegions())
        {
            var variant = new Bgs.Protocol.Variant();
            variant.StringValue = subRegion;
            response.AttributeValue.Add(variant);
        }
    }

    public byte[] GetRealmEntryJSON(RealmId id, uint build)
    {
        byte[] compressed = new byte[0];
        Realm realm = GetRealm(id);
        if (realm != null)
        {
            if (!realm.Flags.HasAnyFlag(RealmFlags.Offline) && realm.Build == build)
            {
                var realmEntry = new RealmEntry();
                realmEntry.WowRealmAddress = (int)realm.Id.GetAddress();
                realmEntry.CfgTimezonesID = 1;
                realmEntry.PopulationState = Math.Max((int)realm.PopulationLevel, 1);
                realmEntry.CfgCategoriesID = realm.Timezone;

                ClientVersion version = new ClientVersion();
                RealmBuildInfo buildInfo = GetBuildInfo(realm.Build);
                if (buildInfo != null)
                {
                    version.Major = (int)buildInfo.MajorVersion;
                    version.Minor = (int)buildInfo.MinorVersion;
                    version.Revision = (int)buildInfo.BugfixVersion;
                    version.Build = (int)buildInfo.Build;
                }
                else
                {
                    version.Major = 6;
                    version.Minor = 2;
                    version.Revision = 4;
                    version.Build = (int)realm.Build;
                }
                realmEntry.Version = version;

                realmEntry.CfgRealmsID = (int)realm.Id.Index;
                realmEntry.Flags = (int)realm.Flags;
                realmEntry.Name = realm.Name;
                realmEntry.CfgConfigsID = (int)realm.GetConfigId();
                realmEntry.CfgLanguagesID = 1;

                compressed = Json.Deflate("JamJSONRealmEntry", realmEntry);
            }
        }

        return compressed;
    }

    public byte[] GetRealmList(uint build, string subRegion)
    {
        var realmList = new RealmListUpdates();
        foreach (var realm in _realms)
        {
            if (realm.Value.Id.GetSubRegionAddress() != subRegion)
                continue;

            RealmFlags flag = realm.Value.Flags;
            if (realm.Value.Build != build)
                flag |= RealmFlags.VersionMismatch;

            RealmListUpdate realmListUpdate = new RealmListUpdate();
            realmListUpdate.Update.WowRealmAddress = (int)realm.Value.Id.GetAddress();
            realmListUpdate.Update.CfgTimezonesID = 1;
            realmListUpdate.Update.PopulationState = (realm.Value.Flags.HasAnyFlag(RealmFlags.Offline) ? 0 : Math.Max((int)realm.Value.PopulationLevel, 1));
            realmListUpdate.Update.CfgCategoriesID = realm.Value.Timezone;

            RealmBuildInfo buildInfo = GetBuildInfo(realm.Value.Build);
            if (buildInfo != null)
            {
                realmListUpdate.Update.Version.Major = (int)buildInfo.MajorVersion;
                realmListUpdate.Update.Version.Minor = (int)buildInfo.MinorVersion;
                realmListUpdate.Update.Version.Revision = (int)buildInfo.BugfixVersion;
                realmListUpdate.Update.Version.Build = (int)buildInfo.Build;
            }
            else
            {
                realmListUpdate.Update.Version.Major = 7;
                realmListUpdate.Update.Version.Minor = 1;
                realmListUpdate.Update.Version.Revision = 0;
                realmListUpdate.Update.Version.Build = (int)realm.Value.Build;
            }

            realmListUpdate.Update.CfgRealmsID = (int)realm.Value.Id.Index;
            realmListUpdate.Update.Flags = (int)flag;
            realmListUpdate.Update.Name = realm.Value.Name;
            realmListUpdate.Update.CfgConfigsID = (int)realm.Value.GetConfigId();
            realmListUpdate.Update.CfgLanguagesID = 1;

            realmListUpdate.Deleting = false;

            realmList.Updates.Add(realmListUpdate);
        }

        return Json.Deflate("JSONRealmListUpdates", realmList);
    }

    public BattlenetRpcErrorCode JoinRealm(uint realmAddress, uint build, IPAddress clientAddress, byte[] clientSecret, Locale locale, string os, string accountName, Bgs.Protocol.GameUtilities.V1.ClientResponse response)
    {
        Realm realm = GetRealm(new RealmId(realmAddress));
        if (realm != null)
        {
            if (realm.Flags.HasAnyFlag(RealmFlags.Offline) || realm.Build != build)
                return BattlenetRpcErrorCode.UserServerNotPermittedOnRealm;

            RealmListServerIPAddresses serverAddresses = new RealmListServerIPAddresses();
            AddressFamily addressFamily = new AddressFamily();
            addressFamily.Id = 1;

            var address = new Address();
            address.Ip = realm.GetAddressForClient(clientAddress).Address.ToString();
            address.Port = realm.Port;
            addressFamily.Addresses.Add(address);
            serverAddresses.Families.Add(addressFamily);

            byte[] compressed = Json.Deflate("JSONRealmListServerIPAddresses", serverAddresses);

            byte[] serverSecret = new byte[0].GenerateRandomKey(32);
            byte[] keyData = clientSecret.ToArray().Combine(serverSecret);

            /*
            PreparedStatement stmt = DB.Login.GetPreparedStatement(LoginStatements.UPD_BNET_GAME_ACCOUNT_LOGIN_INFO);
            stmt.AddValue(0, keyData);
            stmt.AddValue(1, clientAddress.ToString());
            stmt.AddValue(2, (byte)locale);
            stmt.AddValue(3, os);
            stmt.AddValue(4, accountName);
            DB.Login.DirectExecute(stmt);
            */

            Bgs.Protocol.Attribute attribute = new Bgs.Protocol.Attribute();
            attribute.Name = "Param_RealmJoinTicket";
            attribute.Value = new Bgs.Protocol.Variant();
            attribute.Value.BlobValue = Google.Protobuf.ByteString.CopyFrom(accountName, System.Text.Encoding.UTF8);
            response.Attribute.Add(attribute);

            attribute = new Bgs.Protocol.Attribute();
            attribute.Name = "Param_ServerAddresses";
            attribute.Value = new Bgs.Protocol.Variant();
            attribute.Value.BlobValue = Google.Protobuf.ByteString.CopyFrom(compressed);
            response.Attribute.Add(attribute);

            attribute = new Bgs.Protocol.Attribute();
            attribute.Name = "Param_JoinSecret";
            attribute.Value = new Bgs.Protocol.Variant();
            attribute.Value.BlobValue = Google.Protobuf.ByteString.CopyFrom(serverSecret);
            response.Attribute.Add(attribute);
            return BattlenetRpcErrorCode.Ok;
        }

        return BattlenetRpcErrorCode.UtilServerUnknownRealm;
    }

    public ICollection<Realm> GetRealms() { return _realms.Values; }
    List<string> GetSubRegions() { return _subRegions; }

    List<RealmBuildInfo> _builds = new List<RealmBuildInfo>();
    ConcurrentDictionary<RealmId, Realm> _realms = new ConcurrentDictionary<RealmId, Realm>();
    List<string> _subRegions = new List<string>();
}

public class RealmBuildInfo
{
    public uint Build;
    public uint MajorVersion;
    public uint MinorVersion;
    public uint BugfixVersion;
    public char[] HotfixVersion = new char[4];
    public byte[] Win64AuthSeed = new byte[16];
    public byte[] Mac64AuthSeed = new byte[16];
}
