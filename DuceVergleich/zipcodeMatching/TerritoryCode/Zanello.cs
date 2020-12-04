using System;
using System.Collections.Generic;
using System.Text;

namespace zipcodeMatching
{
    public class Zanello
    {
        public void Check()
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
            1203,
1205,
1206,
1207,
1208,
1211,
1212,
1222,
1223,
1224,
1225,
1226,
1227,
1228,
1231,
1234,
1240,
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
1254,
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
1254,

        };
    }
}
