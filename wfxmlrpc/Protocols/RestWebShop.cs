using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;

namespace wfxmlrpc.Protocols
{
    public class RestWebShop
    {
        public string urlDomain { get; set; }

        public RestWebShop(string urlDomainCtor)
        {
            this.urlDomain = urlDomainCtor;
        }

        public string restRequest(string action, KeyValuePair<string, object>[] arr)
        {
            string param = "{";

            foreach (var item in arr)
            {
                param += "\"" + Convert.ToString(item.Key) + "\":";
                param += "\"" + Convert.ToString(item.Value) + "\",";
            }
            param = param.Remove(param.Length - 1);
            param += "}";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(this.urlDomain + "?action=" + action + "&params=" + param);

            WebResponse rsp = wrGETURL.GetResponse();

            string sLine = "";

            using (Stream stream = rsp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                sLine = reader.ReadToEnd();
            }
            return sLine;
        }
    }
}
