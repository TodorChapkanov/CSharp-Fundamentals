namespace P04.Recharge
{
    public abstract class Worker : IWork, ISleeper
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }

        public virtual void Sleep()
        {
            //Worker is sleeping...
        }
    }
}