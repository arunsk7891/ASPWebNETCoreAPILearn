using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ASPWebNETCoreAPI
{
    public class GetDetails
    {

        public static string GetIpdetails()
        {
            var IPAdd = "";


            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPAdd = ip.ToString();
                }
            }
            var res = "Not Found";
            res = IPAdd;
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + IPAdd);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);

                ipInfo.Country = myRI1.EnglishName;

            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }

            res = IPAdd + " Details : " + ipInfo.Country + " : " + ipInfo.Region;
            return res;

        }
    }
}


public class IpInfo
{
    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("hostname")]
    public string Hostname { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("region")]
    public string Region { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("loc")]
    public string Loc { get; set; }

    [JsonProperty("org")]
    public string Org { get; set; }

    [JsonProperty("postal")]
    public string Postal { get; set; }
}