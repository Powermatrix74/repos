using ExcelPreparation.TerritoryCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace zipcodeMatching
{
    public class Aymon
    {
        List<AymonAssociation> assoc { get; set; }
        MasterZipCodes masterZipCodes { get; set; }
        SmaAndSmd smaAndsmd { get; set; }
        public Aymon()
        {
            InitializeAymonAssoc();
            masterZipCodes = new MasterZipCodes();
            smaAndsmd = new SmaAndSmd();
        }
        class AymonAssociation
        {
            public AymonAssociation(int plz, string region, string sdi, string terr, string sma, string smd)
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
                else return string.Format("for PLZ: {0}, area:{1} is correct\n",plz,Territory);
            }
        }

        public string matchZipCodesAgainstMaster()
        {
            StringBuilder total = new StringBuilder();
            foreach (var entry in assoc)
            {
                if (!masterZipCodes.IsZipContainedIn(entry.PLZ_CP, entry.Territory))
                {
                    string otherPlz = masterZipCodes.InWhichRegionIsZipContained(entry.PLZ_CP);
                    if (!string.IsNullOrEmpty(otherPlz))
                        if (otherPlz == entry.Territory)
                            total.Append(entry.matchPlz(entry.PLZ_CP, entry.Territory,true));
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

        public void InitializeAymonAssoc()
        {
            assoc = new List<AymonAssociation>();

            assoc.Add(new AymonAssociation(3960, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3961, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3963, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3965, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3966, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3967, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3968, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3971, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3972, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3973, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3974, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3975, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3976, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3977, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3978, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(3979, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1000, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1001, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1002, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1003, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1004, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1005, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1006, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1007, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1008, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1009, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1010, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1011, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1012, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1014, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1015, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1018, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1020, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1022, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1023, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1024, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1025, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1026, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1027, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1028, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1029, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1030, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1032, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1052, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1058, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1059, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1061, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1062, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1063, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1066, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1068, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1070, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1071, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1072, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1073, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1076, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1077, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1078, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1080, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1081, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1082, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1083, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1084, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1085, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1088, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1090, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1091, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1092, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1093, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1094, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1095, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1096, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1097, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1098, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1121, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1122, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1123, "4", "Sébastien Aymon", "Region_4_10", "Fabien Roman", "Antoine Favre"));
            assoc.Add(new AymonAssociation(1470, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1473, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1474, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1475, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1482, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1483, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1484, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1485, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1486, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1489, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1509, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1510, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1512, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1513, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1514, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1515, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1521, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1522, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1523, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1524, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1525, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1526, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1527, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1528, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1529, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1530, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1532, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1533, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1534, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1535, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1536, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1537, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1538, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1541, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1542, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1543, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1544, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1545, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1551, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1552, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1553, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1554, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1555, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1562, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1563, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1564, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1565, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1566, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1567, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1568, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1580, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1583, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1584, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1585, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1586, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1587, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1588, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1589, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1595, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1607, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1608, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1609, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1610, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1611, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1612, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1613, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1614, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1615, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1616, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1617, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1618, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1619, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1623, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1624, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1625, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1626, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1627, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1628, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1630, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1632, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1633, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1634, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1635, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1636, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1637, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1638, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1642, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1643, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1644, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1645, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1646, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1647, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1648, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1649, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1651, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1652, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1653, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1654, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1656, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1658, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1659, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1660, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1661, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1663, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1665, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1666, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1667, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1669, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1670, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1673, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1674, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1675, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1676, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1677, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1678, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1679, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1680, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1681, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1682, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1683, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1684, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1685, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1686, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1687, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1688, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1689, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1690, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1691, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1692, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1694, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1695, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1696, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1697, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1699, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1700, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1701, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1708, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1712, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1713, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1714, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1715, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1716, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1717, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1718, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1719, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1720, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1721, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1722, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1723, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1724, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1725, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1726, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1727, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1728, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1730, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1731, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1732, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1733, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1734, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1735, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1736, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1737, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1738, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1740, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1741, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1742, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1744, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1745, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1746, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1747, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1748, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1749, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1752, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1753, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1754, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1756, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1757, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1762, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1763, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1772, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1773, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1774, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1775, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1776, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1782, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1783, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1784, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1785, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1786, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1787, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1788, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1789, "4", "Sébastien Aymon", "Region_4_03", "Frédérick Oulevey", "Yves Chételat"));
            assoc.Add(new AymonAssociation(1791, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1792, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1793, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1794, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1795, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1796, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1797, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(1800, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1801, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1802, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1803, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1804, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1805, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1806, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1807, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1808, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1809, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1813, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1814, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1815, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1816, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1817, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1820, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1822, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1823, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1824, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1832, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1833, "4", "Sébastien Aymon", "Region_4_09", "Frédéric Monney", "Sébastien Joly"));
            assoc.Add(new AymonAssociation(1844, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1845, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1846, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1847, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1852, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1853, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1854, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1856, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1860, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1862, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1863, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1864, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1865, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1866, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1867, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1868, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1869, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1870, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1871, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1872, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1873, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1874, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1875, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1880, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1882, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1884, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1885, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1890, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1891, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1892, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1893, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1895, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1896, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1897, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1898, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1899, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1902, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1903, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1904, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1905, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1906, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1907, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1908, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1911, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1912, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1913, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1914, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1918, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1920, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1921, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1922, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1923, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1925, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1926, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1927, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1928, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1929, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1932, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1933, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1934, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1936, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1937, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1938, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1941, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1942, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1943, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1944, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1945, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1946, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1947, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1948, "4", "Sébastien Aymon", "Region_4_05", "Fabien Fournier", "Lionel Salzmann"));
            assoc.Add(new AymonAssociation(1950, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1951, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1955, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1957, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1958, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1961, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1962, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1963, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1964, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1965, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1966, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1967, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1968, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1969, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1971, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1972, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1973, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1974, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1975, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1976, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1977, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1978, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1981, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1982, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1983, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1984, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1985, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1986, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1987, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1988, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1991, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1992, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1993, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1994, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1996, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(1997, "4", "Sébastien Aymon", "Region_4_08", "Stéphane Délez", "Partizan Shala"));
            assoc.Add(new AymonAssociation(2500, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2501, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2502, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2503, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2504, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2505, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2512, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2513, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2514, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2515, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2516, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2517, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2518, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2532, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2533, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2534, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2542, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2543, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2552, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2553, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2554, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2555, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2556, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2557, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2558, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2560, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2562, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2563, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2564, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2565, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2572, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2575, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2576, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(2577, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3174, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3175, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3176, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3177, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3178, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3179, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3182, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3183, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3184, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3185, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3186, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3202, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3203, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3204, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3205, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3206, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3207, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3208, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3210, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3212, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3213, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3214, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3215, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3216, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3225, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3226, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3232, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3233, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3234, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3235, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3236, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3237, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3238, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3250, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3272, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3274, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3280, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3284, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3285, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
            assoc.Add(new AymonAssociation(3286, "4", "Sébastien Aymon", "Region_4_12", "Frédéric Oulevey a.i.", "Elias Zesiger"));
                                                                          
        }



        public void CheckIfZipsAreContained()
        {
            MasterZipCodes masterZipCodes = new MasterZipCodes();
            StringBuilder sb = new StringBuilder();
            foreach (var entry in AymonPlz)
            {
                masterZipCodes.WhichZipIsContained(entry,"Aymon", sb);
            }
            Console.WriteLine(sb.ToString());
        }


        

        List<Int32> AymonPlz = new List<Int32> 
        {
            1000,
            1001,
            1002,
            1003,
            1004,
            1005,
            1006,
            1007,
            1008,
            1009,
            1010,
            1011,
            1012,
            1014,
            1015,
            1018,
            1020,
            1022,
            1023,
            1024,
            1025,
            1026,
            1027,
            1028,
            1029,
            1030,
            1032,
            1052,
            1058,
            1059,
            1061,
            1062,
            1063,
            1066,
            1068,
            1070,
            1071,
            1072,
            1073,
            1076,
            1077,
            1078,
            1080,
            1081,
            1082,
            1083,
            1084,
            1085,
            1088,
            1090,
            1091,
            1092,
            1093,
            1094,
            1095,
            1096,
            1097,
            1098,
            1121,
            1122,
            1123,
            1470,
            1473,
            1474,
            1475,
            1482,
            1483,
            1484,
            1485,
            1486,
            1489,
            1509,
            1510,
            1512,
            1513,
            1514,
            1515,
            1521,
            1522,
            1523,
            1524,
            1525,
            1526,
            1527,
            1528,
            1529,
            1530,
            1532,
            1533,
            1534,
            1535,
            1536,
            1537,
            1538,
            1541,
            1542,
            1543,
            1544,
            1545,
            1551,
            1552,
            1553,
            1554,
            1555,
            1562,
            1563,
            1564,
            1565,
            1566,
            1567,
            1568,
            1580,
            1583,
            1584,
            1585,
            1586,
            1587,
            1588,
            1589,
            1595,
            1607,
            1608,
            1609,
            1610,
            1611,
            1612,
            1613,
            1614,
            1615,
            1616,
            1617,
            1618,
            1619,
            1623,
            1624,
            1625,
            1626,
            1627,
            1628,
            1630,
            1632,
            1633,
            1634,
            1635,
            1636,
            1637,
            1638,
            1642,
            1643,
            1644,
            1645,
            1646,
            1647,
            1648,
            1649,
            1651,
            1652,
            1653,
            1654,
            1656,
            1658,
            1659,
            1660,
            1661,
            1663,
            1665,
            1666,
            1667,
            1669,
            1670,
            1673,
            1674,
            1675,
            1676,
            1677,
            1678,
            1679,
            1680,
            1681,
            1682,
            1683,
            1684,
            1685,
            1686,
            1687,
            1688,
            1689,
            1690,
            1691,
            1692,
            1694,
            1695,
            1696,
            1697,
            1699,
            1700,
            1701,
            1708,
            1712,
            1713,
            1714,
            1715,
            1716,
            1717,
            1718,
            1719,
            1720,
            1721,
            1722,
            1723,
            1724,
            1725,
            1726,
            1727,
            1728,
            1730,
            1731,
            1732,
            1733,
            1734,
            1735,
            1736,
            1737,
            1738,
            1740,
            1741,
            1742,
            1744,
            1745,
            1746,
            1747,
            1748,
            1749,
            1752,
            1753,
            1754,
            1756,
            1757,
            1762,
            1763,
            1772,
            1773,
            1774,
            1775,
            1776,
            1782,
            1783,
            1784,
            1785,
            1786,
            1787,
            1788,
            1789,
            1791,
            1792,
            1793,
            1794,
            1795,
            1796,
            1797,
            1800,
            1801,
            1802,
            1803,
            1804,
            1805,
            1806,
            1807,
            1808,
            1809,
            1813,
            1814,
            1815,
            1816,
            1817,
            1820,
            1822,
            1823,
            1824,
            1832,
            1833,
            1844,
            1845,
            1846,
            1847,
            1852,
            1853,
            1854,
            1856,
            1860,
            1862,
            1863,
            1864,
            1865,
            1866,
            1867,
            1868,
            1869,
            1870,
            1871,
            1872,
            1873,
            1874,
            1875,
            1880,
            1882,
            1884,
            1885,
            1890,
            1891,
            1892,
            1893,
            1895,
            1896,
            1897,
            1898,
            1899,
            1902,
            1903,
            1904,
            1905,
            1906,
            1907,
            1908,
            1911,
            1912,
            1913,
            1914,
            1918,
            1920,
            1921,
            1922,
            1923,
            1925,
            1926,
            1927,
            1928,
            1929,
            1932,
            1933,
            1934,
            1936,
            1937,
            1938,
            1941,
            1942,
            1943,
            1944,
            1945,
            1946,
            1947,
            1948,
            1950,
            1951,
            1955,
            1957,
            1958,
            1961,
            1962,
            1963,
            1964,
            1965,
            1966,
            1967,
            1968,
            1969,
            1971,
            1972,
            1973,
            1974,
            1975,
            1976,
            1977,
            1978,
            1981,
            1982,
            1983,
            1984,
            1985,
            1986,
            1987,
            1988,
            1991,
            1992,
            1993,
            1994,
            1996,
            1997,
            2500,
            2501,
            2502,
            2503,
            2504,
            2505,
            2512,
            2513,
            2514,
            2515,
            2516,
            2517,
            2518,
            2532,
            2533,
            2534,
            2542,
            2543,
            2552,
            2553,
            2554,
            2555,
            2556,
            2557,
            2558,
            2560,
            2562,
            2563,
            2564,
            2565,
            2572,
            2575,
            2576,
            2577,
            3174,
            3175,
            3176,
            3177,
            3178,
            3179,
            3182,
            3183,
            3184,
            3185,
            3186,
            3202,
            3203,
            3204,
            3205,
            3206,
            3207,
            3208,
            3210,
            3212,
            3213,
            3214,
            3215,
            3216,
            3225,
            3226,
            3232,
            3233,
            3234,
            3235,
            3236,
            3237,
            3238,
            3250,
            3272,
            3274,
            3280,
            3284,
            3285,
            3286,
            3960,
            3961,
            3963,
            3965,
            3966,
            3967,
            3968,
            3971,
            3972,
            3973,
            3974,
            3975,
            3976,
            3977,
            3978,
            3979,
        };
    }
}
