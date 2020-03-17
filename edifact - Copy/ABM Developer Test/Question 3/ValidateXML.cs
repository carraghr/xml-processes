using System;
using System.Xml;
using System.Xml.Schema;

namespace ABM_Developer_Test.Question_3
{
    class ValidateXML
    {
        public void Run()
        {
            Console.WriteLine(Solution());
        }

         int Solution()
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add("", "xml.xsd");
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create("xml.xml", settings);

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
                                return -1;
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
                                 return -2;
                            }
                        }
                    }
                }
            }catch(Exception e)
            {
                return 1;
            }
            return 0;
        }
    }
}
