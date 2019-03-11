namespace _03_Ferrary
{
    interface IFerrary
    {
        string Model { get; }

        string DriverName { get; }

        string Brakes();

        string GasPedal();
    }
}
