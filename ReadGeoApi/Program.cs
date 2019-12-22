using System;
using ReadGeoApi;

namespace ReadGeoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            GeoApiHelper geoApi = new GeoApiHelper();
            var result = geoApi.ReadSingleValue();
            result.Wait();
            var returned = result.Result;
        }
    }
}
