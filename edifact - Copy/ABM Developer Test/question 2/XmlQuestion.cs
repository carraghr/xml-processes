using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace ABM_Developer_Test.question_2
{
    class XmlQuestion
    {
        public void RunSolution()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<InputDocument>" +
	"<DeclarationList>" +
			"<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +

			"<DeclarationHeader>" +
				"<Jurisdiction>IE</Jurisdiction>" +
			"<CWProcedure>IMPORT</CWProcedure>" +
			"<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
			"<DocumentRef>71Q0019681</DocumentRef>" +
			"<SiteID>DUB</SiteID>" +
			"<AccountCode>G0779837</AccountCode>" +
			"<Reference RefCode=\"MWB\">" +
			  "<RefText>586133622</RefText>" +
			"</Reference>" +
			"<Reference RefCode=\"KEY\">" +
			  "<RefText>DUB16049</RefText>" +
			"</Reference>" +
			"<Reference RefCode=\"CAR\">" +
			  "<RefText>71Q0019681</RefText>" +
			"</Reference>" +
			"<Reference RefCode=\"COM\">" +
			  "<RefText>71Q0019681</RefText>" +
			"</Reference>" +
			"<Reference RefCode=\"SRC\">" +
			  "<RefText>ECUS</RefText>" +
			"</Reference>" +
			"<Reference RefCode=\"TRV\">" +
			  "<RefText>1</RefText>" +
			"</Reference>" +
			"<Reference RefCode=\"CAS\">" +
			 "<RefText>586133622</RefText>" +
			"</Reference>" +
			"<Reference RefCode=\"HWB\">" +
			  "<RefText>586133622</RefText>" +
			"</Reference>" +
			"<Reference RefCode=\"UCR\">" +
			  "<RefText>586133622</RefText>" +
			"</Reference>" +
			"<Country CodeType=\"NUM\" CountryType=\"Destination\">IE</Country>" +
			"<Country CodeType=\"NUM\" CountryType=\"Dispatch\">CN</Country>" +
			"</DeclarationHeader>" +
			"</Declaration>" +
	"</DeclarationList>" +
"</InputDocument>"
			);

            HashSet<String> keys = new HashSet<string>();
            keys.Add("MWB");
            keys.Add("TRV");
            keys.Add("CAR");

            Solution(doc, keys);

        }

        public string[] Solution(XmlDocument doc, HashSet<String> keys)
        {

			XmlNodeList nodes = doc.GetElementsByTagName("DeclarationHeader");

			foreach(XmlNode node in nodes)
			{
				foreach (XmlNode child in node.ChildNodes)
				{
					if(child.Name == "Reference" && child.Attributes!=null && child.Attributes["RefCode"] != null)
					{
						String key = child.Attributes["RefCode"].Value;
						if (keys.Contains(key))
						{
							Console.WriteLine(child.InnerText);
						}
						
					}
				}
			}

            return null;
        }
    }
}
