using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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


            IPAdd = GetIPAddress();
            

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

        static string GetIPAddress()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);

            return address;



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