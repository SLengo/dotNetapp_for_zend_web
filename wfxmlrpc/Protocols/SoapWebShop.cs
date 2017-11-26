using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace wfxmlrpc.Protocols
{
    public class SoapWebShop
    {
        public string urlDomain { get; set; }

        public SoapWebShop(string urlDomainCtor)
        {
            this.urlDomain = urlDomainCtor;
        }

        public string parseXmlToJson(dynamic stuff)
        {
            string json = "";
            json = "{";
            try
            {
                foreach (var items in stuff.item)
                {

                    foreach (var vars in items)
                    {
                        var asd = vars;
                        string asdStr = "{";
                        asdStr += JsonConvert.SerializeObject(asd);
                        asdStr += "}";
                        dynamic key_val = JsonConvert.DeserializeObject(asdStr);
                        string key = (string)key_val.SelectToken("key.#text");
                        string value = "";
                        int itsArr = 0;
                        try
                        {
                            value = (string)key_val.SelectToken("value.#text");
                        }
                        catch
                        {
                            itsArr = 1;
                        }


                        if (key != null)
                        {
                            json += key + ":";
                        }
                        else if (value != null)
                        {
                            json += value + ",";
                        }


                    }


                }
            }
            catch
            {
                foreach (var vars in stuff.item)
                {
                    var asd = vars;
                    string asdStr = "{";
                    asdStr += JsonConvert.SerializeObject(asd);
                    asdStr += "}";
                    dynamic key_val = JsonConvert.DeserializeObject(asdStr);
                    string key = (string)key_val.SelectToken("key.#text");
                    string value = "";
                    int itsArr = 0;
                    try
                    {
                        value = (string)key_val.SelectToken("value.#text");
                    }
                    catch
                    {
                        itsArr = 1;
                    }


                    if (key != null)
                    {
                        json += key + ":";
                    }
                    else if (value != null)
                    {
                        json += value + ",";
                    }


                }
            }
            json = json.Remove(json.Length - 1);
            json += "}";
            return json;
        }


        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public  XmlDocument CreateSoapEnvelope(KeyValuePair<string, object>[] list, string action)
        {
            XmlDocument soapEnvelopeXml = new XmlDocument();
            String xmlStrHead = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns1="""+ this.urlDomain + @""" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:ns2=""http://xml.apache.org/xml-soap"" xmlns:enc=""http://www.w3.org/2003/05/soap-encoding"">
                                <env:Header/>
                                <env:Body>
                                <ns1:"+action+@" env:encodingStyle=""http://www.w3.org/2003/05/soap-encoding"">
                                <param0 xsi:type=""ns2:Map"">";
            String xmlStrBottom = @"</param0>
                                    </ns1:"+action+@">
                                    </env:Body>
                                    </env:Envelope> ";
            
            foreach(KeyValuePair<string, object> item in list)
            {
                xmlStrHead += "<item>";
                xmlStrHead += "<key xsi:type=\"xsd: string\">" + item.Key + "</key>";
                xmlStrHead += "<value xsi:type=\"xsd: string\">" + item.Value + "</value>";
                xmlStrHead += "</item>";
            }

            soapEnvelopeXml.LoadXml(xmlStrHead + xmlStrBottom);
            return soapEnvelopeXml;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        public string soapClientRequest(KeyValuePair<String, object>[] arr, string action)
        {
            string result = "";
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(arr, action);
            HttpWebRequest webRequest = CreateWebRequest(this.urlDomain, action);

            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    result = rd.ReadToEnd();
                }
            }

            XmlDocument res = new XmlDocument();
            res.LoadXml(result);
            string json = "";

            json = JsonConvert.SerializeXmlNode(res);
            XmlNode product = res.GetElementsByTagName("variables")[0];

            //res.LoadXml(product.InnerXml);
            json = JsonConvert.SerializeXmlNode(product);

            dynamic stuff = JsonConvert.DeserializeObject(json);

            json = "{";

            string innerj = "";

            try
            {
                foreach (var items in stuff.variables.item)
                {

                    foreach (var vars in items)
                    {
                        var asd = vars;
                        string asdStr = "{";
                        //if (vars.Count == 1) asdStr += "{";
                        asdStr += JsonConvert.SerializeObject(asd);
                        asdStr += "}";
                        //if (vars.Count == 1) asdStr += "}";
                        dynamic key_val = null;

                        key_val = JsonConvert.DeserializeObject(asdStr);

                        string key = (string)key_val.SelectToken("key.#text");
                        string value = "";
                        int itsArr = 0;

                        value = (string)key_val.SelectToken("value.#text");

                        if (key == null && value == null)
                        {
                            innerj = parseXmlToJson(key_val.value);
                            json += innerj + ",";
                        }


                        else if (key != null)
                        {
                            json += key + ":";
                        }
                        else if (value != null)
                        {
                            json += value + ",";
                        }


                    }


                }
            }
            catch
            {
                foreach (var vars in stuff.variables.item)
                {
                    var asd = vars;
                    string asdStr = "{";
                    //if (vars.Count == 1) asdStr += "{";
                    asdStr += JsonConvert.SerializeObject(asd);
                    asdStr += "}";
                    //if (vars.Count == 1) asdStr += "}";
                    dynamic key_val = null;

                    key_val = JsonConvert.DeserializeObject(asdStr);

                    string key = (string)key_val.SelectToken("key.#text");
                    string value = "";
                    int itsArr = 0;

                    value = (string)key_val.SelectToken("value.#text");

                    if (key == null && value == null)
                    {
                        innerj = parseXmlToJson(key_val.value);
                        json += innerj + ",";
                    }


                    else if (key != null)
                    {
                        json += key + ":";
                    }
                    else if (value != null)
                    {
                        json += value + ",";
                    }


                }
            }


            json = json.Remove(json.Length - 1);
            json += "}";
            //var json_1 = stuff.SelectToken("env:Envelope[0].env:Body[0].return[0].variables[0].item[0]");

            return json;
        }
    }
}
