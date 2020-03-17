using System;

using System.Net.Http;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XmlController : ControllerBase
    {

        private readonly ILogger<XmlController> _logger;

        public XmlController(ILogger<XmlController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            return "hello world!";
        }

        [HttpPost]
        public String Post(HttpRequestMessage request)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add("", "xml.xsd");
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(request.Content.ReadAsStreamAsync().Result, settings);

                XmlDocument document = new XmlDocument();
                document.Load(reader);
                XmlNodeList nodes = document.GetElementsByTagName("DeclarationHeader");

                foreach (XmlNode node in nodes)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name == "SiteID")
                        {
                            String key = child.InnerXml;
                            if (key != "DUB")
                            {
                                return ""+-1;
                            }
                        }
                    }
                }

                nodes = document.GetElementsByTagName("DeclarationList");

                foreach (XmlNode node in nodes)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name == "Declaration" && child.Attributes != null && child.Attributes["Command"] != null)
                        {
                            String key = child.Attributes["Command"].Value;
                            if (key != "DEFAULT")
                            {
                                return "" + -2;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return "" + 1;
            }
            return "" + 0;
        }
    }
    }
}
