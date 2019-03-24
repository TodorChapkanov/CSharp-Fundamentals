namespace _08_CustomAttribute.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    class WeaponAttribute : Attribute
    {
        public WeaponAttribute(string author, int revision, string description,params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; private set; }

        public int Revision { get; set; }

        public string Description { get; set; }

        public string[] Reviewers { get; set; }

    }
}
