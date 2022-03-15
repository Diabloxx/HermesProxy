﻿using HermesProxy.Auth;
using HermesProxy.World;
using HermesProxy.World.Client;
using HermesProxy.World.Enums;
using HermesProxy.World.Objects;
using HermesProxy.World.Server;
using System.Collections.Generic;

namespace HermesProxy
{
    public class PlayerCache
    {
        public string Name;
        public Race RaceId;
        public Class ClassId;
        public Gender SexId;
        public byte Level;
    }
    public class GameSessionData
    {
        public bool IsInTaxiFlight;
        public bool IsWaitingForTaxiStart;
        public bool IsWaitingForNewWorld;
        public bool IsFirstEnterWorld;
        public bool IsInWorld;
        public uint? CurrentMapId;
        public uint CurrentTaxiNode;
        public uint PendingTransferMapId;
        public uint LastEnteredAreaTrigger;
        public WowGuid128 CurrentPlayerGuid;
        public long CurrentPlayerCreateTime;
        public uint CurrentGuildCreateTime;
        public uint CurrentGuildNumAccounts;
        public uint LastWhoRequestId;
        public uint LastClientCastId;
        public WowGuid128 LastClientCastGuid;
        public WowGuid128 LastLootTargetGuid;
        public List<int> ActionButtons = new();
        public Dictionary<WowGuid128, PlayerCache> CachedPlayers = new();
        public Dictionary<WowGuid128, uint> PlayerGuildIds = new();
        public Dictionary<WowGuid128, Dictionary<int, UpdateField>> ObjectCacheLegacy = new();
        public Dictionary<WowGuid128, UpdateFieldsArray> ObjectCacheModern = new();
        public Dictionary<WowGuid128, ObjectType> OriginalObjectTypes = new();
        public Dictionary<WowGuid128, uint[]> ItemGems = new();
        public Dictionary<uint, Class> CreatureClasses = new();
        public List<WowGuid128> OwnCharacters = new();
        public Dictionary<string, int> ChannelIds = new();
        public Dictionary<uint, uint> ItemBuyCount = new();
        public Dictionary<uint, uint> RealSpellToLearnSpell = new();

        public void StorePlayerGuildId(WowGuid128 guid, uint guildId)
        {
            if (PlayerGuildIds.ContainsKey(guid))
                PlayerGuildIds[guid] = guildId;
            else
                PlayerGuildIds.Add(guid, guildId);
        }
        public uint GetPlayerGuildId(WowGuid128 guid)
        {
            if (PlayerGuildIds.ContainsKey(guid))
                return PlayerGuildIds[guid];
            return 0;
        }
        public uint[] GetGemsForItem(WowGuid128 guid)
        {
            if (ItemGems.ContainsKey(guid))
                return ItemGems[guid];
            return null;
        }
        public void SaveGemsForItem(WowGuid128 guid, uint?[] gems)
        {
            uint[] existing;
            if (ItemGems.ContainsKey(guid))
                existing = ItemGems[guid];
            else
            {
                existing = new uint[ItemConst.MaxGemSockets];
                ItemGems.Add(guid, existing);
            }

            for (int i = 0; i < ItemConst.MaxGemSockets; i++)
            {
                if (gems[i] != null)
                    existing[i] = (uint)gems[i];
            }
        }
        public WowGuid128 GetPetGuidByNumber(uint petNumber)
        {
            foreach (var itr in ObjectCacheModern)
            {
                if (itr.Key.GetHighType() == HighGuidType.Pet &&
                    itr.Key.GetEntry() == petNumber)
                    return itr.Key;
            }
            return null;
        }
        public void StoreOriginalObjectType(WowGuid128 guid, ObjectType type)
        {
            if (OriginalObjectTypes.ContainsKey(guid))
                OriginalObjectTypes[guid] = type;
            else
                OriginalObjectTypes.Add(guid, type);
        }
        public ObjectType GetOriginalObjectType(WowGuid128 guid)
        {
            if (OriginalObjectTypes.ContainsKey(guid))
                return OriginalObjectTypes[guid];

            return guid.GetObjectType();
        }
        public void StoreRealSpell(uint realSpellId, uint learnSpellId)
        {
            if (RealSpellToLearnSpell.ContainsKey(realSpellId))
                RealSpellToLearnSpell[realSpellId] = learnSpellId;
            else
                RealSpellToLearnSpell.Add(realSpellId, learnSpellId);
        }
        public uint GetLearnSpellFromRealSpell(uint spellId)
        {
            if (RealSpellToLearnSpell.ContainsKey(spellId))
                return RealSpellToLearnSpell[spellId];

            return spellId;
        }
        public void StoreCreatureClass(uint entry, Class classId)
        {
            if (CreatureClasses.ContainsKey(entry))
                CreatureClasses[entry] = classId;
            else
                CreatureClasses.Add(entry, classId);
        }
        public void SetItemBuyCount(uint itemId, uint buyCount)
        {
            if (ItemBuyCount.ContainsKey(itemId))
                ItemBuyCount[itemId] = buyCount;
            else
                ItemBuyCount.Add(itemId, buyCount);
        }
        public uint GetItemBuyCount(uint itemId)
        {
            if (ItemBuyCount.ContainsKey(itemId))
                return ItemBuyCount[itemId];

            return 1;
        }
        public void SetChannelId(string name, int id)
        {
            if (ChannelIds.ContainsKey(name))
                ChannelIds[name] = id;
            else
                ChannelIds.Add(name, id);
        }

