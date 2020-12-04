using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExcelPreparation.TerritoryCode
{
    public class SmaAndSmd
    {
        List<SmaSmd> smaAndSmd;

        public class SmaSmd
        {
            public SmaSmd(string userName, string federationIdentifier, string roleSMAOrSMD, string territoryName)
            {
                UserName = userName;
                FederationIdentifier = federationIdentifier;
                RoleSmaOrSmd = roleSMAOrSMD;
                TerritoryName = territoryName;
            }
            public string UserName { get; set; }
            public string FederationIdentifier { get; set; }
            public string RoleSmaOrSmd { get; set; }
            public string TerritoryName { get; set; }
        }

        public SmaAndSmd()
        {
            smaAndSmd = new List<SmaSmd>();
            InitializeSmaAndSmd();
        }

        public void InitializeSmaAndSmd()
        {
            smaAndSmd.Add(new SmaSmd("David Krecar", "ltv4130", "SMD", "Region_2_01"));
            smaAndSmd.Add(new SmaSmd("Serbay Birinci", "ltv3627", "SMA", "Region_2_01"));
            smaAndSmd.Add(new SmaSmd("Luca Gaglione", "ltv4853", "SMD", "Region_2_03"));
            smaAndSmd.Add(new SmaSmd("Marco Tarzi", "ltv1702", "SMA", "Region_2_03"));
            smaAndSmd.Add(new SmaSmd("Andreas Noll", "ltv3519", "SMA", "Region_2_04"));
            smaAndSmd.Add(new SmaSmd("Michele Iosca", "ltv3498", "SMA", "Region_2_05"));
            smaAndSmd.Add(new SmaSmd("Virgilio Ferraro", "ltv4015", "SMA", "Region_2_06"));
            smaAndSmd.Add(new SmaSmd("Giuseppe Gulino", "ltv4772", "SMD", "Region_2_06"));
            smaAndSmd.Add(new SmaSmd("Alban Shkodra", "ltv3740", "SMA", "Region_2_07"));
            smaAndSmd.Add(new SmaSmd("Sandro Heger", "ltv4887", "SMD", "Region_2_14"));
            smaAndSmd.Add(new SmaSmd("Marcos Romero", "ltv3554", "SMA", "Region_2_14"));
            smaAndSmd.Add(new SmaSmd("Dursun Birinci", "ltv4467", "SMA", "Region_2_15"));
            smaAndSmd.Add(new SmaSmd("Oktar Gar", "ltv4750", "SMD", "Region_2_15"));
            smaAndSmd.Add(new SmaSmd("Yves Chételat", "ltv4199", "SMD", "Region_4_03"));
            smaAndSmd.Add(new SmaSmd("Frédérick Oulevey", "ltv4009", "SMA", "Region_4_03"));
            smaAndSmd.Add(new SmaSmd("Fabien Fournier", "ltv4592", "SMA", "Region_4_05"));
            smaAndSmd.Add(new SmaSmd("Lionel Salzmann", "ltv3963", "SMD", "Region_4_05"));
            smaAndSmd.Add(new SmaSmd("Stéphane Délez", "ltv3307", "SMA", "Region_4_08"));
            smaAndSmd.Add(new SmaSmd("Partizan Shala", "ltv3766", "SMD", "Region_4_08"));
            smaAndSmd.Add(new SmaSmd("Frédéric Monney", "ltv910", "SMA", "Region_4_09"));
            smaAndSmd.Add(new SmaSmd("Sébastien Joly", "ltv4692", "SMD", "Region_4_09"));
            smaAndSmd.Add(new SmaSmd("Fabien Roman", "ltv4846", "SMA", "Region_4_10"));
            smaAndSmd.Add(new SmaSmd("Antoine Favre", "ltv4927", "SMD", "Region_4_10"));
            smaAndSmd.Add(new SmaSmd("Elias Zesiger", "ltv4341", "SMD", "Region_4_12"));
            smaAndSmd.Add(new SmaSmd("Bajram Zenuni", "dir14135", "SMA", "Region_5_08"));
            smaAndSmd.Add(new SmaSmd("Stefan Kummer", "ltv1288", "SMA", "Region_5_09"));
            smaAndSmd.Add(new SmaSmd("Kreshnik Mulaki", "ltv4553", "SMD", "Region_5_09"));
            smaAndSmd.Add(new SmaSmd("Alban Rexhepi", "ltv5055", "SMD", "Region_5_10"));
            smaAndSmd.Add(new SmaSmd("Markus Löw", "ltv1946", "SMA", "Region_5_10"));
            smaAndSmd.Add(new SmaSmd("Kilian Holzer", "ltv2966", "SMA", "Region_5_13"));
            smaAndSmd.Add(new SmaSmd("Donato Castronuovo", "ltv1624", "SMA", "Region_5_15"));
            smaAndSmd.Add(new SmaSmd("Charif El-Husseini", "ltv4379", "SMA", "Region_5_17"));
            smaAndSmd.Add(new SmaSmd("Nicole Obrist", "ltv9067", "SMD", "Region_5_17"));
            smaAndSmd.Add(new SmaSmd("Pascal Wolf", "ltv3437", "SMA", "Region_5_18"));
            smaAndSmd.Add(new SmaSmd("Salvatore Turcis", "ltv2355", "SMA", "Region_5_21"));
            smaAndSmd.Add(new SmaSmd("John Müller", "ltv3813", "SMD", "Region_5_21"));
            smaAndSmd.Add(new SmaSmd("Sandro Montuori a.i.", "dir15178", "SMA", "Region_6_01"));
            smaAndSmd.Add(new SmaSmd("Carmen Steger", "ltv4790", "SMA", "Region_6_03"));
            smaAndSmd.Add(new SmaSmd("Vito Modoni", "ltv1779", "SMD", "Region_6_03"));
            smaAndSmd.Add(new SmaSmd("Robert Nikolovski", "ltv1928", "SMD", "Region_6_05"));
            smaAndSmd.Add(new SmaSmd("Rossano Verrienti", "ltv3674", "SMA", "Region_6_05"));
            smaAndSmd.Add(new SmaSmd("André Moes", "ltv15127", "SMA", "Region_6_06"));
            smaAndSmd.Add(new SmaSmd("Irena Pavlovic", "ltv4359", "SMA", "Region_6_07"));
            smaAndSmd.Add(new SmaSmd("Sandro Montuori", "ltv3883", "SMA", "Region_6_08"));
            smaAndSmd.Add(new SmaSmd("Ljubisa Markovic", "ltv4459", "SMD", "Region_6_08"));
            smaAndSmd.Add(new SmaSmd("Nicole Nussbaumer", "ltv4083", "SMD", "Region_6_10"));
            smaAndSmd.Add(new SmaSmd("Roger Lieberherr", "ltv1342", "SMA", "Region_6_10"));
            smaAndSmd.Add(new SmaSmd("Angelo Calado Mercuri", "ltv3731", "SMA", "Region_6_14"));
            smaAndSmd.Add(new SmaSmd("Laëtitia Rigolot", "ltv4926", "SMD", "Region_7_03"));
            smaAndSmd.Add(new SmaSmd("Julien Pala", "ltv3339", "SMA", "Region_7_03"));
            smaAndSmd.Add(new SmaSmd("Fabrice Flammini", "ltv3149", "SMA", "Region_7_04"));
            smaAndSmd.Add(new SmaSmd("Céline Plantard", "ltv4524", "SMA", "Region_7_05"));
            smaAndSmd.Add(new SmaSmd("Michael Ferreira Da Silva Costa", "ltv4619", "SMA", "Region_7_09"));
            smaAndSmd.Add(new SmaSmd("Davy Mercier", "ltv3284", "SMA",	"Region_7_11"));

        }

        public bool CheckIfConfigurationExists(string smaOrSmD, string territory)
        {
            foreach (var entry in smaAndSmd)
            {
                if (entry.UserName == smaOrSmD && entry.TerritoryName == territory)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
