using ReadGeoApi.ReadGeoApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReadGeoApi
{
    public class GeoApiHelper
    {
        public async Task<string> ReadSingleValue()
        {
            using (HttpClient client = new HttpClient())
            {
                PostData data = new PostData();
                var result = await client.PostAsync(new Uri("http://localhost:5000/api/geo"), data.GetStringContent());
                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return result.Content.ToString();
                }
            }
            return string.Empty;
        }
    }
}
