namespace _05_Mordor_sCruelPlan.Factories
{
    using Models.Moods;

    class MoodFactory
    {
        public  Mood CreateMode(int happiness)
        {
            if (happiness <-5)
            {
                return new Angry();
                
            }

            if (happiness >= -5 && happiness <= 0)
            {
                return new Sad();
            }

            if (happiness >= 1 && happiness <= 15)
            {
                return new Happy();
            }

            if (happiness > 15)
            {
                return new JavaScript();
            }

            return new Legendary();
        }
    }
}

