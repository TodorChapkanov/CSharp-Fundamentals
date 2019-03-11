namespace _03_Ferrary
{
    class Ferrary : IFerrary
    {
        public Ferrary(string driverName)
        {
            this.Model = "488-Spider";
            this.DriverName = driverName;
        }
        public string Model { get; private set; }

        public string DriverName { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.GasPedal()}/{this.DriverName}";
        }
    }
}
