using ExcelPreparation.TerritoryCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace zipcodeMatching
{
    public class Kaempfer
    {
        List<KaempferAssociation> assoc { get; set; }
        MasterZipCodes masterZipCodes { get; set; }
        SmaAndSmd smaAndsmd { get; set; }
        string Incorrect { get; set; }
        string Correct { get; set; }
        public Kaempfer()
        {
            assoc = new List<KaempferAssociation>();
            InitiAlizeKaempferAssoc();
            masterZipCodes = new MasterZipCodes();
            smaAndsmd = new SmaAndSmd();
        }

        class KaempferAssociation
        {
            public KaempferAssociation(int plz, string region, string sdi, string terr, string sma, string smd)
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




        public void InitiAlizeKaempferAssoc()
        {
            assoc.Add(new KaempferAssociation(1657, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis" , "John Müller"));
            assoc.Add(new KaempferAssociation(2540, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(2544, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(2545, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(2814, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(3000, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3001, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3002, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3003, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3004, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3005, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3006, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3007, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3008, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3010, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3011, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3012, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3013, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3014, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3015, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3018, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3019, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3020, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3027, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3030, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3032, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3033, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3034, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3035, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3036, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3037, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3038, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3042, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3043, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3044, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3045, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3046, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3047, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3048, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3049, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3050, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3052, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3053, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3054, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3063, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3065, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3066, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3067, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3068, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3072, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3073, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3074, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3075, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3076, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3077, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3078, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3082, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3083, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3084, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3086, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3087, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3088, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3089, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3095, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3096, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3097, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3098, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3099, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3110, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3111, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3112, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3113, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3114, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3115, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3116, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3122, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3123, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3124, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3125, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3126, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3127, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3128, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3132, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3144, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3145, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3147, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3148, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3150, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3152, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3153, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3154, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3155, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3156, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3157, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3158, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3159, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3172, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3173, "5", "Anja Kämpfer", "Region_5_18", "Pascal Wolf", "Ali Dabiri"));
            assoc.Add(new KaempferAssociation(3251, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3252, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3253, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3254, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3255, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3256, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3257, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3262, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3263, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3264, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3266, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3267, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3268, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3270, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3271, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3273, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3282, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3283, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3292, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3293, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3294, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3295, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3296, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3297, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3298, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3302, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3303, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3305, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3306, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3307, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3308, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3309, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3312, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3313, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3314, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3315, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3317, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3321, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3322, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3323, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3324, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3325, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3326, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3360, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3362, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3363, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3365, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3366, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3367, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3368, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3372, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3373, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3374, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3375, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3376, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3377, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3380, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3400, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3401, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3412, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3413, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3414, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3415, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3416, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3417, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3418, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3419, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3421, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3422, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3423, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3424, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3425, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3426, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3427, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3428, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3429, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3432, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3433, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3434, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3435, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3436, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3437, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3438, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3439, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3452, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3453, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3454, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3455, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3456, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3457, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3462, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3463, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3464, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3465, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3472, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3473, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3474, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3475, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3476, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3503, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3504, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3506, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3507, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3508, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3510, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3512, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3513, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3531, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3532, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3533, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3534, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3535, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3536, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3537, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3538, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3543, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3550, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3551, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3552, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3553, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3555, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3556, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3557, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(3600, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3602, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3603, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3604, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3608, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3612, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3613, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3614, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3615, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3616, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3617, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3618, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3619, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3622, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3623, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3624, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3625, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3626, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3627, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3628, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3629, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3631, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3632, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3633, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3634, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3635, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3636, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3638, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3645, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3646, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3647, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3652, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3653, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3654, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3655, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3656, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3657, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3658, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3661, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3662, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3663, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3664, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3665, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3671, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3672, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3673, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3674, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(3700, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3702, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3703, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3704, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3705, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3706, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3707, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3711, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3713, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3714, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3715, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3716, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3717, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3718, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3722, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3723, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3724, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3725, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3752, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3753, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3754, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3755, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3756, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3757, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3758, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3762, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3763, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3764, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3765, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3766, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3770, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3771, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3772, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3773, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3775, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3776, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3777, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3778, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3780, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3781, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3782, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3783, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3784, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3785, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3792, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3800, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3801, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3803, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3804, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3805, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3806, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3807, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3812, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3813, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3814, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3815, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3816, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3818, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3822, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3823, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3824, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3825, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3826, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3852, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3853, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3854, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3855, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3856, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3857, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3858, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3860, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3862, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3863, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3864, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(3900, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3901, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3902, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3903, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3904, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3905, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3906, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3907, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3908, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3909, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3910, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3911, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3912, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3913, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3914, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3916, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3917, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3918, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3919, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3920, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3922, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3923, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3924, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3925, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3926, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3927, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3928, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3929, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3930, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3931, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3932, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3933, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3934, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3935, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3937, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3938, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3939, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3940, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3942, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3943, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3944, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3945, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3946, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3947, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3948, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3949, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3951, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3952, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3953, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3954, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3955, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3956, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3957, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3969, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3970, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3982, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3983, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3984, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3985, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3986, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3987, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3988, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3989, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3991, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3992, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3993, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3994, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3995, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3996, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3997, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3998, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(3999, "5", "Anja Kämpfer", "Region_5_13", "Kilian Holzer", "undefined"));
            assoc.Add(new KaempferAssociation(4000, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4001, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4002, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4005, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4009, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4010, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4018, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4019, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4020, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4030, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4031, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4051, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4052, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4053, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4054, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4055, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4056, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4057, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4058, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4059, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4070, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4101, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4102, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4103, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4104, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4105, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4106, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4107, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4108, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4112, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4114, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4115, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4116, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4117, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4118, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4123, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4124, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4125, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4126, "5", "Anja Kämpfer", "Region_5_10", "Markus Löw", "Benedict Birkner"));
            assoc.Add(new KaempferAssociation(4127, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4132, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4133, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4142, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4143, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4144, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4145, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4146, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4147, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4148, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4153, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4202, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4203, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4204, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4206, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4207, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4208, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4222, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4223, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4224, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4225, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4226, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4227, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4228, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4229, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4232, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4233, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4234, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4242, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4243, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4244, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4245, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4246, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4247, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4252, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4253, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4254, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4302, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4303, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4304, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4305, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4310, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4312, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4313, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4314, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4315, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4316, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4317, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4322, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4323, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4324, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4325, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4332, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4333, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4334, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4402, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4410, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4411, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4412, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4413, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4414, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4415, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4416, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4417, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4418, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4419, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4421, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4422, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4423, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4424, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4425, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4426, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4431, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4432, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4433, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4434, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4435, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4436, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4437, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4438, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4441, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4442, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4443, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4444, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4445, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4446, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4447, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4448, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4450, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4451, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4452, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4453, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4455, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4456, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4457, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4458, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4460, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4461, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4462, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4463, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4464, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4465, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4466, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4467, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4468, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4469, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4492, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4493, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4494, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4495, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4496, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4497, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(4500, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4502, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4503, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4512, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4513, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4514, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4515, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4522, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4523, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4524, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4525, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4528, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4532, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4533, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4534, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4535, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4536, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4537, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4538, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4539, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4542, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4543, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4552, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4553, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4554, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4556, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4557, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4558, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4562, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4563, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4564, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4565, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4566, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4571, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4573, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4574, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4576, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4577, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4578, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4579, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4581, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4582, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4583, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4584, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4585, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4586, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4587, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4588, "5", "Anja Kämpfer", "Region_5_17", "Charif El-Husseini", "Nicole Obrist"));
            assoc.Add(new KaempferAssociation(4600, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4612, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4613, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4614, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4615, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4616, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4617, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4618, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4622, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4623, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4624, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4625, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4626, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4628, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4629, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4632, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4633, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4634, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4652, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4653, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4654, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4655, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4656, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4657, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4658, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4663, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4665, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4702, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4703, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4704, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4710, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4712, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4713, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4714, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4715, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4716, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4717, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4718, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4719, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4800, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4802, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4803, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4805, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4806, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4812, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4813, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4814, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4852, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(4853, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4856, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4900, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4901, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4911, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4912, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4913, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4914, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4915, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4916, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4917, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4919, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4922, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4923, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4924, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4932, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4933, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4934, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4935, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4936, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4937, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4938, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4942, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4943, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4944, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4950, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4952, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4953, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4954, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(4955, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5000, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5001, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5004, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5012, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5013, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5014, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5015, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5017, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5018, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5022, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5023, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5024, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5025, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5026, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5027, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5028, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5032, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5033, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5034, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5035, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5036, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5037, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5040, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5042, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5043, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5044, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5046, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5053, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5054, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5056, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5057, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5058, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5062, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5063, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5064, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5070, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5072, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5073, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5074, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5075, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5076, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5077, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5078, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5079, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5080, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5082, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5083, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5084, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5085, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5102, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5103, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5113, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5272, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5273, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5274, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5275, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5276, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5277, "5", "Anja Kämpfer", "Region_5_08", "Bajram Zenuni", "undefined"));
            assoc.Add(new KaempferAssociation(5502, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5503, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5504, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5505, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5506, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5600, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5603, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5604, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5615, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5616, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5617, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5702, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5703, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5704, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5705, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5706, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5707, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5708, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5712, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5722, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5723, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5724, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5725, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5726, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5727, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5728, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5732, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5733, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5734, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5735, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5736, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5737, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(5742, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5745, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5746, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(5906, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(6016, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6017, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6018, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6019, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6022, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6024, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6025, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6083, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(6084, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(6085, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(6086, "5", "Anja Kämpfer", "Region_5_21", "Salvatore Turcis", "John Müller"));
            assoc.Add(new KaempferAssociation(6105, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6106, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6110, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6112, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6113, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6114, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6122, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6123, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6125, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6126, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6130, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6132, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6133, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6142, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6143, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6144, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6145, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6146, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6147, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6152, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6153, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6154, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6156, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6160, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6162, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6163, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6166, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6167, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6170, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6173, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6174, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6182, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6192, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6196, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6197, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6203, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6204, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6205, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6206, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6207, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6208, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6210, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6211, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(6212, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6213, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6214, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6215, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6216, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6217, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6218, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6221, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6222, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6231, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6232, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6233, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6234, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6235, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6236, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6242, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6243, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6244, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6245, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6246, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6247, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6248, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6252, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(6253, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(6260, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(6262, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(6263, "5", "Anja Kämpfer", "Region_5_15", "Stefan Kummer a.i.", "undefined"));
            assoc.Add(new KaempferAssociation(6264, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));
            assoc.Add(new KaempferAssociation(6265, "5", "Anja Kämpfer", "Region_5_09", "Stefan Kummer", "Kreshnik Mulaki"));

        }




        public void CheckIfZipsAreContained()
        {
            MasterZipCodes masterZipCodes = new MasterZipCodes();
            StringBuilder sb = new StringBuilder();
            foreach (var entry in KaempferPlz)
            {
                masterZipCodes.WhichZipIsContained(entry,"Kaempfer", sb);
            }
            Console.WriteLine(sb.ToString());
        }


        List<Int32> KaempferPlz = new List<Int32>
        {
           1657,
2540,
2544,
2545,
2814,
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
3273,
3282,
3283,
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
3969,
3970,
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
5113,
5272,
5273,
5274,
5275,
5276,
5277,
5502,
5503,
5504,
5505,
5506,
5600,
5603,
5604,
5615,
5616,
5617,
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
6016,
6017,
6018,
6019,
6022,
6024,
6025,
6083,
6084,
6085,
6086,
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

        };
    }
}
