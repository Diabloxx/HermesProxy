﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesProxy.World.Enums.V1_12_1_5875
{
    // ReSharper disable InconsistentNaming
    // 1.12.1
    public enum ObjectField
    {
        OBJECT_FIELD_GUID = 0x0,                                                    // 0x000 - Size: 2 - Type: GUID - Flags: PUBLIC
        OBJECT_FIELD_TYPE = 0x2,                                                    // 0x002 - Size: 1 - Type: INT - Flags: PUBLIC
        OBJECT_FIELD_ENTRY = 0x3,                                                   // 0x003 - Size: 1 - Type: INT - Flags: PUBLIC
        OBJECT_FIELD_SCALE_X = 0x4,                                                 // 0x004 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        OBJECT_FIELD_PADDING = 0x5,                                                 // 0x005 - Size: 1 - Type: INT - Flags: NONE
        OBJECT_END = 0x6
    }

    public enum ItemField
    {
        ITEM_FIELD_OWNER = ObjectField.OBJECT_END + 0x0,                            // 0x006 - Size: 2 - Type: GUID - Flags: PUBLIC
        ITEM_FIELD_CONTAINED = ObjectField.OBJECT_END + 0x2,                        // 0x008 - Size: 2 - Type: GUID - Flags: PUBLIC
        ITEM_FIELD_CREATOR = ObjectField.OBJECT_END + 0x4,                          // 0x00A - Size: 2 - Type: GUID - Flags: PUBLIC
        ITEM_FIELD_GIFTCREATOR = ObjectField.OBJECT_END + 0x6,                      // 0x00C - Size: 2 - Type: GUID - Flags: PUBLIC
        ITEM_FIELD_STACK_COUNT = ObjectField.OBJECT_END + 0x8,                      // 0x00E - Size: 1 - Type: INT - Flags: OWNER_ONLY + UNK2
        ITEM_FIELD_DURATION = ObjectField.OBJECT_END + 0x9,                         // 0x00F - Size: 1 - Type: INT - Flags: OWNER_ONLY + UNK2
        ITEM_FIELD_SPELL_CHARGES = ObjectField.OBJECT_END + 0xA,                    // 0x010 - Size: 5 - Type: INT - Flags: OWNER_ONLY + UNK2
        ITEM_FIELD_FLAGS = ObjectField.OBJECT_END + 0xF,                            // 0x015 - Size: 1 - Type: INT - Flags: PUBLIC
        ITEM_FIELD_ENCHANTMENT = ObjectField.OBJECT_END + 0x10,                     // 0x016 - Size: 21 - Type: INT - Flags: PUBLIC
        ITEM_FIELD_PROPERTY_SEED = ObjectField.OBJECT_END + 0x25,                   // 0x02B - Size: 1 - Type: INT - Flags: PUBLIC
        ITEM_FIELD_RANDOM_PROPERTIES_ID = ObjectField.OBJECT_END + 0x26,            // 0x02C - Size: 1 - Type: INT - Flags: PUBLIC
        ITEM_FIELD_ITEM_TEXT_ID = ObjectField.OBJECT_END + 0x27,                    // 0x02D - Size: 1 - Type: INT - Flags: OWNER_ONLY
        ITEM_FIELD_DURABILITY = ObjectField.OBJECT_END + 0x28,                      // 0x02E - Size: 1 - Type: INT - Flags: OWNER_ONLY + UNK2
        ITEM_FIELD_MAXDURABILITY = ObjectField.OBJECT_END + 0x29,                   // 0x02F - Size: 1 - Type: INT - Flags: OWNER_ONLY + UNK2
        ITEM_END = ObjectField.OBJECT_END + 0x2A                                    // 0x030
    }

    public enum ContainerField
    {
        CONTAINER_FIELD_NUM_SLOTS = ItemField.ITEM_END + 0x0,                       // 0x02A - Size: 1 - Type: INT - Flags: PUBLIC
        CONTAINER_ALIGN_PAD = ItemField.ITEM_END + 0x1,                             // 0x02B - Size: 1 - Type: BYTES - Flags: NONE
        CONTAINER_FIELD_SLOT_1 = ItemField.ITEM_END + 0x2,                          // 0x02C - Size: 72 - Type: GUID - Flags: PUBLIC
        CONTAINER_END = ItemField.ITEM_END + 0x4A                                   // 0x074
    }

    public enum UnitField
    {
        UNIT_FIELD_CHARM = ObjectField.OBJECT_END + 0x0,                            // 0x006 - Size: 2 - Type: GUID - Flags: PUBLIC
        UNIT_FIELD_SUMMON = ObjectField.OBJECT_END + 0x2,                           // 0x008 - Size: 2 - Type: GUID - Flags: PUBLIC
        UNIT_FIELD_CHARMEDBY = ObjectField.OBJECT_END + 0x4,                        // 0x00A - Size: 2 - Type: GUID - Flags: PUBLIC
        UNIT_FIELD_SUMMONEDBY = ObjectField.OBJECT_END + 0x6,                       // 0x00C - Size: 2 - Type: GUID - Flags: PUBLIC
        UNIT_FIELD_CREATEDBY = ObjectField.OBJECT_END + 0x8,                        // 0x00E - Size: 2 - Type: GUID - Flags: PUBLIC
        UNIT_FIELD_TARGET = ObjectField.OBJECT_END + 0xA,                           // 0x010 - Size: 2 - Type: GUID - Flags: PUBLIC
        UNIT_FIELD_PERSUADED = ObjectField.OBJECT_END + 0xC,                        // 0x012 - Size: 2 - Type: GUID - Flags: PUBLIC
        UNIT_FIELD_CHANNEL_OBJECT = ObjectField.OBJECT_END + 0xE,                   // 0x014 - Size: 2 - Type: GUID - Flags: PUBLIC
        UNIT_FIELD_HEALTH = ObjectField.OBJECT_END + 0x10,                          // 0x016 - Size: 1 - Type: INT - Flags: DYNAMIC
        UNIT_FIELD_POWER1 = ObjectField.OBJECT_END + 0x11,                          // 0x017 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_POWER2 = ObjectField.OBJECT_END + 0x12,                          // 0x018 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_POWER3 = ObjectField.OBJECT_END + 0x13,                          // 0x019 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_POWER4 = ObjectField.OBJECT_END + 0x14,                          // 0x01A - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_POWER5 = ObjectField.OBJECT_END + 0x15,                          // 0x01B - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_MAXHEALTH = ObjectField.OBJECT_END + 0x16,                       // 0x01C - Size: 1 - Type: INT - Flags: DYNAMIC
        UNIT_FIELD_MAXPOWER1 = ObjectField.OBJECT_END + 0x17,                       // 0x01D - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_MAXPOWER2 = ObjectField.OBJECT_END + 0x18,                       // 0x01E - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_MAXPOWER3 = ObjectField.OBJECT_END + 0x19,                       // 0x01F - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_MAXPOWER4 = ObjectField.OBJECT_END + 0x1A,                       // 0x020 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_MAXPOWER5 = ObjectField.OBJECT_END + 0x1B,                       // 0x021 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_LEVEL = ObjectField.OBJECT_END + 0x1C,                           // 0x022 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_FACTIONTEMPLATE = ObjectField.OBJECT_END + 0x1D,                 // 0x023 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_BYTES_0 = ObjectField.OBJECT_END + 0x1E,                         // 0x024 - Size: 1 - Type: BYTES - Flags: PUBLIC
        UNIT_VIRTUAL_ITEM_SLOT_DISPLAY = ObjectField.OBJECT_END + 0x1F,             // 0x025 - Size: 3 - Type: INT - Flags: PUBLIC
        UNIT_VIRTUAL_ITEM_INFO = ObjectField.OBJECT_END + 0x22,                     // 0x028 - Size: 6 - Type: BYTES - Flags: PUBLIC
        UNIT_FIELD_FLAGS = ObjectField.OBJECT_END + 0x28,                           // 0x02E - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_AURA = ObjectField.OBJECT_END + 0x29,                            // 0x02F - Size: 48 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_AURAFLAGS = ObjectField.OBJECT_END + 0x59,                       // 0x05F - Size: 6 - Type: BYTES - Flags: PUBLIC
        UNIT_FIELD_AURALEVELS = ObjectField.OBJECT_END + 0x5F,                      // 0x065 - Size: 12 - Type: BYTES - Flags: PUBLIC
        UNIT_FIELD_AURAAPPLICATIONS = ObjectField.OBJECT_END + 0x6B,                // 0x071 - Size: 12 - Type: BYTES - Flags: PUBLIC
        UNIT_FIELD_AURASTATE = ObjectField.OBJECT_END + 0x77,                       // 0x07D - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_BASEATTACKTIME = ObjectField.OBJECT_END + 0x78,                  // 0x07E - Size: 2 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_RANGEDATTACKTIME = ObjectField.OBJECT_END + 0x7A,                // 0x080 - Size: 1 - Type: INT - Flags: PRIVATE
        UNIT_FIELD_BOUNDINGRADIUS = ObjectField.OBJECT_END + 0x7B,                  // 0x081 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        UNIT_FIELD_COMBATREACH = ObjectField.OBJECT_END + 0x7C,                     // 0x082 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        UNIT_FIELD_DISPLAYID = ObjectField.OBJECT_END + 0x7D,                       // 0x083 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_NATIVEDISPLAYID = ObjectField.OBJECT_END + 0x7E,                 // 0x084 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_MOUNTDISPLAYID = ObjectField.OBJECT_END + 0x7F,                  // 0x085 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_MINDAMAGE = ObjectField.OBJECT_END + 0x80,                       // 0x086 - Size: 1 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY + UNK3
        UNIT_FIELD_MAXDAMAGE = ObjectField.OBJECT_END + 0x81,                       // 0x087 - Size: 1 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY + UNK3
        UNIT_FIELD_MINOFFHANDDAMAGE = ObjectField.OBJECT_END + 0x82,                // 0x088 - Size: 1 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY + UNK3
        UNIT_FIELD_MAXOFFHANDDAMAGE = ObjectField.OBJECT_END + 0x83,                // 0x089 - Size: 1 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY + UNK3
        UNIT_FIELD_BYTES_1 = ObjectField.OBJECT_END + 0x84,                         // 0x08A - Size: 1 - Type: BYTES - Flags: PUBLIC
        UNIT_FIELD_PETNUMBER = ObjectField.OBJECT_END + 0x85,                       // 0x08B - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_PET_NAME_TIMESTAMP = ObjectField.OBJECT_END + 0x86,              // 0x08C - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_FIELD_PETEXPERIENCE = ObjectField.OBJECT_END + 0x87,                   // 0x08D - Size: 1 - Type: INT - Flags: OWNER_ONLY
        UNIT_FIELD_PETNEXTLEVELEXP = ObjectField.OBJECT_END + 0x88,                 // 0x08E - Size: 1 - Type: INT - Flags: OWNER_ONLY
        UNIT_DYNAMIC_FLAGS = ObjectField.OBJECT_END + 0x89,                         // 0x08F - Size: 1 - Type: INT - Flags: DYNAMIC
        UNIT_CHANNEL_SPELL = ObjectField.OBJECT_END + 0x8A,                         // 0x090 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_MOD_CAST_SPEED = ObjectField.OBJECT_END + 0x8B,                        // 0x091 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        UNIT_CREATED_BY_SPELL = ObjectField.OBJECT_END + 0x8C,                      // 0x092 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_NPC_FLAGS = ObjectField.OBJECT_END + 0x8D,                             // 0x093 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_NPC_EMOTESTATE = ObjectField.OBJECT_END + 0x8E,                        // 0x094 - Size: 1 - Type: INT - Flags: PUBLIC
        UNIT_TRAINING_POINTS = ObjectField.OBJECT_END + 0x8F,                       // 0x095 - Size: 1 - Type: TWO_SHORT - Flags: OWNER_ONLY
        UNIT_FIELD_STAT0 = ObjectField.OBJECT_END + 0x90,                           // 0x096 - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_STAT1 = ObjectField.OBJECT_END + 0x91,                           // 0x097 - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_STAT2 = ObjectField.OBJECT_END + 0x92,                           // 0x098 - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_STAT3 = ObjectField.OBJECT_END + 0x93,                           // 0x099 - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_STAT4 = ObjectField.OBJECT_END + 0x94,                           // 0x09A - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_RESISTANCES = ObjectField.OBJECT_END + 0x95,                     // 0x09B - Size: 7 - Type: INT - Flags: PRIVATE + OWNER_ONLY + UNK3
        UNIT_FIELD_BASE_MANA = ObjectField.OBJECT_END + 0x9C,                       // 0x0A2 - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_BASE_HEALTH = ObjectField.OBJECT_END + 0x9D,                     // 0x0A3 - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_BYTES_2 = ObjectField.OBJECT_END + 0x9E,                         // 0x0A4 - Size: 1 - Type: BYTES - Flags: PUBLIC
        UNIT_FIELD_ATTACK_POWER = ObjectField.OBJECT_END + 0x9F,                    // 0x0A5 - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_ATTACK_POWER_MODS = ObjectField.OBJECT_END + 0xA0,               // 0x0A6 - Size: 1 - Type: TWO_SHORT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_ATTACK_POWER_MULTIPLIER = ObjectField.OBJECT_END + 0xA1,         // 0x0A7 - Size: 1 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_RANGED_ATTACK_POWER = ObjectField.OBJECT_END + 0xA2,             // 0x0A8 - Size: 1 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_RANGED_ATTACK_POWER_MODS = ObjectField.OBJECT_END + 0xA3,        // 0x0A9 - Size: 1 - Type: TWO_SHORT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER = ObjectField.OBJECT_END + 0xA4,  // 0x0AA - Size: 1 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_MINRANGEDDAMAGE = ObjectField.OBJECT_END + 0xA5,                 // 0x0AB - Size: 1 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_MAXRANGEDDAMAGE = ObjectField.OBJECT_END + 0xA6,                 // 0x0AC - Size: 1 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_POWER_COST_MODIFIER = ObjectField.OBJECT_END + 0xA7,             // 0x0AD - Size: 7 - Type: INT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_POWER_COST_MULTIPLIER = ObjectField.OBJECT_END + 0xAE,           // 0x0B4 - Size: 7 - Type: FLOAT - Flags: PRIVATE + OWNER_ONLY
        UNIT_FIELD_PADDING = ObjectField.OBJECT_END + 0xB5,                         // 0x0BB - Size: 1 - Type: INT - Flags: NONE
        UNIT_END = ObjectField.OBJECT_END + 0xB6                                    // 0x0BC
    }

    public enum PlayerField
    {
        PLAYER_DUEL_ARBITER = UnitField.UNIT_END + 0x0,                             // 0x0B6 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_FLAGS = UnitField.UNIT_END + 0x2,                                    // 0x0B8 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_GUILDID = UnitField.UNIT_END + 0x3,                                  // 0x0B9 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_GUILDRANK = UnitField.UNIT_END + 0x4,                                // 0x0BA - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_BYTES = UnitField.UNIT_END + 0x5,                                    // 0x0BB - Size: 1 - Type: BYTES - Flags: PUBLIC
        PLAYER_BYTES_2 = UnitField.UNIT_END + 0x6,                                  // 0x0BC - Size: 1 - Type: BYTES - Flags: PUBLIC
        PLAYER_BYTES_3 = UnitField.UNIT_END + 0x7,                                  // 0x0BD - Size: 1 - Type: BYTES - Flags: PUBLIC
        PLAYER_DUEL_TEAM = UnitField.UNIT_END + 0x8,                                // 0x0BE - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_GUILD_TIMESTAMP = UnitField.UNIT_END + 0x9,                          // 0x0BF - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_QUEST_LOG_1_1 = UnitField.UNIT_END + 0xA,                            // 0x0C0 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_1_2 = UnitField.UNIT_END + 0xB,                            // 0x0C1 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_2_1 = UnitField.UNIT_END + 0xD,                            // 0x0C3 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_2_2 = UnitField.UNIT_END + 0xE,                            // 0x0C4 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_3_1 = UnitField.UNIT_END + 0x10,                           // 0x0C6 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_3_2 = UnitField.UNIT_END + 0x11,                           // 0x0C7 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_4_1 = UnitField.UNIT_END + 0x13,                           // 0x0C9 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_4_2 = UnitField.UNIT_END + 0x14,                           // 0x0CA - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_5_1 = UnitField.UNIT_END + 0x16,                           // 0x0CC - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_5_2 = UnitField.UNIT_END + 0x17,                           // 0x0CD - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_6_1 = UnitField.UNIT_END + 0x19,                           // 0x0CF - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_6_2 = UnitField.UNIT_END + 0x1A,                           // 0x0D0 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_7_1 = UnitField.UNIT_END + 0x1C,                           // 0x0D2 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_7_2 = UnitField.UNIT_END + 0x1D,                           // 0x0D3 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_8_1 = UnitField.UNIT_END + 0x1F,                           // 0x0D5 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_8_2 = UnitField.UNIT_END + 0x20,                           // 0x0D6 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_9_1 = UnitField.UNIT_END + 0x22,                           // 0x0D8 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_9_2 = UnitField.UNIT_END + 0x23,                           // 0x0D9 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_10_1 = UnitField.UNIT_END + 0x25,                          // 0x0DB - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_10_2 = UnitField.UNIT_END + 0x26,                          // 0x0DC - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_11_1 = UnitField.UNIT_END + 0x28,                          // 0x0DE - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_11_2 = UnitField.UNIT_END + 0x29,                          // 0x0DF - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_12_1 = UnitField.UNIT_END + 0x2B,                          // 0x0E1 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_12_2 = UnitField.UNIT_END + 0x2C,                          // 0x0E2 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_13_1 = UnitField.UNIT_END + 0x2E,                          // 0x0E4 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_13_2 = UnitField.UNIT_END + 0x2F,                          // 0x0E5 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_14_1 = UnitField.UNIT_END + 0x31,                          // 0x0E7 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_14_2 = UnitField.UNIT_END + 0x32,                          // 0x0E8 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_15_1 = UnitField.UNIT_END + 0x34,                          // 0x0EA - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_15_2 = UnitField.UNIT_END + 0x35,                          // 0x0EB - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_16_1 = UnitField.UNIT_END + 0x37,                          // 0x0ED - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_16_2 = UnitField.UNIT_END + 0x38,                          // 0x0EE - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_17_1 = UnitField.UNIT_END + 0x3A,                          // 0x0F0 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_17_2 = UnitField.UNIT_END + 0x3B,                          // 0x0F1 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_18_1 = UnitField.UNIT_END + 0x3D,                          // 0x0F3 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_18_2 = UnitField.UNIT_END + 0x3E,                          // 0x0F4 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_19_1 = UnitField.UNIT_END + 0x40,                          // 0x0F6 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_19_2 = UnitField.UNIT_END + 0x41,                          // 0x0F7 - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_QUEST_LOG_20_1 = UnitField.UNIT_END + 0x43,                          // 0x0F9 - Size: 1 - Type: INT - Flags: GROUP_ONLY
        PLAYER_QUEST_LOG_20_2 = UnitField.UNIT_END + 0x44,                          // 0x0FA - Size: 2 - Type: INT - Flags: PRIVATE
        PLAYER_VISIBLE_ITEM_1_CREATOR = UnitField.UNIT_END + 0x46,                  // 0x0FC - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_1_0 = UnitField.UNIT_END + 0x48,                        // 0x0FE - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_1_PROPERTIES = UnitField.UNIT_END + 0x50,               // 0x106 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_1_PAD = UnitField.UNIT_END + 0x51,                      // 0x107 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_2_CREATOR = UnitField.UNIT_END + 0x52,                  // 0x108 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_2_0 = UnitField.UNIT_END + 0x54,                        // 0x10A - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_2_PROPERTIES = UnitField.UNIT_END + 0x5C,               // 0x112 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_2_PAD = UnitField.UNIT_END + 0x5D,                      // 0x113 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_3_CREATOR = UnitField.UNIT_END + 0x5E,                  // 0x114 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_3_0 = UnitField.UNIT_END + 0x60,                        // 0x116 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_3_PROPERTIES = UnitField.UNIT_END + 0x68,               // 0x11E - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_3_PAD = UnitField.UNIT_END + 0x69,                      // 0x11F - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_4_CREATOR = UnitField.UNIT_END + 0x6A,                  // 0x120 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_4_0 = UnitField.UNIT_END + 0x6C,                        // 0x122 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_4_PROPERTIES = UnitField.UNIT_END + 0x74,               // 0x12A - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_4_PAD = UnitField.UNIT_END + 0x75,                      // 0x12B - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_5_CREATOR = UnitField.UNIT_END + 0x76,                  // 0x12C - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_5_0 = UnitField.UNIT_END + 0x78,                        // 0x12E - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_5_PROPERTIES = UnitField.UNIT_END + 0x80,               // 0x136 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_5_PAD = UnitField.UNIT_END + 0x81,                      // 0x137 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_6_CREATOR = UnitField.UNIT_END + 0x82,                  // 0x138 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_6_0 = UnitField.UNIT_END + 0x84,                        // 0x13A - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_6_PROPERTIES = UnitField.UNIT_END + 0x8C,               // 0x142 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_6_PAD = UnitField.UNIT_END + 0x8D,                      // 0x143 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_7_CREATOR = UnitField.UNIT_END + 0x8E,                  // 0x144 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_7_0 = UnitField.UNIT_END + 0x90,                        // 0x146 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_7_PROPERTIES = UnitField.UNIT_END + 0x98,               // 0x14E - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_7_PAD = UnitField.UNIT_END + 0x99,                      // 0x14F - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_8_CREATOR = UnitField.UNIT_END + 0x9A,                  // 0x150 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_8_0 = UnitField.UNIT_END + 0x9C,                        // 0x152 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_8_PROPERTIES = UnitField.UNIT_END + 0xA4,               // 0x15A - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_8_PAD = UnitField.UNIT_END + 0xA5,                      // 0x15B - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_9_CREATOR = UnitField.UNIT_END + 0xA6,                  // 0x15C - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_9_0 = UnitField.UNIT_END + 0xA8,                        // 0x15E - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_9_PROPERTIES = UnitField.UNIT_END + 0xB0,               // 0x166 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_9_PAD = UnitField.UNIT_END + 0xB1,                      // 0x167 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_10_CREATOR = UnitField.UNIT_END + 0xB2,                 // 0x168 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_10_0 = UnitField.UNIT_END + 0xB4,                       // 0x16A - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_10_PROPERTIES = UnitField.UNIT_END + 0xBC,              // 0x172 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_10_PAD = UnitField.UNIT_END + 0xBD,                     // 0x173 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_11_CREATOR = UnitField.UNIT_END + 0xBE,                 // 0x174 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_11_0 = UnitField.UNIT_END + 0xC0,                       // 0x176 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_11_PROPERTIES = UnitField.UNIT_END + 0xC8,              // 0x17E - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_11_PAD = UnitField.UNIT_END + 0xC9,                     // 0x17F - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_12_CREATOR = UnitField.UNIT_END + 0xCA,                 // 0x180 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_12_0 = UnitField.UNIT_END + 0xCC,                       // 0x182 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_12_PROPERTIES = UnitField.UNIT_END + 0xD4,              // 0x18A - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_12_PAD = UnitField.UNIT_END + 0xD5,                     // 0x18B - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_13_CREATOR = UnitField.UNIT_END + 0xD6,                 // 0x18C - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_13_0 = UnitField.UNIT_END + 0xD8,                       // 0x18E - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_13_PROPERTIES = UnitField.UNIT_END + 0xE0,              // 0x196 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_13_PAD = UnitField.UNIT_END + 0xE1,                     // 0x197 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_14_CREATOR = UnitField.UNIT_END + 0xE2,                 // 0x198 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_14_0 = UnitField.UNIT_END + 0xE4,                       // 0x19A - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_14_PROPERTIES = UnitField.UNIT_END + 0xEC,              // 0x1A2 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_14_PAD = UnitField.UNIT_END + 0xED,                     // 0x1A3 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_15_CREATOR = UnitField.UNIT_END + 0xEE,                 // 0x1A4 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_15_0 = UnitField.UNIT_END + 0xF0,                       // 0x1A6 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_15_PROPERTIES = UnitField.UNIT_END + 0xF8,              // 0x1AE - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_15_PAD = UnitField.UNIT_END + 0xF9,                     // 0x1AF - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_16_CREATOR = UnitField.UNIT_END + 0xFA,                 // 0x1B0 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_16_0 = UnitField.UNIT_END + 0xFC,                       // 0x1B2 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_16_PROPERTIES = UnitField.UNIT_END + 0x104,             // 0x1BA - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_16_PAD = UnitField.UNIT_END + 0x105,                    // 0x1BB - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_17_CREATOR = UnitField.UNIT_END + 0x106,                // 0x1BC - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_17_0 = UnitField.UNIT_END + 0x108,                      // 0x1BE - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_17_PROPERTIES = UnitField.UNIT_END + 0x110,             // 0x1C6 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_17_PAD = UnitField.UNIT_END + 0x111,                    // 0x1C7 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_18_CREATOR = UnitField.UNIT_END + 0x112,                // 0x1C8 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_18_0 = UnitField.UNIT_END + 0x114,                      // 0x1CA - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_18_PROPERTIES = UnitField.UNIT_END + 0x11C,             // 0x1D2 - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_18_PAD = UnitField.UNIT_END + 0x11D,                    // 0x1D3 - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_19_CREATOR = UnitField.UNIT_END + 0x11E,                // 0x1D4 - Size: 2 - Type: GUID - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_19_0 = UnitField.UNIT_END + 0x120,                      // 0x1D6 - Size: 8 - Type: INT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_19_PROPERTIES = UnitField.UNIT_END + 0x128,             // 0x1DE - Size: 1 - Type: TWO_SHORT - Flags: PUBLIC
        PLAYER_VISIBLE_ITEM_19_PAD = UnitField.UNIT_END + 0x129,                    // 0x1DF - Size: 1 - Type: INT - Flags: PUBLIC
        PLAYER_FIELD_INV_SLOT_HEAD = UnitField.UNIT_END + 0x12A,                    // 0x1E0 - Size: 46 - Type: GUID - Flags: PRIVATE
        PLAYER_FIELD_PACK_SLOT_1 = UnitField.UNIT_END + 0x158,                      // 0x20E - Size: 32 - Type: GUID - Flags: PRIVATE
        PLAYER_FIELD_BANK_SLOT_1 = UnitField.UNIT_END + 0x178,                      // 0x22E - Size: 48 - Type: GUID - Flags: PRIVATE
        PLAYER_FIELD_BANKBAG_SLOT_1 = UnitField.UNIT_END + 0x1A8,                   // 0x25E - Size: 12 - Type: GUID - Flags: PRIVATE
        PLAYER_FIELD_VENDORBUYBACK_SLOT_1 = UnitField.UNIT_END + 0x1B4,             // 0x26A - Size: 24 - Type: GUID - Flags: PRIVATE
        PLAYER_FIELD_KEYRING_SLOT_1 = UnitField.UNIT_END + 0x1CC,                   // 0x282 - Size: 64 - Type: GUID - Flags: PRIVATE
        PLAYER_FARSIGHT = UnitField.UNIT_END + 0x20C,                               // 0x2C2 - Size: 2 - Type: GUID - Flags: PRIVATE
        PLAYER_FIELD_COMBO_TARGET = UnitField.UNIT_END + 0x20E,                     // 0x2C4 - Size: 2 - Type: GUID - Flags: PRIVATE
        PLAYER_XP = UnitField.UNIT_END + 0x210,                                     // 0x2C6 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_NEXT_LEVEL_XP = UnitField.UNIT_END + 0x211,                          // 0x2C7 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_SKILL_INFO_1_1 = UnitField.UNIT_END + 0x212,                         // 0x2C8 - Size: 384 - Type: TWO_SHORT - Flags: PRIVATE
        PLAYER_CHARACTER_POINTS1 = UnitField.UNIT_END + 0x392,                      // 0x448 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_CHARACTER_POINTS2 = UnitField.UNIT_END + 0x393,                      // 0x449 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_TRACK_CREATURES = UnitField.UNIT_END + 0x394,                        // 0x44A - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_TRACK_RESOURCES = UnitField.UNIT_END + 0x395,                        // 0x44B - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_BLOCK_PERCENTAGE = UnitField.UNIT_END + 0x396,                       // 0x44C - Size: 1 - Type: FLOAT - Flags: PRIVATE
        PLAYER_DODGE_PERCENTAGE = UnitField.UNIT_END + 0x397,                       // 0x44D - Size: 1 - Type: FLOAT - Flags: PRIVATE
        PLAYER_PARRY_PERCENTAGE = UnitField.UNIT_END + 0x398,                       // 0x44E - Size: 1 - Type: FLOAT - Flags: PRIVATE
        PLAYER_CRIT_PERCENTAGE = UnitField.UNIT_END + 0x399,                        // 0x44F - Size: 1 - Type: FLOAT - Flags: PRIVATE
        PLAYER_RANGED_CRIT_PERCENTAGE = UnitField.UNIT_END + 0x39A,                 // 0x450 - Size: 1 - Type: FLOAT - Flags: PRIVATE
        PLAYER_EXPLORED_ZONES_1 = UnitField.UNIT_END + 0x39B,                       // 0x451 - Size: 64 - Type: BYTES - Flags: PRIVATE
        PLAYER_REST_STATE_EXPERIENCE = UnitField.UNIT_END + 0x3DB,                  // 0x491 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_COINAGE = UnitField.UNIT_END + 0x3DC,                          // 0x492 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_POSSTAT0 = UnitField.UNIT_END + 0x3DD,                         // 0x493 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_POSSTAT1 = UnitField.UNIT_END + 0x3DE,                         // 0x494 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_POSSTAT2 = UnitField.UNIT_END + 0x3DF,                         // 0x495 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_POSSTAT3 = UnitField.UNIT_END + 0x3E0,                         // 0x496 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_POSSTAT4 = UnitField.UNIT_END + 0x3E1,                         // 0x497 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_NEGSTAT0 = UnitField.UNIT_END + 0x3E2,                         // 0x498 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_NEGSTAT1 = UnitField.UNIT_END + 0x3E3,                         // 0x499 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_NEGSTAT2 = UnitField.UNIT_END + 0x3E4,                         // 0x49A - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_NEGSTAT3 = UnitField.UNIT_END + 0x3E5,                         // 0x49B - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_NEGSTAT4 = UnitField.UNIT_END + 0x3E6,                         // 0x49C - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE = UnitField.UNIT_END + 0x3E7,       // 0x49D - Size: 7 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE = UnitField.UNIT_END + 0x3EE,       // 0x4A4 - Size: 7 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_MOD_DAMAGE_DONE_POS = UnitField.UNIT_END + 0x3F5,              // 0x4AB - Size: 7 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_MOD_DAMAGE_DONE_NEG = UnitField.UNIT_END + 0x3FC,              // 0x4B2 - Size: 7 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_MOD_DAMAGE_DONE_PCT = UnitField.UNIT_END + 0x403,              // 0x4B9 - Size: 7 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_BYTES = UnitField.UNIT_END + 0x40A,                            // 0x4C0 - Size: 1 - Type: BYTES - Flags: PRIVATE
        PLAYER_AMMO_ID = UnitField.UNIT_END + 0x40B,                                // 0x4C1 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_SELF_RES_SPELL = UnitField.UNIT_END + 0x40C,                         // 0x4C2 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_PVP_MEDALS = UnitField.UNIT_END + 0x40D,                       // 0x4C3 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_BUYBACK_PRICE_1 = UnitField.UNIT_END + 0x40E,                  // 0x4C4 - Size: 12 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_BUYBACK_TIMESTAMP_1 = UnitField.UNIT_END + 0x41A,              // 0x4D0 - Size: 12 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_SESSION_KILLS = UnitField.UNIT_END + 0x426,                    // 0x4DC - Size: 1 - Type: TWO_SHORT - Flags: PRIVATE
        PLAYER_FIELD_YESTERDAY_KILLS = UnitField.UNIT_END + 0x427,                  // 0x4DD - Size: 1 - Type: TWO_SHORT - Flags: PRIVATE
        PLAYER_FIELD_LAST_WEEK_KILLS = UnitField.UNIT_END + 0x428,                  // 0x4DE - Size: 1 - Type: TWO_SHORT - Flags: PRIVATE
        PLAYER_FIELD_THIS_WEEK_KILLS = UnitField.UNIT_END + 0x429,                  // 0x4DF - Size: 1 - Type: TWO_SHORT - Flags: PRIVATE
        PLAYER_FIELD_THIS_WEEK_CONTRIBUTION = UnitField.UNIT_END + 0x42A,           // 0x4E0 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_LIFETIME_HONORABLE_KILLS = UnitField.UNIT_END + 0x42B,         // 0x4E1 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_LIFETIME_DISHONORABLE_KILLS = UnitField.UNIT_END + 0x42C,      // 0x4E2 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_YESTERDAY_CONTRIBUTION = UnitField.UNIT_END + 0x42D,           // 0x4E3 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_LAST_WEEK_CONTRIBUTION = UnitField.UNIT_END + 0x42E,           // 0x4E4 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_LAST_WEEK_RANK = UnitField.UNIT_END + 0x42F,                   // 0x4E5 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_BYTES2 = UnitField.UNIT_END + 0x430,                           // 0x4E6 - Size: 1 - Type: BYTES - Flags: PRIVATE
        PLAYER_FIELD_WATCHED_FACTION_INDEX = UnitField.UNIT_END + 0x431,            // 0x4E7 - Size: 1 - Type: INT - Flags: PRIVATE
        PLAYER_FIELD_COMBAT_RATING_1 = UnitField.UNIT_END + 0x432,                  // 0x4E8 - Size: 20 - Type: INT - Flags: PRIVATE
        PLAYER_END = UnitField.UNIT_END + 0x446                                     // 0x4FC
    }

    public enum GameObjectField
    {
        GAMEOBJECT_FIELD_CREATED_BY = ObjectField.OBJECT_END + 0x0,                 // 0x006 - Size: 2 - Type: GUID - Flags: PUBLIC
        GAMEOBJECT_DISPLAYID = ObjectField.OBJECT_END + 0x2,                        // 0x008 - Size: 1 - Type: INT - Flags: PUBLIC
        GAMEOBJECT_FLAGS = ObjectField.OBJECT_END + 0x3,                            // 0x009 - Size: 1 - Type: INT - Flags: PUBLIC
        GAMEOBJECT_ROTATION = ObjectField.OBJECT_END + 0x4,                         // 0x00A - Size: 4 - Type: FLOAT - Flags: PUBLIC
        GAMEOBJECT_STATE = ObjectField.OBJECT_END + 0x8,                            // 0x00E - Size: 1 - Type: INT - Flags: PUBLIC
        GAMEOBJECT_POS_X = ObjectField.OBJECT_END + 0x9,                            // 0x00F - Size: 1 - Type: FLOAT - Flags: PUBLIC
        GAMEOBJECT_POS_Y = ObjectField.OBJECT_END + 0xA,                            // 0x010 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        GAMEOBJECT_POS_Z = ObjectField.OBJECT_END + 0xB,                            // 0x011 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        GAMEOBJECT_FACING = ObjectField.OBJECT_END + 0xC,                           // 0x012 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        GAMEOBJECT_DYN_FLAGS = ObjectField.OBJECT_END + 0xD,                        // 0x013 - Size: 1 - Type: INT - Flags: DYNAMIC
        GAMEOBJECT_FACTION = ObjectField.OBJECT_END + 0xE,                          // 0x014 - Size: 1 - Type: INT - Flags: PUBLIC
        GAMEOBJECT_TYPE_ID = ObjectField.OBJECT_END + 0xF,                          // 0x015 - Size: 1 - Type: INT - Flags: PUBLIC
        GAMEOBJECT_LEVEL = ObjectField.OBJECT_END + 0x10,                           // 0x016 - Size: 1 - Type: INT - Flags: PUBLIC
        GAMEOBJECT_ARTKIT = ObjectField.OBJECT_END + 0x11,                          // 0x017 - Size: 1 - Type: INT - Flags: PUBLIC
        GAMEOBJECT_ANIMPROGRESS = ObjectField.OBJECT_END + 0x12,                    // 0x018 - Size: 1 - Type: INT - Flags: DYNAMIC
        GAMEOBJECT_PADDING = ObjectField.OBJECT_END + 0x13,                         // 0x019 - Size: 1 - Type: INT - Flags: NONE
        GAMEOBJECT_END = ObjectField.OBJECT_END + 0x14                              // 0x01A
    }

    public enum DynamicObjectField
    {
        DYNAMICOBJECT_CASTER = ObjectField.OBJECT_END + 0x0,                        // 0x006 - Size: 2 - Type: GUID - Flags: PUBLIC
        DYNAMICOBJECT_BYTES = ObjectField.OBJECT_END + 0x2,                         // 0x008 - Size: 1 - Type: BYTES - Flags: PUBLIC
        DYNAMICOBJECT_SPELLID = ObjectField.OBJECT_END + 0x3,                       // 0x009 - Size: 1 - Type: INT - Flags: PUBLIC
        DYNAMICOBJECT_RADIUS = ObjectField.OBJECT_END + 0x4,                        // 0x00A - Size: 1 - Type: FLOAT - Flags: PUBLIC
        DYNAMICOBJECT_POS_X = ObjectField.OBJECT_END + 0x5,                         // 0x00B - Size: 1 - Type: FLOAT - Flags: PUBLIC
        DYNAMICOBJECT_POS_Y = ObjectField.OBJECT_END + 0x6,                         // 0x00C - Size: 1 - Type: FLOAT - Flags: PUBLIC
        DYNAMICOBJECT_POS_Z = ObjectField.OBJECT_END + 0x7,                         // 0x00D - Size: 1 - Type: FLOAT - Flags: PUBLIC
        DYNAMICOBJECT_FACING = ObjectField.OBJECT_END + 0x8,                        // 0x00E - Size: 1 - Type: FLOAT - Flags: PUBLIC
        DYNAMICOBJECT_PAD = ObjectField.OBJECT_END + 0x9,                           // 0x00F - Size: 1 - Type: BYTES - Flags: PUBLIC
        DYNAMICOBJECT_END = ObjectField.OBJECT_END + 0xA                            // 0x010
    }

    public enum CorpseField
    {
        CORPSE_FIELD_OWNER = ObjectField.OBJECT_END + 0x0,                          // 0x006 - Size: 2 - Type: GUID - Flags: PUBLIC
        CORPSE_FIELD_FACING = ObjectField.OBJECT_END + 0x2,                         // 0x008 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        CORPSE_FIELD_POS_X = ObjectField.OBJECT_END + 0x3,                          // 0x009 - Size: 1 - Type: FLOAT - Flags: PUBLIC
        CORPSE_FIELD_POS_Y = ObjectField.OBJECT_END + 0x4,                          // 0x00A - Size: 1 - Type: FLOAT - Flags: PUBLIC
        CORPSE_FIELD_POS_Z = ObjectField.OBJECT_END + 0x5,                          // 0x00B - Size: 1 - Type: FLOAT - Flags: PUBLIC
        CORPSE_FIELD_DISPLAY_ID = ObjectField.OBJECT_END + 0x6,                     // 0x00C - Size: 1 - Type: INT - Flags: PUBLIC
        CORPSE_FIELD_ITEM = ObjectField.OBJECT_END + 0x7,                           // 0x00D - Size: 19 - Type: INT - Flags: PUBLIC
        CORPSE_FIELD_BYTES_1 = ObjectField.OBJECT_END + 0x1A,                       // 0x020 - Size: 1 - Type: BYTES - Flags: PUBLIC
        CORPSE_FIELD_BYTES_2 = ObjectField.OBJECT_END + 0x1B,                       // 0x021 - Size: 1 - Type: BYTES - Flags: PUBLIC
        CORPSE_FIELD_GUILD = ObjectField.OBJECT_END + 0x1C,                         // 0x022 - Size: 1 - Type: INT - Flags: PUBLIC
        CORPSE_FIELD_FLAGS = ObjectField.OBJECT_END + 0x1D,                         // 0x023 - Size: 1 - Type: INT - Flags: PUBLIC
        CORPSE_FIELD_DYNAMIC_FLAGS = ObjectField.OBJECT_END + 0x1E,                 // 0x024 - Size: 1 - Type: INT - Flags: DYNAMIC
        CORPSE_FIELD_PAD = ObjectField.OBJECT_END + 0x1F,                           // 0x025 - Size: 1 - Type: INT - Flags: NONE
        CORPSE_END = ObjectField.OBJECT_END + 0x20                                  // 0x026
    }
}
