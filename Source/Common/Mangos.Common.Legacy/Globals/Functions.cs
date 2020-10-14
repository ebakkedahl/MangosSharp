﻿//
//  Copyright (C) 2013-2020 getMaNGOS <https:\\getmangos.eu>
//  
//  This program is free software. You can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation. either version 2 of the License, or
//  (at your option) any later version.
//  
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY. Without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//

// Note: Temp place holder
using System;
using System.Data;
using global;
using Mangos.Common.Enums.Global;
using Mangos.Common.Enums.Player;
using Mangos.Loggers;
using Microsoft.VisualBasic;

namespace Mangos.Common.Globals
{
    public class Functions
    {
        private readonly Global_Constants _Global_Constants;
		private readonly ILogger logger;

		public Functions(Global_Constants globalConstants, ILogger logger)
		{
			_Global_Constants = globalConstants;
			this.logger = logger;
		}

		public bool GuidIsCreature(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_UNIT)
                return true;
            return false;
        }

        public bool GuidIsPet(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_PET)
                return true;
            return false;
        }

        public bool GuidIsItem(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_ITEM)
                return true;
            return false;
        }

        public bool GuidIsGameObject(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_GAMEOBJECT)
                return true;
            return false;
        }

        public bool GuidIsDnyamicObject(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_DYNAMICOBJECT)
                return true;
            return false;
        }

        public bool GuidIsTransport(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_TRANSPORT)
                return true;
            return false;
        }

        public bool GuidIsMoTransport(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_MO_TRANSPORT)
                return true;
            return false;
        }

        public bool GuidIsCorpse(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_CORPSE)
                return true;
            return false;
        }

        public bool GuidIsPlayer(ulong guid)
        {
            if (GuidHigh2(guid) == _Global_Constants.GUID_PLAYER)
                return true;
            return false;
        }

        public ulong GuidHigh2(ulong guid)
        {
            return guid & _Global_Constants.GUID_MASK_HIGH;
        }

        public uint GuidHigh(ulong guid)
        {
            return (uint)((guid & _Global_Constants.GUID_MASK_HIGH) >> 32);
        }

        public uint GuidLow(ulong guid)
        {
            return (uint)(guid & _Global_Constants.GUID_MASK_LOW);
        }

        public int GetShapeshiftModel(ShapeshiftForm form, Races race, int model)
        {
            switch (form)
            {
                case ShapeshiftForm.FORM_CAT:
                    {
                        if (race == Races.RACE_NIGHT_ELF)
                            return 892;
                        if (race == Races.RACE_TAUREN)
                            return 8571;
                        break;
                    }

                case ShapeshiftForm.FORM_BEAR:
                case ShapeshiftForm.FORM_DIREBEAR:
                    {
                        if (race == Races.RACE_NIGHT_ELF)
                            return 2281;
                        if (race == Races.RACE_TAUREN)
                            return 2289;
                        break;
                    }

                case ShapeshiftForm.FORM_MOONKIN:
                    {
                        if (race == Races.RACE_NIGHT_ELF)
                            return 15374;
                        if (race == Races.RACE_TAUREN)
                            return 15375;
                        break;
                    }

                case ShapeshiftForm.FORM_TRAVEL:
                    {
                        return 632;
                    }

                case ShapeshiftForm.FORM_AQUA:
                    {
                        return 2428;
                    }

                case ShapeshiftForm.FORM_FLIGHT:
                    {
                        if (race == Races.RACE_NIGHT_ELF)
                            return 20857;
                        if (race == Races.RACE_TAUREN)
                            return 20872;
                        break;
                    }

                case ShapeshiftForm.FORM_SWIFT:
                    {
                        if (race == Races.RACE_NIGHT_ELF)
                            return 21243;
                        if (race == Races.RACE_TAUREN)
                            return 21244;
                        break;
                    }

                case ShapeshiftForm.FORM_GHOUL:
                    {
                        if (race == Races.RACE_NIGHT_ELF)
                            return 10045;
                        else
                            return model;
                    }

                case ShapeshiftForm.FORM_CREATUREBEAR:
                    {
                        return 902;
                    }

                case ShapeshiftForm.FORM_GHOSTWOLF:
                    {
                        return 4613;
                    }

                case ShapeshiftForm.FORM_SPIRITOFREDEMPTION:
                    {
                        return 12824;
                    }

                default:
                    {
                        return model;
                    }
                    // Case ShapeshiftForm.FORM_CREATURECAT
                    // Case ShapeshiftForm.FORM_AMBIENT
                    // Case ShapeshiftForm.FORM_SHADOW
            }

            return default;
        }

        public ManaTypes GetShapeshiftManaType(ShapeshiftForm form, ManaTypes manaType)
        {
            switch (form)
            {
                case ShapeshiftForm.FORM_CAT:
                case ShapeshiftForm.FORM_STEALTH:
                    {
                        return ManaTypes.TYPE_ENERGY;
                    }

                case ShapeshiftForm.FORM_AQUA:
                case ShapeshiftForm.FORM_TRAVEL:
                case ShapeshiftForm.FORM_MOONKIN:
                case var @case when @case == ShapeshiftForm.FORM_MOONKIN:
                case var case1 when case1 == ShapeshiftForm.FORM_MOONKIN:
                case ShapeshiftForm.FORM_SPIRITOFREDEMPTION:
                case ShapeshiftForm.FORM_FLIGHT:
                case ShapeshiftForm.FORM_SWIFT:
                    {
                        return ManaTypes.TYPE_MANA;
                    }

                case ShapeshiftForm.FORM_BEAR:
                case ShapeshiftForm.FORM_DIREBEAR:
                    {
                        return ManaTypes.TYPE_RAGE;
                    }

                default:
                    {
                        return manaType;
                    }
            }
        }

        public bool CheckRequiredDbVersion(SQL thisDatabase, ServerDb thisServerDb)
        {
            var mySqlQuery = new DataTable();
            // thisDatabase.Query(String.Format("SELECT column_name FROM information_schema.columns WHERE table_name='" & thisTableName & "'  AND TABLE_SCHEMA='" & thisDatabase.SQLDBName & "'"), mySqlQuery)
            thisDatabase.Query("SELECT `version`,`structure`,`content` FROM db_version ORDER BY VERSION DESC, structure DESC, content DESC LIMIT 0,1", ref mySqlQuery);
            // Check database version against code version

            int coreDbVersion = 0;
            int coreDbStructure = 0;
            int coreDbContent = 0;
            switch (thisServerDb)
            {
                case ServerDb.Realm:
                    {
                        coreDbVersion = _Global_Constants.RevisionDbRealmVersion;
                        coreDbStructure = _Global_Constants.RevisionDbRealmStructure;
                        coreDbContent = _Global_Constants.RevisionDbRealmContent;
                        break;
                    }

                case ServerDb.Character:
                    {
                        coreDbVersion = _Global_Constants.RevisionDbCharactersVersion;
                        coreDbStructure = _Global_Constants.RevisionDbCharactersStructure;
                        coreDbContent = _Global_Constants.RevisionDbCharactersContent;
                        break;
                    }

                case ServerDb.World:
                    {
                        coreDbVersion = _Global_Constants.RevisionDbMangosVersion;
                        coreDbStructure = _Global_Constants.RevisionDbMangosStructure;
                        coreDbContent = _Global_Constants.RevisionDbMangosContent;
                        break;
                    }
            }

            if (mySqlQuery.Rows.Count > 0)
            {
                // For Each row As DataRow In mySqlQuery.Rows
                // dtVersion = row.Item("column_name").ToString
                // Next
                int dbVersion = Convert.ToInt32(mySqlQuery.Rows[0]["version"].ToString());
                int dbStructure = Convert.ToInt32(mySqlQuery.Rows[0]["structure"].ToString());
                int dbContent = Convert.ToInt32(mySqlQuery.Rows[0]["content"].ToString());

                // NOTES: Version or Structure mismatch is a hard error, Content mismatch as a warning

                if (dbVersion == coreDbVersion & dbStructure == coreDbStructure & dbContent == coreDbContent) // Full Match
                {
					logger.Debug("[{0}] Db Version Matched", Strings.Format(DateAndTime.TimeOfDay, "hh:mm:ss"));
                    return true;
                }
                else if (dbVersion == coreDbVersion & dbStructure == coreDbStructure & dbContent != coreDbContent) // Content MisMatch, only a warning
                {
					logger.Warning("--------------------------------------------------------------");
					logger.Warning("-- WARNING: CONTENT VERSION MISMATCH                        --");
					logger.Warning("--------------------------------------------------------------");
					logger.Warning("Your Database " + thisDatabase.SQLDBName + " requires updating.");
					logger.Warning("You have: Rev{0}.{1}.{2}, however the core expects Rev{3}.{4}.{5}", dbVersion, dbStructure, dbContent, coreDbVersion, coreDbStructure, coreDbContent);
					logger.Warning("The server will run, but you may be missing some database fixes");
                    return true;
                }
                else // Oh no they do not match
                {
					logger.Error("--------------------------------------------------------------");
					logger.Error("-- FATAL ERROR: VERSION MISMATCH                            --");
					logger.Error("--------------------------------------------------------------");
					logger.Error("Your Database " + thisDatabase.SQLDBName + " requires updating.");
					logger.Error("You have: Rev{0}.{1}.{2}, however the core expects Rev{3}.{4}.{5}", dbVersion, dbStructure, dbContent, coreDbVersion, coreDbStructure, coreDbContent);
					logger.Error("The server is unable to run until the required updates are run");
					logger.Error("--------------------------------------------------------------");
					logger.Error("You must apply all updates after Rev{1}.{2}.{3} ", coreDbVersion, coreDbStructure, coreDbContent);
					logger.Error("These updates are included in the sql/updates folder.");
					logger.Error("--------------------------------------------------------------");
                    return false;
                }
            }
            else
            {
				logger.Debug("--------------------------------------------------------------");
				logger.Debug("The table `db_version` in database " + thisDatabase.SQLDBName + " is missing");
				logger.Debug("--------------------------------------------------------------");
				logger.Debug("MaNGOSVB cannot find the version info required, please update","hh:mm:ss");
				logger.Debug("your database to check that the db is up to date.",  "hh:mm:ss");
				logger.Debug("your database to Rev{0}.{1}.{2} ", coreDbVersion, coreDbStructure, coreDbContent);
                return false;
            }
        }
    }
}