namespace Logger.Layouts.Factories
{
    using Contracts;
    using Logger.Layouts.Contracts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            var typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "simplelayout":
                    return new SimpleLayout();

                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invali Layout type!");
            }
        }
    }
}
