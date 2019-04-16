namespace Skeleton
{
    using Skeleton.Contracts;
    using System;


  public  class FakeWeapon : IWeapon
    {
        public const int InitialAttackPoints = 10;
        public const int InitialDurabilityPoints = 10;

        public int AttackPoints => InitialAttackPoints;
        public int DurabilityPoints=> InitialDurabilityPoints;

        public void Attack(ITarget target)
        {
           
        }
    }
}
