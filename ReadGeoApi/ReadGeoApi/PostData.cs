using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ReadGeoApi.ReadGeoApi
{
    public class PostData
    {
        /*"Locality" : "",
        "Zip" : "",
        "Street" : "",
        "StreetNumber" : ""*/
        string Locality { get; set; } = "";
        string Zip { get; set; } = "";
        string Street { get; set; } = "";
        string StreetNumber { get; set; } = "";

        public StringContent GetStringContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Locality:");
            sb.Append(Locality);
            sb.Append("Zip:");
            sb.Append(Zip);
            sb.Append("Street");
            sb.Append(Street);
            sb.Append("StreetNumber");
            sb.Append(StreetNumber);
            var stringContent = new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
