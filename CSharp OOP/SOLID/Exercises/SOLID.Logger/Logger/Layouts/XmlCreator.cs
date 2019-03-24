namespace Logger.Layouts
{
    using System.Xml.Linq;

    public class XmlCreator
    {
        // The purpose of this Class is only to create new XML format
        public static string CreateXmlAsString()
        {
            XElement xmlFormat = new XElement("log",
            new XElement("data", "{0}"), new XElement("level", "{1}"), new XElement("message", "{2}"));

            return xmlFormat.ToString();
        }

        
    }
}
