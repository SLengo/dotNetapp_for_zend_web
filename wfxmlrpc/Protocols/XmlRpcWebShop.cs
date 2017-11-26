using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlRpc;

namespace wfxmlrpc.Protocols
{
    public class XmlRpcWebShop
    {
        public string urlDomain { get; set; }
        public string className { get; set; }
        public XmlRpcClient clientXmlRpc { get; set; }

        public XmlRpcWebShop(string urlDomainCtor, string classNameCtor)
        {
            this.urlDomain = urlDomainCtor;
            this.className = classNameCtor;
            this.clientXmlRpc = new XmlRpcClient();
            clientXmlRpc.Url = this.urlDomain;
        }

        public string parseResponse(string str)
        {
            string json = "";
            int pFrom = str.IndexOf("{") + "{".Length;
            int pTo = str.LastIndexOf("}") + 2;

            json = str.Substring(pFrom - 1, pTo - pFrom);
            return json;
        }


        public string getResponse(string actionName, KeyValuePair<String, object>[] arrParams)
        {
            XmlRpcRequest request = new XmlRpcRequest(this.className + "." + actionName);
            request.AddParamStruct(arrParams);
            XmlRpcResponse response = this.clientXmlRpc.Execute(request);
            return parseResponse(response.GetString());
        }
    }
}