        public string GetPlayerName(WowGuid128 guid)
        {
            if (CachedPlayers.ContainsKey(guid))
            {
                if (CachedPlayers[guid].Name != null)
                    return CachedPlayers[guid].Name;
            }
            return "";
        }

        public WowGuid128 GetPlayerGuidByName(string name)
        {
            name = name.Trim().Replace("\0", "");
            foreach (var player in CachedPlayers)
            {
                if (player.Value.Name == name)
                    return player.Key;
            }
            return null;
        }

        public void UpdatePlayerCache(WowGuid128 guid, PlayerCache data)
        {
            if (data.Name != null)
                data.Name = data.Name.Trim().Replace("\0", "");
            if (CachedPlayers.ContainsKey(guid))
            {
                if (!string.IsNullOrEmpty(data.Name))
                    CachedPlayers[guid].Name = data.Name;
                if (data.RaceId != Race.None)
                    CachedPlayers[guid].RaceId = data.RaceId;
                if (data.ClassId != Class.None)
                    CachedPlayers[guid].ClassId = data.ClassId;
                if (data.SexId != Gender.None)
                    CachedPlayers[guid].SexId = data.SexId;
                if (data.Level != 0)
                    CachedPlayers[guid].Level = data.Level;
            }
            else
                CachedPlayers.Add(guid, data);
        }

        public Class GetUnitClass(WowGuid128 guid)
        {
            if (CachedPlayers.ContainsKey(guid))
                return CachedPlayers[guid].ClassId;

            if (CreatureClasses.ContainsKey(guid.GetEntry()))
                return CreatureClasses[guid.GetEntry()];

            return Class.Warrior;
        }

        public Dictionary<int, UpdateField> GetCachedObjectFieldsLegacy(WowGuid128 guid)
        {
            Dictionary<int, UpdateField> dict;
            if (ObjectCacheLegacy.TryGetValue(guid, out dict))
                return dict;
            return null;
        }

        public UpdateFieldsArray GetCachedObjectFieldsModern(WowGuid128 guid)
        {
            UpdateFieldsArray array;
            if (ObjectCacheModern.TryGetValue(guid, out array))
                return array;
            return null;
        }
    }
    public class GlobalSessionData
    {
        public BNetServer.Networking.AccountInfo AccountInfo;
        public BNetServer.Networking.GameAccountInfo GameAccountInfo;
        public string Username;
        public string Password;
        public string LoginTicket;
        public byte[] SessionKey;
        public string Locale;
        public string OS;
        public uint Build;
        public Framework.Realm.RealmId RealmId;
        public GameSessionData GameState = new();
        public WorldSocket RealmSocket;
        public WorldSocket InstanceSocket;
        public AuthClient AuthClient;
        public WorldClient WorldClient;
        public SniffFile ModernSniff;
        public Dictionary<string, WowGuid128> GuildsByName = new();
        public Dictionary<uint, List<string>> GuildRanks = new();

        public void StoreGuildRankNames(uint guildId, List<string> ranks)
        {
            if (GuildRanks.ContainsKey(guildId))
                GuildRanks[guildId] = ranks;
            else
                GuildRanks.Add(guildId, ranks);
        }
        public uint GetGuildRankIdByName(uint guildId, string name)
        {
            if (GuildRanks.ContainsKey(guildId))
            {
                for (int i = 0; i < GuildRanks[guildId].Count; i++)
                {
                    if (GuildRanks[guildId][i] == name)
                        return (uint)i;
                }
            }
            return 0;
        }
        public string GetGuildRankNameById(uint guildId, byte rankId)
        {
            if (GuildRanks.ContainsKey(guildId))
                return GuildRanks[guildId][rankId];

            return $"Rank {rankId}";
        }
        public void StoreGuildGuidAndName(WowGuid128 guid, string name)
        {
            if (GuildsByName.ContainsKey(name))
                GuildsByName[name] = guid;
            else
                GuildsByName.Add(name, guid);
        }
        public WowGuid128 GetGuildGuid(string name)
        {
            if (GuildsByName.ContainsKey(name))
                return GuildsByName[name];

            WowGuid128 guid = WowGuid128.Create(HighGuidType703.Guild, (ulong)(GuildsByName.Count + 1));
            GuildsByName.Add(name, guid);
            return guid;
        }

        public WowGuid128 GetGameAccountGuidForPlayer(WowGuid128 playerGuid)
        {
            if (GameState.OwnCharacters.Contains(playerGuid))
                return WowGuid128.Create(HighGuidType703.WowAccount, GameAccountInfo.Id);
            else
                return WowGuid128.Create(HighGuidType703.WowAccount, playerGuid.GetLow());
        }

        public WowGuid128 GetBnetAccountGuidForPlayer(WowGuid128 playerGuid)
        {
            if (GameState.OwnCharacters.Contains(playerGuid))
                return WowGuid128.Create(HighGuidType703.BNetAccount, AccountInfo.Id);
            else
                return WowGuid128.Create(HighGuidType703.BNetAccount, playerGuid.GetLow());
        }

        public void OnDisconnect()
        {
            if (AuthClient != null)
            {
                AuthClient.Disconnect();
                AuthClient = null;
            }
            if (WorldClient != null)
            {
                WorldClient.Disconnect();
                WorldClient = null;
            }
            if (RealmSocket != null)
            {
                RealmSocket.CloseSocket();
                RealmSocket = null;
            }
            if (InstanceSocket != null)
            {
                InstanceSocket.CloseSocket();
                InstanceSocket = null;
            }

            GameState = new();
        }
    }
}