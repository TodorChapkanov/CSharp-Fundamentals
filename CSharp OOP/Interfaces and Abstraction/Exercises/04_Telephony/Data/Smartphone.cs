namespace _04_Telephony
{
    using _04_Telephony.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SmartPhone : ICallable, IBrawseable
    {
        private readonly List<string> phoneNumbers;
        private List<string> websites;

        public SmartPhone()
        {
            this.phoneNumbers = new List<string>();
            this.websites = new List<string>();
        }

        public void AddPhoneNumber(string phoneNumber)
        {
                this.phoneNumbers.Add(phoneNumber);
            
        }

        public void AddWebsite(string website)
        {
            
                this.websites.Add(website);
        }

        public string Browsing()
        {
            var builde = new StringBuilder();
            foreach (var site in this.websites)
            {
                if (!site.Any(c=> char.IsDigit(c)))
                {
                    builde.AppendLine($"Browsing: {site}!");
                }
                else
                {
                    builde.AppendLine("Invalid URL!");
                }
            }

            return builde.ToString();
        }

        public string Calling()
        {
            var builde = new StringBuilder();
            foreach (var number in this.phoneNumbers)
            {
                if (number.Any(c=> char.IsDigit(c)))
                {
                    builde.AppendLine($"Calling... {number}");
                }
                else
                {
                    builde.AppendLine("Invalid number!");
                }
                
            }

            return builde.ToString();
        }
    }
}
