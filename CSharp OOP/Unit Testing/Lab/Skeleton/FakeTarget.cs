namespace Skeleton
{
    using Skeleton.Contracts;

    public class FakeTarget : ITarget
    {
        public const int InitialHelth = 0;
        public const int InitialrGiveExperienceReturnValue = 20;

        public int Health => InitialHelth;

        public int GiveExperience()
        {
            return InitialrGiveExperienceReturnValue;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
         
        }
    }
}
