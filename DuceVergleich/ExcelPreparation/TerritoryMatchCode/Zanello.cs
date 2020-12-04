using ExcelPreparation.TerritoryCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace zipcodeMatching
{
    public class Zanello
    {

        List<ZanelloAssociation> assoc { get; set; }
        MasterZipCodes masterZipCodes { get; set; }

        SmaAndSmd smaAndsmd { get; set; }

        string Incorrect { get; set; }
        string Correct { get; set; }
        public Zanello()
        {
            assoc = new List<ZanelloAssociation>();
            InitiAlizeZanelloAssoc();
            masterZipCodes = new MasterZipCodes();
            smaAndsmd = new SmaAndSmd();
        }

        class ZanelloAssociation
        {
            public ZanelloAssociation(int plz, string region, string sdi, string terr, string sma, string smd)
            {
                PLZ_CP = plz;
                Region = region;
                SDI = sdi;
                Territory = terr;
                SMA = sma;
                SMD = smd;
            }
            public int PLZ_CP { get; set; }
            public string Region { get; set; }
            public string SDI { get; set; }
            public string Territory { get; set; }
            public string SMA { get; set; }
            public string SMD { get; set; }

            public string matchPlz(int plz, string area, bool isCorrect)
            {
                if (!isCorrect)
                    return string.Format("for PLZ: {0}, area: {1} is not correct, expected area is: {2} for SMA: {3} and SM{4}\n", plz, area, Territory, SMA, SMD);
                else return string.Format("for PLZ: {0}, area:{1} is correct\n", plz, Territory);
            }
        }

        public string matchAllZipAgainstMaster()
        {
            StringBuilder total = new StringBuilder();
            foreach (var entry in assoc)
            {
                if (!masterZipCodes.IsZipContainedIn(entry.PLZ_CP, entry.Territory))
                {
                    string otherPlz = masterZipCodes.InWhichRegionIsZipContained(entry.PLZ_CP);
                    if (!string.IsNullOrEmpty(otherPlz))
                        if (otherPlz == entry.Territory)
                            total.Append(entry.matchPlz(entry.PLZ_CP, entry.Territory, true));
                        else
                            total.Append(entry.matchPlz(entry.PLZ_CP, otherPlz, false));


                }
            }
            return total.ToString();
        }

        public string SmaSmdOkAll()
        {
            List<string> errors = new List<string>();
            foreach (var entry in assoc)
            {
                // check sma
                if (!smaAndsmd.CheckIfConfigurationExists(entry.SMA, entry.Territory))
                {
                    string missingSMA = string.Format("SMA: {0} does not exist for Territory: {1}\n", entry.SMA, entry.Territory);
                    if (!errors.Contains(missingSMA))
                        errors.Add(string.Format("SMA: {0} does not exist for Territory: {1}\n", entry.SMA, entry.Territory));
                }
                // check smd
                if (!smaAndsmd.CheckIfConfigurationExists(entry.SMD, entry.Territory))
                {
                    string missingSMD = string.Format("SMD: {0} does not exist for Territory: {1}\n", entry.SMD, entry.Territory);
                    if (!errors.Contains(missingSMD))
                        errors.Add(string.Format("SMD: {0} does not exist for Territory: {1}\n", entry.SMD, entry.Territory));
                }
            }
            StringBuilder errorResult = new StringBuilder();
            foreach (var entry in errors)
                errorResult.Append(entry);

            return errorResult.ToString();
        }

        public void InitiAlizeZanelloAssoc()
        {
            assoc.Add(new ZanelloAssociation(1031, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1033, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1034, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1035, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1036, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1037, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1038, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1040, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1041, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1042, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1043, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1044, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1045, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1046, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1047, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1053, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1054, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1055, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1110, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1112, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1113, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1114, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1115, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1116, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1117, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1124, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1125, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1126, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1127, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1128, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1131, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1132, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1134, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1135, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1136, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1141, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1142, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1143, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1144, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1145, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1146, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1147, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1148, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1149, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1162, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1163, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1164, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1165, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1166, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1167, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1168, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1169, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1170, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1172, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1173, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1174, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1175, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1176, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1180, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1182, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1183, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1184, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1185, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1186, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1187, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1188, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1189, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1195, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1196, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1197, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1200, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1201, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1202, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1203, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1204, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1205, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1206, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1207, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1208, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1209, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1211, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1212, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1213, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1214, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1215, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1216, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1217, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1218, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1219, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1220, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1222, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1223, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1224, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1225, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1226, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1227, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1228, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1231, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1232, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1233, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1234, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1236, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1237, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1239, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1240, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1241, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1242, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1243, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1244, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1245, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1246, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1247, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1248, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1251, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1252, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1253, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1254, "7", "Patrick Zanello", "Region_7_05", "Patrick Zanello a.i.", "unknown"));
            assoc.Add(new ZanelloAssociation(1255, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1256, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1257, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1258, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1260, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1261, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1262, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1263, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1264, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1265, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1266, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1267, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1268, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1269, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1270, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1271, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1272, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1273, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1274, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1275, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1276, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1277, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1278, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1279, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1281, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1283, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1284, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1285, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1286, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1287, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1288, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1290, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1291, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1292, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1293, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1294, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1295, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1296, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1297, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1298, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1299, "7", "Patrick Zanello", "Region_7_03", "Julien Pala", "Laëtitia Rigolot"));
            assoc.Add(new ZanelloAssociation(1302, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1303, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1304, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1305, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1306, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1307, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1308, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1312, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1313, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1315, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1316, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1317, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1318, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1321, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1322, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1323, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1324, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1325, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1326, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1329, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1337, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1338, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1341, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1342, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1343, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1344, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1345, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1346, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1347, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1348, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1350, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1352, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1353, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1354, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1355, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1356, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1357, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1358, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1372, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1373, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1374, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1375, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1376, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1377, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1400, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1401, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1404, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1405, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1406, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1407, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1408, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1409, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1410, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1412, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1413, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1415, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1416, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1417, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1418, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1420, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1421, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1422, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1423, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1424, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1425, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1426, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1427, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1428, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1429, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1430, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1431, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1432, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1433, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1434, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1435, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1436, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1437, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1438, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1439, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1440, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1441, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1442, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1443, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1445, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1446, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1450, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1452, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1453, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1454, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1462, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1463, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1464, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(1468, "7", "Patrick Zanello", "Region_7_09", "Michael Ferreira Da Silva Costa", "unknown"));
            assoc.Add(new ZanelloAssociation(2000, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2001, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2012, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2013, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2014, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2015, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2016, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2017, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2019, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2022, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2023, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2024, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2025, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2027, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2028, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2034, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2035, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2036, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2037, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2042, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2043, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2046, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2052, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2053, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2054, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2056, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2057, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2058, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2063, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2064, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2065, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2067, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2068, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2072, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2073, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2074, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2075, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2087, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2088, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2103, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2105, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2108, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2112, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2113, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2114, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2115, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2116, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2117, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2123, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2124, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2126, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2127, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2149, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2203, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2206, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2207, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2208, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2222, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2300, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2301, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2314, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2316, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2318, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2322, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2325, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2333, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2336, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2338, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2340, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2345, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2350, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2353, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2354, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2360, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2362, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2363, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2364, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2400, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2405, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2406, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2414, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2416, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2520, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2523, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2525, "7", "Patrick Zanello", "Region_7_04", "Fabrice Flammini", "unknown"));
            assoc.Add(new ZanelloAssociation(2535, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2536, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2537, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2538, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2603, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2604, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2605, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2606, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2607, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2608, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2610, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2612, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2613, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2615, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2616, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2710, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2712, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2713, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2714, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2715, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2716, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2717, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2718, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2720, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2722, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2723, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2732, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2733, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2735, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2736, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2738, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2740, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2742, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2743, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2744, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2745, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2746, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2747, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2748, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2762, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2800, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2802, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2803, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2805, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2806, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2807, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2812, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2813, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2822, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2823, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2824, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2825, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2826, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2827, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2828, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2829, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2830, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2832, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2842, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2843, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2852, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2853, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2854, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2855, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2856, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2857, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2863, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2864, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2873, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2882, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2883, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2884, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2885, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2886, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2887, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2888, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2889, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2900, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2902, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2903, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2904, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2905, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2906, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2907, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2908, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2912, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2914, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2915, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2916, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2922, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2923, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2924, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2925, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2926, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2932, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2933, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2935, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2942, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2943, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2944, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2946, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2947, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2950, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2952, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2953, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(2954, "7", "Patrick Zanello", "Region_7_11", "Davy Mercier", "unknown"));
            assoc.Add(new ZanelloAssociation(1223, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1227, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1241, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1243, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1244, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1245, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1246, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1247, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1248, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1251, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1252, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1253, "unknown", "unknown", "unknown", "unknown", "unknown"));
            assoc.Add(new ZanelloAssociation(1254, "unknown", "unknown", "unknown", "unknown", "unknown"));

        }






        public void CheckIfZipCodesAreContained()
        {
            MasterZipCodes masterZipCodes = new MasterZipCodes();
            StringBuilder sb = new StringBuilder();
            foreach (var entry in zanelloPlz)
            {
                masterZipCodes.WhichZipIsContained(entry,"Zanello", sb);
            }
            Console.WriteLine(sb.ToString());
        }


        List<Int32> zanelloPlz = new List<Int32>
        {
            1031,
1033,
1034,
1035,
1036,
1037,
1038,
1040,
1041,
1042,
1043,
1044,
1045,
1046,
1047,
1053,
1054,
1055,
1110,
1112,
1113,
1114,
1115,
1116,
1117,
1124,
1125,
1126,
1127,
1128,
1131,
1132,
1134,
1135,
1136,
1141,
1142,
1143,
1144,
1145,
1146,
1147,
1148,
1149,
1162,
1163,
1164,
1165,
1166,
1167,
1168,
1169,
1170,
1172,
1173,
1174,
1175,
1176,
1180,
1182,
1183,
1184,
1185,
1186,
1187,
1188,
1189,
1195,
1196,
1197,
1200,
1201,
1202,
1203,
1204,
1205,
1206,
1207,
1208,
1209,
1211,
1212,
1213,
1214,
1215,
1216,
1217,
1218,
1219,
1220,
1222,
1223,
1224,
1225,
1226,
1227,
1228,
1231,
1232,
1233,
1234,
1236,
1237,
1239,
1240,
1241,
1242,
1243,
1244,
1245,
1246,
1247,
1248,
1251,
1252,
1253,
1254,
1255,
1256,
1257,
1258,
1260,
1261,
1262,
1263,
1264,
1265,
1266,
1267,
1268,
1269,
1270,
1271,
1272,
1273,
1274,
1275,
1276,
1277,
1278,
1279,
1281,
1283,
1284,
1285,
1286,
1287,
1288,
1290,
1291,
1292,
1293,
1294,
1295,
1296,
1297,
1298,
1299,
1302,
1303,
1304,
1305,
1306,
1307,
1308,
1312,
1313,
1315,
1316,
1317,
1318,
1321,
1322,
1323,
1324,
1325,
1326,
1329,
1337,
1338,
1341,
1342,
1343,
1344,
1345,
1346,
1347,
1348,
1350,
1352,
1353,
1354,
1355,
1356,
1357,
1358,
1372,
1373,
1374,
1375,
1376,
1377,
1400,
1401,
1404,
1405,
1406,
1407,
1408,
1409,
1410,
1412,
1413,
1415,
1416,
1417,
1418,
1420,
1421,
1422,
1423,
1424,
1425,
1426,
1427,
1428,
1429,
1430,
1431,
1432,
1433,
1434,
1435,
1436,
1437,
1438,
1439,
1440,
1441,
1442,
1443,
1445,
1446,
1450,
1452,
1453,
1454,
1462,
1463,
1464,
1468,
2000,
2001,
2012,
2013,
2014,
2015,
2016,
2017,
2019,
2022,
2023,
2024,
2025,
2027,
2028,
2034,
2035,
2036,
2037,
2042,
2043,
2046,
2052,
2053,
2054,
2056,
2057,
2058,
2063,
2064,
2065,
2067,
2068,
2072,
2073,
2074,
2075,
2087,
2088,
2103,
2105,
2108,
2112,
2113,
2114,
2115,
2116,
2117,
2123,
2124,
2126,
2127,
2149,
2203,
2206,
2207,
2208,
2222,
2300,
2301,
2314,
2316,
2318,
2322,
2325,
2333,
2336,
2338,
2340,
2345,
2350,
2353,
2354,
2360,
2362,
2363,
2364,
2400,
2405,
2406,
2414,
2416,
2520,
2523,
2525,
2535,
2536,
2537,
2538,
2603,
2604,
2605,
2606,
2607,
2608,
2610,
2612,
2613,
2615,
2616,
2710,
2712,
2713,
2714,
2715,
2716,
2717,
2718,
2720,
2722,
2723,
2732,
2733,
2735,
2736,
2738,
2740,
2742,
2743,
2744,
2745,
2746,
2747,
2748,
2762,
2800,
2802,
2803,
2805,
2806,
2807,
2812,
2813,
2822,
2823,
2824,
2825,
2826,
2827,
2828,
2829,
2830,
2832,
2842,
2843,
2852,
2853,
2854,
2855,
2856,
2857,
2863,
2864,
2873,
2882,
2883,
2884,
2885,
2886,
2887,
2888,
2889,
2900,
2902,
2903,
2904,
2905,
2906,
2907,
2908,
2912,
2914,
2915,
2916,
2922,
2923,
2924,
2925,
2926,
2932,
2933,
2935,
2942,
2943,
2944,
2946,
2947,
2950,
2952,
2953,
2954,
1223,
1227,
1241,
1243,
1244,
1245,
1246,
1247,
1248,
1251,
1252,
1253,
1254


        };
    }
}
