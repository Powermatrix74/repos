using ExcelPreparation.TerritoryCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace zipcodeMatching
{
    public class VerrientiBertschinger
    {

        List<VerrientiBertschingerAssociation> assoc { get; set; }
        MasterZipCodes masterZipCodes { get; set; }
        SmaAndSmd smaAndsmd { get; set; }
        string Incorrect { get; set; }
        string Correct { get; set; }
        public VerrientiBertschinger()
        {
            assoc = new List<VerrientiBertschingerAssociation>();
            InitiAlizeVerrientiBertschingerAssoc();
            masterZipCodes = new MasterZipCodes();
            smaAndsmd = new SmaAndSmd();
        }

        class VerrientiBertschingerAssociation
        {
            public VerrientiBertschingerAssociation(int plz, string region, string sdi, string terr, string sma, string smd)
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

        public void InitiAlizeVerrientiBertschingerAssoc()
        {
            assoc.Add(new VerrientiBertschingerAssociation(5105, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5106, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5107, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5108, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5112, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5116, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5200, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5201, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5210, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5212, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5213, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5222, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5223, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5225, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5232, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5233, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5234, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5235, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5236, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5237, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5242, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5243, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5244, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5245, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5246, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5300, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5301, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5303, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5304, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5305, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5306, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5312, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5313, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5314, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5315, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5316, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5317, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5318, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5322, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5323, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5324, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5325, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5326, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5330, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5332, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5333, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5334, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5400, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5401, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5404, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5405, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5406, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5408, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5412, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5413, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5415, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5416, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5417, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5420, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5423, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5425, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5426, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5430, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5432, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5436, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5442, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5443, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5444, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5445, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5452, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5453, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5454, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5462, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5463, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5464, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5465, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5466, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5467, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5507, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5512, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5522, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5524, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5525, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5605, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5606, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5607, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5608, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(5610, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5611, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5612, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5613, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5614, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5618, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5619, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5620, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5621, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5622, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5623, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5624, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5625, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5626, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5627, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5628, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5630, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5632, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5634, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5636, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5637, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5642, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5643, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5644, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5645, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5646, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(5647, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6000, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6002, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6003, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6004, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6005, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6006, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6010, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6012, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6013, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6014, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6015, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6020, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6021, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6023, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6026, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6027, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6028, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6030, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6032, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6033, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6034, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6035, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6036, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6037, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6038, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6039, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6042, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6043, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6044, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6045, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6047, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6048, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6052, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6053, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6055, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6056, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6060, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6061, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6062, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6063, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6064, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6066, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6067, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6068, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6072, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6073, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6074, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6078, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6102, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6103, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6274, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6275, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6276, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6277, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6280, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6281, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6283, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6284, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6285, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6286, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6287, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6288, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6289, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6294, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6295, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(6300, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(6301, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(6302, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(6304, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(6312, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6313, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6314, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6315, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6317, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6318, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6319, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6330, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6331, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6332, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6333, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6340, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6341, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6343, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6344, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6345, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(6353, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6354, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6356, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6362, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6363, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6365, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6370, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6371, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6372, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6373, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6374, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6375, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6376, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6377, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6382, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6383, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6386, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6387, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6388, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6390, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6391, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6402, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6403, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6404, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6405, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6410, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6414, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6415, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6416, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6417, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6418, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6422, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6423, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6424, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6430, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6431, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6432, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6433, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6434, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6436, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6438, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6440, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6441, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6442, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6443, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6452, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6454, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6460, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6461, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6462, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6463, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6464, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6465, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6466, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6467, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6468, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6469, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6472, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6473, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6474, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6475, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6476, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6482, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6484, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6485, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6487, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6490, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6491, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6493, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(6500, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6501, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6503, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6512, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6513, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6514, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6515, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6516, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6517, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6518, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6523, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6524, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6525, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6526, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6527, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6528, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6532, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6533, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6534, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6535, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6537, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6538, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6540, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6541, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6542, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6543, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6544, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6545, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6546, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6548, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6549, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6556, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6557, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6558, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6562, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6563, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6565, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6571, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6572, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6573, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6574, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6575, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6576, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6577, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6578, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6579, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6582, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6583, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6584, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6592, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6593, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6594, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6595, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6596, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6597, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6598, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6599, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6600, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6601, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6604, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6605, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6611, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6612, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6613, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6614, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6616, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6618, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6622, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6631, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6632, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6633, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6634, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6635, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6636, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6637, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6644, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6645, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6646, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6647, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6648, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6652, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6653, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6654, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6655, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6656, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6657, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6658, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6659, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6661, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6662, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6663, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6664, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6670, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6672, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6673, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6674, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6675, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6676, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6677, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6678, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6682, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6683, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6684, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6685, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6690, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6692, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6693, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6694, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6695, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6696, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6702, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6703, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6705, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6707, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6710, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6713, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6714, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6715, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6716, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6717, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6718, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6719, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6720, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6721, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6722, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6723, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6724, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6742, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6743, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6744, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6745, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6746, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6747, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6748, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6749, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6760, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6763, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6764, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6772, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6773, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6774, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6775, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6776, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6777, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6780, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6781, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6802, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6803, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6804, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6805, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6806, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6807, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6808, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6809, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6810, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6814, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6815, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6816, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6817, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6818, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6821, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6822, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6823, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6825, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6826, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6827, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6828, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6830, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6832, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6833, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6834, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6835, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6836, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6837, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6838, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6839, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6850, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6852, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6853, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6854, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6855, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6862, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6863, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6864, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6865, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6866, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6867, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6872, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6873, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6874, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6875, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6877, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6883, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6900, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6901, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6902, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6903, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6904, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6908, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(6911, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6912, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6913, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6914, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6915, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6916, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6917, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6918, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6919, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6921, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6922, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6924, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6925, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6926, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6927, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6928, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6929, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6930, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6932, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6933, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6934, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6935, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6936, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6937, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6938, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6939, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6942, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6943, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6944, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6945, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6946, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6947, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6948, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6949, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6950, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6951, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6952, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6953, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6954, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6955, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6956, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6957, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6958, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6959, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6960, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6962, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6963, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6964, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6965, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6966, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6967, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6968, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6974, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6976, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6977, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6978, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6979, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6980, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6981, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6982, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6983, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6984, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6986, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6987, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6988, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6989, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6990, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6991, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6992, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6993, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6994, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6995, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6997, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6998, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(6999, "2", "Francesco Verrienti", "Region_2_06", "Virgilio Ferraro", "Giuseppe Gulino"));
            assoc.Add(new VerrientiBertschingerAssociation(7000, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7001, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7004, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7006, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7007, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7012, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7013, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7014, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7015, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7016, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7017, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7018, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7019, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7023, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7026, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7027, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7028, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7029, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7031, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7032, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7050, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7056, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7057, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7058, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7062, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7063, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7064, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7074, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7075, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7076, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7077, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7078, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7082, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7083, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7084, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7104, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7106, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7107, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7109, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7110, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7111, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7112, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7113, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7114, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7115, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7122, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7126, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7127, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7128, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7130, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7132, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7134, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7137, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7138, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7141, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7142, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7143, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7144, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7145, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7146, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7147, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7148, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7149, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7151, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7152, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7153, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7154, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7155, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7156, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7157, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7158, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7159, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7162, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7163, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7164, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7165, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7166, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7167, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7168, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7172, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7173, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7174, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7175, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7176, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7180, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7183, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7184, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7185, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7186, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7187, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7188, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7189, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7202, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7203, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7204, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7205, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7206, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7208, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7212, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7213, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7214, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7215, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7220, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7222, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7223, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7224, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7226, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7228, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7231, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7232, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7233, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7235, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7240, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7241, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7242, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7243, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7244, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7245, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7246, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7247, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7249, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7250, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7252, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7260, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7265, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7270, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7272, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7276, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7277, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7278, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7302, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7303, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7304, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7306, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7307, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7310, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7312, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7313, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7314, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7315, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7317, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7320, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7323, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7324, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7325, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7326, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7400, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7402, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7403, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7404, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7405, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7407, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7408, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7411, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7412, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7413, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7414, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7415, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7416, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7417, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7418, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7419, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7421, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7422, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7423, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7424, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7425, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7426, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7427, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7428, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7430, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7431, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7432, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7433, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7434, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7435, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7436, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7437, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7438, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7440, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7442, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7443, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7444, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7445, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7446, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7447, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7448, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7450, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7451, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7452, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7453, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7454, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7455, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7456, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7457, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7458, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7459, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7460, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7462, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7463, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7464, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7472, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7473, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7477, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7482, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7484, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7492, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7493, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7494, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7500, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7502, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7503, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7504, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7505, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7512, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7513, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7514, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7515, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7516, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7517, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7522, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7523, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7524, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7525, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7526, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7527, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7530, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7532, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7533, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7534, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7535, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7536, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7537, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7542, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7543, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7545, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7546, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7550, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7551, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7552, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7553, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7554, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7556, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7557, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7558, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7559, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7560, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7562, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7563, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(7602, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7603, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7604, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7605, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7606, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7608, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7610, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7710, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7741, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7742, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7743, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7744, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7745, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7746, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7747, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(7748, "2", "Francesco Verrienti", "Region_2_03", "Marco Tarzi", "Luca Gaglione"));
            assoc.Add(new VerrientiBertschingerAssociation(8000, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8001, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8002, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8003, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8004, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8005, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8006, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8008, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8010, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8012, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8021, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8022, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8024, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8027, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8031, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8032, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8036, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8037, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8038, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8040, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8041, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8042, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8044, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8045, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8046, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8047, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8048, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8049, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8050, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8051, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8052, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8053, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8055, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8057, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8058, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8060, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8064, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8070, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8087, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8090, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8091, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8092, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8098, "2", "Francesco Verrienti", "Region_2_01", "Serbay Birinci", "David Krecar"));
            assoc.Add(new VerrientiBertschingerAssociation(8102, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8103, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8104, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8105, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8106, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8107, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8108, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8109, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8112, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8113, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8114, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8115, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8117, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8118, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8121, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8122, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8123, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8124, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8125, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8126, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8127, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8132, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8133, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8134, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8135, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8136, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8142, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8143, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8152, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8153, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8154, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8155, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8156, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8157, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8158, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8162, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8164, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8165, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8166, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8172, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8173, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8174, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8175, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8180, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8181, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8182, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8184, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8185, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8187, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8192, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8193, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8194, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8195, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8196, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8197, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8200, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8201, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8203, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8207, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8208, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8212, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8213, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8214, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8215, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8216, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8217, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8218, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8219, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8222, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8223, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8224, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8225, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8226, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8228, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8231, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8232, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8233, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8234, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8235, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8236, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8238, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8239, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8240, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8241, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8242, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8243, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8245, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8246, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8247, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8248, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8252, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8253, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8254, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8255, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8259, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8260, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8261, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8262, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8263, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8264, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8265, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8266, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8267, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8268, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8269, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8272, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8273, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8274, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8280, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8301, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8302, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8303, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8304, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8305, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8306, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8307, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8308, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8309, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8310, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8311, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8312, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8314, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8315, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8317, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8320, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8322, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8330, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8331, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8332, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8335, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8340, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8342, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8344, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8345, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8352, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8353, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8354, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8355, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8356, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8357, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8360, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8362, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8363, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8370, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8371, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8372, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8374, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8376, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8400, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8401, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8404, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8405, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8406, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8408, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8409, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8412, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8413, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8414, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8415, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8416, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8418, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8421, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8422, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8424, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8425, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8426, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8427, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8428, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8442, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8444, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8447, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8450, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8451, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8452, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8453, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8454, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8455, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8457, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8458, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8459, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8460, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8461, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8462, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8463, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8464, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8465, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8466, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8467, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8468, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8471, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8472, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8474, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8475, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8476, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8477, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8478, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8479, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8482, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8483, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8484, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8486, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8487, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8488, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8489, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8492, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8493, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8494, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8495, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8496, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8497, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8498, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8499, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8500, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8501, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8505, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8506, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8507, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8508, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8509, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8510, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8512, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8514, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8522, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8523, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8524, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8525, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8526, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8532, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8535, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8536, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8537, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8542, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8543, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8544, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8545, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8546, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8547, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8548, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8552, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8553, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8554, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8555, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8556, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8558, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8560, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8561, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8564, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8565, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8566, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8570, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8572, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8573, "6", "Daniel Bertschinger", "Region_6_06", "André Moes", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8574, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8575, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8576, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8577, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8580, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8581, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8582, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8583, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8584, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8585, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8586, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8587, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8588, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8589, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8590, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8592, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8593, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8594, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8595, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8596, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8597, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8598, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8599, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8600, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8602, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8603, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8604, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8605, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8606, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8607, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8608, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8610, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8613, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8614, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8615, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8616, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8617, "6", "Daniel Bertschinger", "Region_6_01", "Sandro Montuori a.i.", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8618, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8620, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8623, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8624, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8625, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8626, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8627, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8630, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8632, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8633, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8634, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8635, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8636, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8637, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8638, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8640, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8645, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8646, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8700, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8702, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8703, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8704, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8706, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8707, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8708, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8712, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8713, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8714, "2", "Francesco Verrienti", "Region_2_05", "Michele Iosca", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8715, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8716, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8717, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8718, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8722, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8723, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8725, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8726, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(8727, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8730, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8732, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8733, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8734, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8735, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8737, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8738, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8739, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8750, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8751, "2", "Francesco Verrienti", "Region_2_14", "Marcos Romero", "Sandro Hegeri"));
            assoc.Add(new VerrientiBertschingerAssociation(8752, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8753, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8754, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8755, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8756, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8757, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8758, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8762, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8765, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8766, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8767, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8772, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8773, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8774, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8775, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8777, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8782, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8783, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8784, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8800, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8802, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8803, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8804, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8805, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8806, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8807, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8808, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8810, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8815, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8816, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8820, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8824, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8825, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8832, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8833, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8834, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8835, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8836, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8840, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8841, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8842, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8843, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8844, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8845, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8846, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8847, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8849, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8852, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8853, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8854, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8855, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8856, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8857, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8858, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8862, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8863, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8864, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8865, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8866, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8867, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8868, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8872, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8873, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8874, "6", "Daniel Bertschinger", "Region_6_10", "Irena Pavlovic", "Nicole Nussbaumer"));
            assoc.Add(new VerrientiBertschingerAssociation(8877, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8878, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8880, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8881, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8882, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8883, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8884, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8885, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8886, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8887, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8888, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8889, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8890, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8892, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8893, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8894, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8895, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8896, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8897, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8898, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8902, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8903, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8904, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8905, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8906, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8907, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8908, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8909, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8910, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8911, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8912, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8913, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8914, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8915, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8916, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8917, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8918, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8919, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8925, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8926, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8932, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8933, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8934, "2", "Francesco Verrienti", "Region_2_15", "Dursun Birinci", "Oktar Gar"));
            assoc.Add(new VerrientiBertschingerAssociation(8942, "2", "Francesco Verrienti", "Region_2_07", "Alban Shkodra", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8951, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8952, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8953, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8954, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8955, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8956, "6", "Daniel Bertschinger", "Region_6_08", "Sandro Montuori", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(8957, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8962, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8964, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8965, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8966, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(8967, "6", "Daniel Bertschinger", "Region_6_05", "Rossano Verrienti", "Robert Nikolovski"));
            assoc.Add(new VerrientiBertschingerAssociation(9000, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9001, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9004, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9006, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9008, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9010, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9011, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9012, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9014, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9015, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9016, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9030, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9032, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9033, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9034, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9035, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9036, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9037, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9038, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9042, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9043, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9044, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9050, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9052, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9053, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9054, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9055, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9056, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9057, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9058, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9062, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9063, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9064, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9100, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9102, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9103, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9104, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9105, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9107, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9108, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9112, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9113, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9114, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9115, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9116, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9122, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9123, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9125, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9126, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9127, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9200, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9201, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9203, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9204, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9205, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9212, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9213, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9214, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9215, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9216, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9217, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9220, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9223, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9225, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9230, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9231, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9240, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9242, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9243, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9244, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9245, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9246, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9247, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9248, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9249, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9300, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9301, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9304, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9305, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9306, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9308, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9312, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9313, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9314, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9315, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9320, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9322, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9323, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9325, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9326, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9327, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9400, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9401, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9402, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9403, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9404, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9405, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9410, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9411, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9413, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9422, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9423, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9424, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9425, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9426, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9427, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9428, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9430, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9434, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9435, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9436, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9437, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9442, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9443, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9444, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9445, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9450, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9451, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9452, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9453, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9454, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9462, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9463, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9464, "6", "Daniel Bertschinger", "Region_6_07", "Irena Pavlovic", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9465, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9466, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9467, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9468, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9469, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9470, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9472, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9473, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9475, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9476, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9477, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9478, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9479, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9485, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9486, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9487, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9488, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9490, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9491, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9492, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9493, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9494, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9495, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9496, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9497, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9498, "2", "Francesco Verrienti", "Region_2_04", "Andreas Noll", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9500, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9501, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9502, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9503, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9504, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9506, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9507, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9508, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9512, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9514, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9515, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9517, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9523, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9524, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9525, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9526, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9527, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9532, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9533, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9534, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9535, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9536, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9542, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9543, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9545, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9546, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9547, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9548, "6", "Daniel Bertschinger", "Region_6_03", "Carmen Steger", "unknown"));
            assoc.Add(new VerrientiBertschingerAssociation(9552, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9553, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9554, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9555, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9556, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9562, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9565, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9573, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9601, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9602, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9604, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9606, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9607, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9608, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9612, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9613, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9614, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9615, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9620, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9621, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9622, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9630, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9631, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9633, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9642, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9643, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9650, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9651, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9652, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9655, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9656, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9657, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));
            assoc.Add(new VerrientiBertschingerAssociation(9658, "6", "Daniel Bertschinger", "Region_6_14", "Angelo Calado Mercuri", "Vito Modoni"));

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
                            total.Append(entry.matchPlz(entry.PLZ_CP, entry.Territory, true));
                        else
                            total.Append(entry.matchPlz(entry.PLZ_CP, otherPlz, false));


                }
            }
            return total.ToString();
        }






        public void CheckIfZipsAreContained()
        {
            MasterZipCodes masterZipCodes = new MasterZipCodes();
            StringBuilder sb = new StringBuilder();
            foreach (var entry in VerrientiBertschingerPlz)
            {
                masterZipCodes.WhichZipIsContained(entry,"VerrientiAndBertschinger", sb);
            }
            Console.WriteLine(sb.ToString());
        }


        List<Int32> VerrientiBertschingerPlz = new List<Int32>
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
1031,
1032,
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
1052,
1053,
1054,
1055,
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
1110,
1112,
1113,
1114,
1115,
1116,
1117,
1121,
1122,
1123,
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
1657,
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
2520,
2523,
2525,
2532,
2533,
2534,
2535,
2536,
2537,
2538,
2540,
2542,
2543,
2544,
2545,
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
2814,
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
3000,
3001,
3002,
3003,
3004,
3005,
3006,
3007,
3008,
3010,
3011,
3012,
3013,
3014,
3015,
3018,
3019,
3020,
3027,
3030,
3032,
3033,
3034,
3035,
3036,
3037,
3038,
3042,
3043,
3044,
3045,
3046,
3047,
3048,
3049,
3050,
3052,
3053,
3054,
3063,
3065,
3066,
3067,
3068,
3072,
3073,
3074,
3075,
3076,
3077,
3078,
3082,
3083,
3084,
3086,
3087,
3088,
3089,
3095,
3096,
3097,
3098,
3099,
3110,
3111,
3112,
3113,
3114,
3115,
3116,
3122,
3123,
3124,
3125,
3126,
3127,
3128,
3132,
3144,
3145,
3147,
3148,
3150,
3152,
3153,
3154,
3155,
3156,
3157,
3158,
3159,
3172,
3173,
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
3251,
3252,
3253,
3254,
3255,
3256,
3257,
3262,
3263,
3264,
3266,
3267,
3268,
3270,
3271,
3272,
3273,
3274,
3280,
3282,
3283,
3284,
3285,
3286,
3292,
3293,
3294,
3295,
3296,
3297,
3298,
3302,
3303,
3305,
3306,
3307,
3308,
3309,
3312,
3313,
3314,
3315,
3317,
3321,
3322,
3323,
3324,
3325,
3326,
3360,
3362,
3363,
3365,
3366,
3367,
3368,
3372,
3373,
3374,
3375,
3376,
3377,
3380,
3400,
3401,
3412,
3413,
3414,
3415,
3416,
3417,
3418,
3419,
3421,
3422,
3423,
3424,
3425,
3426,
3427,
3428,
3429,
3432,
3433,
3434,
3435,
3436,
3437,
3438,
3439,
3452,
3453,
3454,
3455,
3456,
3457,
3462,
3463,
3464,
3465,
3472,
3473,
3474,
3475,
3476,
3503,
3504,
3506,
3507,
3508,
3510,
3512,
3513,
3531,
3532,
3533,
3534,
3535,
3536,
3537,
3538,
3543,
3550,
3551,
3552,
3553,
3555,
3556,
3557,
3600,
3602,
3603,
3604,
3608,
3612,
3613,
3614,
3615,
3616,
3617,
3618,
3619,
3622,
3623,
3624,
3625,
3626,
3627,
3628,
3629,
3631,
3632,
3633,
3634,
3635,
3636,
3638,
3645,
3646,
3647,
3652,
3653,
3654,
3655,
3656,
3657,
3658,
3661,
3662,
3663,
3664,
3665,
3671,
3672,
3673,
3674,
3700,
3702,
3703,
3704,
3705,
3706,
3707,
3711,
3713,
3714,
3715,
3716,
3717,
3718,
3722,
3723,
3724,
3725,
3752,
3753,
3754,
3755,
3756,
3757,
3758,
3762,
3763,
3764,
3765,
3766,
3770,
3771,
3772,
3773,
3775,
3776,
3777,
3778,
3780,
3781,
3782,
3783,
3784,
3785,
3792,
3800,
3801,
3803,
3804,
3805,
3806,
3807,
3812,
3813,
3814,
3815,
3816,
3818,
3822,
3823,
3824,
3825,
3826,
3852,
3853,
3854,
3855,
3856,
3857,
3858,
3860,
3862,
3863,
3864,
3900,
3901,
3902,
3903,
3904,
3905,
3906,
3907,
3908,
3909,
3910,
3911,
3912,
3913,
3914,
3916,
3917,
3918,
3919,
3920,
3922,
3923,
3924,
3925,
3926,
3927,
3928,
3929,
3930,
3931,
3932,
3933,
3934,
3935,
3937,
3938,
3939,
3940,
3942,
3943,
3944,
3945,
3946,
3947,
3948,
3949,
3951,
3952,
3953,
3954,
3955,
3956,
3957,
3960,
3961,
3963,
3965,
3966,
3967,
3968,
3969,
3970,
3971,
3972,
3973,
3974,
3975,
3976,
3977,
3978,
3979,
3982,
3983,
3984,
3985,
3986,
3987,
3988,
3989,
3991,
3992,
3993,
3994,
3995,
3996,
3997,
3998,
3999,
4000,
4001,
4002,
4005,
4009,
4010,
4018,
4019,
4020,
4030,
4031,
4051,
4052,
4053,
4054,
4055,
4056,
4057,
4058,
4059,
4070,
4101,
4102,
4103,
4104,
4105,
4106,
4107,
4108,
4112,
4114,
4115,
4116,
4117,
4118,
4123,
4124,
4125,
4126,
4127,
4132,
4133,
4142,
4143,
4144,
4145,
4146,
4147,
4148,
4153,
4202,
4203,
4204,
4206,
4207,
4208,
4222,
4223,
4224,
4225,
4226,
4227,
4228,
4229,
4232,
4233,
4234,
4242,
4243,
4244,
4245,
4246,
4247,
4252,
4253,
4254,
4302,
4303,
4304,
4305,
4310,
4312,
4313,
4314,
4315,
4316,
4317,
4322,
4323,
4324,
4325,
4332,
4333,
4334,
4402,
4410,
4411,
4412,
4413,
4414,
4415,
4416,
4417,
4418,
4419,
4421,
4422,
4423,
4424,
4425,
4426,
4431,
4432,
4433,
4434,
4435,
4436,
4437,
4438,
4441,
4442,
4443,
4444,
4445,
4446,
4447,
4448,
4450,
4451,
4452,
4453,
4455,
4456,
4457,
4458,
4460,
4461,
4462,
4463,
4464,
4465,
4466,
4467,
4468,
4469,
4492,
4493,
4494,
4495,
4496,
4497,
4500,
4502,
4503,
4512,
4513,
4514,
4515,
4522,
4523,
4524,
4525,
4528,
4532,
4533,
4534,
4535,
4536,
4537,
4538,
4539,
4542,
4543,
4552,
4553,
4554,
4556,
4557,
4558,
4562,
4563,
4564,
4565,
4566,
4571,
4573,
4574,
4576,
4577,
4578,
4579,
4581,
4582,
4583,
4584,
4585,
4586,
4587,
4588,
4600,
4612,
4613,
4614,
4615,
4616,
4617,
4618,
4622,
4623,
4624,
4625,
4626,
4628,
4629,
4632,
4633,
4634,
4652,
4653,
4654,
4655,
4656,
4657,
4658,
4663,
4665,
4702,
4703,
4704,
4710,
4712,
4713,
4714,
4715,
4716,
4717,
4718,
4719,
4800,
4802,
4803,
4805,
4806,
4812,
4813,
4814,
4852,
4853,
4856,
4900,
4901,
4911,
4912,
4913,
4914,
4915,
4916,
4917,
4919,
4922,
4923,
4924,
4932,
4933,
4934,
4935,
4936,
4937,
4938,
4942,
4943,
4944,
4950,
4952,
4953,
4954,
4955,
5000,
5001,
5004,
5012,
5013,
5014,
5015,
5017,
5018,
5022,
5023,
5024,
5025,
5026,
5027,
5028,
5032,
5033,
5034,
5035,
5036,
5037,
5040,
5042,
5043,
5044,
5046,
5053,
5054,
5056,
5057,
5058,
5062,
5063,
5064,
5070,
5072,
5073,
5074,
5075,
5076,
5077,
5078,
5079,
5080,
5082,
5083,
5084,
5085,
5102,
5103,
5105,
5106,
5107,
5108,
5112,
5113,
5116,
5200,
5201,
5210,
5212,
5213,
5222,
5223,
5225,
5232,
5233,
5234,
5235,
5236,
5237,
5242,
5243,
5244,
5245,
5246,
5272,
5273,
5274,
5275,
5276,
5277,
5300,
5301,
5303,
5304,
5305,
5306,
5312,
5313,
5314,
5315,
5316,
5317,
5318,
5322,
5323,
5324,
5325,
5326,
5330,
5332,
5333,
5334,
5400,
5401,
5404,
5405,
5406,
5408,
5412,
5413,
5415,
5416,
5417,
5420,
5423,
5425,
5426,
5430,
5432,
5436,
5442,
5443,
5444,
5445,
5452,
5453,
5454,
5462,
5463,
5464,
5465,
5466,
5467,
5502,
5503,
5504,
5505,
5506,
5507,
5512,
5522,
5524,
5525,
5600,
5603,
5604,
5605,
5606,
5607,
5608,
5610,
5611,
5612,
5613,
5614,
5615,
5616,
5617,
5618,
5619,
5620,
5621,
5622,
5623,
5624,
5625,
5626,
5627,
5628,
5630,
5632,
5634,
5636,
5637,
5642,
5643,
5644,
5645,
5646,
5647,
5702,
5703,
5704,
5705,
5706,
5707,
5708,
5712,
5722,
5723,
5724,
5725,
5726,
5727,
5728,
5732,
5733,
5734,
5735,
5736,
5737,
5742,
5745,
5746,
5906,
6000,
6002,
6003,
6004,
6005,
6006,
6010,
6012,
6013,
6014,
6015,
6016,
6017,
6018,
6019,
6020,
6021,
6022,
6023,
6024,
6025,
6026,
6027,
6028,
6030,
6032,
6033,
6034,
6035,
6036,
6037,
6038,
6039,
6042,
6043,
6044,
6045,
6047,
6048,
6052,
6053,
6055,
6056,
6060,
6061,
6062,
6063,
6064,
6066,
6067,
6068,
6072,
6073,
6074,
6078,
6083,
6084,
6085,
6086,
6102,
6103,
6105,
6106,
6110,
6112,
6113,
6114,
6122,
6123,
6125,
6126,
6130,
6132,
6133,
6142,
6143,
6144,
6145,
6146,
6147,
6152,
6153,
6154,
6156,
6160,
6162,
6163,
6166,
6167,
6170,
6173,
6174,
6182,
6192,
6196,
6197,
6203,
6204,
6205,
6206,
6207,
6208,
6210,
6211,
6212,
6213,
6214,
6215,
6216,
6217,
6218,
6221,
6222,
6231,
6232,
6233,
6234,
6235,
6236,
6242,
6243,
6244,
6245,
6246,
6247,
6248,
6252,
6253,
6260,
6262,
6263,
6264,
6265,
6274,
6275,
6276,
6277,
6280,
6281,
6283,
6284,
6285,
6286,
6287,
6288,
6289,
6294,
6295,
6300,
6301,
6302,
6304,
6312,
6313,
6314,
6315,
6317,
6318,
6319,
6330,
6331,
6332,
6333,
6340,
6341,
6343,
6344,
6345,
6353,
6354,
6356,
6362,
6363,
6365,
6370,
6371,
6372,
6373,
6374,
6375,
6376,
6377,
6382,
6383,
6386,
6387,
6388,
6390,
6391,
6402,
6403,
6404,
6405,
6410,
6414,
6415,
6416,
6417,
6418,
6422,
6423,
6424,
6430,
6431,
6432,
6433,
6434,
6436,
6438,
6440,
6441,
6442,
6443,
6452,
6454,
6460,
6461,
6462,
6463,
6464,
6465,
6466,
6467,
6468,
6469,
6472,
6473,
6474,
6475,
6476,
6482,
6484,
6485,
6487,
6490,
6491,
6493,
6500,
6501,
6503,
6512,
6513,
6514,
6515,
6516,
6517,
6518,
6523,
6524,
6525,
6526,
6527,
6528,
6532,
6533,
6534,
6535,
6537,
6538,
6540,
6541,
6542,
6543,
6544,
6545,
6546,
6548,
6549,
6556,
6557,
6558,
6562,
6563,
6565,
6571,
6572,
6573,
6574,
6575,
6576,
6577,
6578,
6579,
6582,
6583,
6584,
6592,
6593,
6594,
6595,
6596,
6597,
6598,
6599,
6600,
6601,
6604,
6605,
6611,
6612,
6613,
6614,
6616,
6618,
6622,
6631,
6632,
6633,
6634,
6635,
6636,
6637,
6644,
6645,
6646,
6647,
6648,
6652,
6653,
6654,
6655,
6656,
6657,
6658,
6659,
6661,
6662,
6663,
6664,
6670,
6672,
6673,
6674,
6675,
6676,
6677,
6678,
6682,
6683,
6684,
6685,
6690,
6692,
6693,
6694,
6695,
6696,
6702,
6703,
6705,
6707,
6710,
6713,
6714,
6715,
6716,
6717,
6718,
6719,
6720,
6721,
6722,
6723,
6724,
6742,
6743,
6744,
6745,
6746,
6747,
6748,
6749,
6760,
6763,
6764,
6772,
6773,
6774,
6775,
6776,
6777,
6780,
6781,
6802,
6803,
6804,
6805,
6806,
6807,
6808,
6809,
6810,
6814,
6815,
6816,
6817,
6818,
6821,
6822,
6823,
6825,
6826,
6827,
6828,
6830,
6832,
6833,
6834,
6835,
6836,
6837,
6838,
6839,
6850,
6852,
6853,
6854,
6855,
6862,
6863,
6864,
6865,
6866,
6867,
6872,
6873,
6874,
6875,
6877,
6883,
6900,
6901,
6902,
6903,
6904,
6908,
6911,
6912,
6913,
6914,
6915,
6916,
6917,
6918,
6919,
6921,
6922,
6924,
6925,
6926,
6927,
6928,
6929,
6930,
6932,
6933,
6934,
6935,
6936,
6937,
6938,
6939,
6942,
6943,
6944,
6945,
6946,
6947,
6948,
6949,
6950,
6951,
6952,
6953,
6954,
6955,
6956,
6957,
6958,
6959,
6960,
6962,
6963,
6964,
6965,
6966,
6967,
6968,
6974,
6976,
6977,
6978,
6979,
6980,
6981,
6982,
6983,
6984,
6986,
6987,
6988,
6989,
6990,
6991,
6992,
6993,
6994,
6995,
6997,
6998,
6999,
7000,
7001,
7004,
7006,
7007,
7012,
7013,
7014,
7015,
7016,
7017,
7018,
7019,
7023,
7026,
7027,
7028,
7029,
7031,
7032,
7050,
7056,
7057,
7058,
7062,
7063,
7064,
7074,
7075,
7076,
7077,
7078,
7082,
7083,
7084,
7104,
7106,
7107,
7109,
7110,
7111,
7112,
7113,
7114,
7115,
7122,
7126,
7127,
7128,
7130,
7132,
7134,
7137,
7138,
7141,
7142,
7143,
7144,
7145,
7146,
7147,
7148,
7149,
7151,
7152,
7153,
7154,
7155,
7156,
7157,
7158,
7159,
7162,
7163,
7164,
7165,
7166,
7167,
7168,
7172,
7173,
7174,
7175,
7176,
7180,
7183,
7184,
7185,
7186,
7187,
7188,
7189,
7202,
7203,
7204,
7205,
7206,
7208,
7212,
7213,
7214,
7215,
7220,
7222,
7223,
7224,
7226,
7228,
7231,
7232,
7233,
7235,
7240,
7241,
7242,
7243,
7244,
7245,
7246,
7247,
7249,
7250,
7252,
7260,
7265,
7270,
7272,
7276,
7277,
7278,
7302,
7303,
7304,
7306,
7307,
7310,
7312,
7313,
7314,
7315,
7317,
7320,
7323,
7324,
7325,
7326,
7400,
7402,
7403,
7404,
7405,
7407,
7408,
7411,
7412,
7413,
7414,
7415,
7416,
7417,
7418,
7419,
7421,
7422,
7423,
7424,
7425,
7426,
7427,
7428,
7430,
7431,
7432,
7433,
7434,
7435,
7436,
7437,
7438,
7440,
7442,
7443,
7444,
7445,
7446,
7447,
7448,
7450,
7451,
7452,
7453,
7454,
7455,
7456,
7457,
7458,
7459,
7460,
7462,
7463,
7464,
7472,
7473,
7477,
7482,
7484,
7492,
7493,
7494,
7500,
7502,
7503,
7504,
7505,
7512,
7513,
7514,
7515,
7516,
7517,
7522,
7523,
7524,
7525,
7526,
7527,
7530,
7532,
7533,
7534,
7535,
7536,
7537,
7542,
7543,
7545,
7546,
7550,
7551,
7552,
7553,
7554,
7556,
7557,
7558,
7559,
7560,
7562,
7563,
7602,
7603,
7604,
7605,
7606,
7608,
7610,
7710,
7741,
7742,
7743,
7744,
7745,
7746,
7747,
7748,
8000,
8001,
8002,
8003,
8004,
8005,
8006,
8008,
8010,
8012,
8021,
8022,
8024,
8027,
8031,
8032,
8036,
8037,
8038,
8040,
8041,
8042,
8044,
8045,
8046,
8047,
8048,
8049,
8050,
8051,
8052,
8053,
8055,
8057,
8058,
8060,
8064,
8070,
8087,
8090,
8091,
8092,
8098,
8102,
8103,
8104,
8105,
8106,
8107,
8108,
8109,
8112,
8113,
8114,
8115,
8117,
8118,
8121,
8122,
8123,
8124,
8125,
8126,
8127,
8132,
8133,
8134,
8135,
8136,
8142,
8143,
8152,
8153,
8154,
8155,
8156,
8157,
8158,
8162,
8164,
8165,
8166,
8172,
8173,
8174,
8175,
8180,
8181,
8182,
8184,
8185,
8187,
8192,
8193,
8194,
8195,
8196,
8197,
8200,
8201,
8203,
8207,
8208,
8212,
8213,
8214,
8215,
8216,
8217,
8218,
8219,
8222,
8223,
8224,
8225,
8226,
8228,
8231,
8232,
8233,
8234,
8235,
8236,
8238,
8239,
8240,
8241,
8242,
8243,
8245,
8246,
8247,
8248,
8252,
8253,
8254,
8255,
8259,
8260,
8261,
8262,
8263,
8264,
8265,
8266,
8267,
8268,
8269,
8272,
8273,
8274,
8280,
8301,
8302,
8303,
8304,
8305,
8306,
8307,
8308,
8309,
8310,
8311,
8312,
8314,
8315,
8317,
8320,
8322,
8330,
8331,
8332,
8335,
8340,
8342,
8344,
8345,
8352,
8353,
8354,
8355,
8356,
8357,
8360,
8362,
8363,
8370,
8371,
8372,
8374,
8376,
8400,
8401,
8404,
8405,
8406,
8408,
8409,
8412,
8413,
8414,
8415,
8416,
8418,
8421,
8422,
8424,
8425,
8426,
8427,
8428,
8442,
8444,
8447,
8450,
8451,
8452,
8453,
8454,
8455,
8457,
8458,
8459,
8460,
8461,
8462,
8463,
8464,
8465,
8466,
8467,
8468,
8471,
8472,
8474,
8475,
8476,
8477,
8478,
8479,
8482,
8483,
8484,
8486,
8487,
8488,
8489,
8492,
8493,
8494,
8495,
8496,
8497,
8498,
8499,
8500,
8501,
8505,
8506,
8507,
8508,
8509,
8510,
8512,
8514,
8522,
8523,
8524,
8525,
8526,
8532,
8535,
8536,
8537,
8542,
8543,
8544,
8545,
8546,
8547,
8548,
8552,
8553,
8554,
8555,
8556,
8558,
8560,
8561,
8564,
8565,
8566,
8570,
8572,
8573,
8574,
8575,
8576,
8577,
8580,
8581,
8582,
8583,
8584,
8585,
8586,
8587,
8588,
8589,
8590,
8592,
8593,
8594,
8595,
8596,
8597,
8598,
8599,
8600,
8602,
8603,
8604,
8605,
8606,
8607,
8608,
8610,
8613,
8614,
8615,
8616,
8617,
8618,
8620,
8623,
8624,
8625,
8626,
8627,
8630,
8632,
8633,
8634,
8635,
8636,
8637,
8638,
8640,
8645,
8646,
8700,
8702,
8703,
8704,
8706,
8707,
8708,
8712,
8713,
8714,
8715,
8716,
8717,
8718,
8722,
8723,
8725,
8726,
8727,
8730,
8732,
8733,
8734,
8735,
8737,
8738,
8739,
8750,
8751,
8752,
8753,
8754,
8755,
8756,
8757,
8758,
8762,
8765,
8766,
8767,
8772,
8773,
8774,
8775,
8777,
8782,
8783,
8784,
8800,
8802,
8803,
8804,
8805,
8806,
8807,
8808,
8810,
8815,
8816,
8820,
8824,
8825,
8832,
8833,
8834,
8835,
8836,
8840,
8841,
8842,
8843,
8844,
8845,
8846,
8847,
8849,
8852,
8853,
8854,
8855,
8856,
8857,
8858,
8862,
8863,
8864,
8865,
8866,
8867,
8868,
8872,
8873,
8874,
8877,
8878,
8880,
8881,
8882,
8883,
8884,
8885,
8886,
8887,
8888,
8889,
8890,
8892,
8893,
8894,
8895,
8896,
8897,
8898,
8902,
8903,
8904,
8905,
8906,
8907,
8908,
8909,
8910,
8911,
8912,
8913,
8914,
8915,
8916,
8917,
8918,
8919,
8925,
8926,
8932,
8933,
8934,
8942,
8951,
8952,
8953,
8954,
8955,
8956,
8957,
8962,
8964,
8965,
8966,
8967,
9000,
9001,
9004,
9006,
9008,
9010,
9011,
9012,
9014,
9015,
9016,
9030,
9032,
9033,
9034,
9035,
9036,
9037,
9038,
9042,
9043,
9044,
9050,
9052,
9053,
9054,
9055,
9056,
9057,
9058,
9062,
9063,
9064,
9100,
9102,
9103,
9104,
9105,
9107,
9108,
9112,
9113,
9114,
9115,
9116,
9122,
9123,
9125,
9126,
9127,
9200,
9201,
9203,
9204,
9205,
9212,
9213,
9214,
9215,
9216,
9217,
9220,
9223,
9225,
9230,
9231,
9240,
9242,
9243,
9244,
9245,
9246,
9247,
9248,
9249,
9300,
9301,
9304,
9305,
9306,
9308,
9312,
9313,
9314,
9315,
9320,
9322,
9323,
9325,
9326,
9327,
9400,
9401,
9402,
9403,
9404,
9405,
9410,
9411,
9413,
9422,
9423,
9424,
9425,
9426,
9427,
9428,
9430,
9434,
9435,
9436,
9437,
9442,
9443,
9444,
9445,
9450,
9451,
9452,
9453,
9454,
9462,
9463,
9464,
9465,
9466,
9467,
9468,
9469,
9470,
9472,
9473,
9475,
9476,
9477,
9478,
9479,
9485,
9486,
9487,
9488,
9490,
9491,
9492,
9493,
9494,
9495,
9496,
9497,
9498,
9500,
9501,
9502,
9503,
9504,
9506,
9507,
9508,
9512,
9514,
9515,
9517,
9523,
9524,
9525,
9526,
9527,
9532,
9533,
9534,
9535,
9536,
9542,
9543,
9545,
9546,
9547,
9548,
9552,
9553,
9554,
9555,
9556,
9562,
9565,
9573,
9601,
9602,
9604,
9606,
9607,
9608,
9612,
9613,
9614,
9615,
9620,
9621,
9622,
9630,
9631,
9633,
9642,
9643,
9650,
9651,
9652,
9655,
9656,
9657,
9658,

        };
    }
}
