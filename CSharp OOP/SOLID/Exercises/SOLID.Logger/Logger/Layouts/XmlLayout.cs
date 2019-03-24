namespace Logger.Layouts
{
    using Contracts;

    public class XmlLayout : ILayout
    {
        
        public string Format => XmlCreator.CreateXmlAsString();
    }
}
