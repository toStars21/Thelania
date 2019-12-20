using System;

namespace Thelania.Units.Archer
{
    public class Archer : UnitBase
    {
        // TODO: move to separate
        private const double ARCHER_HP = 80;
        private const double ARCHER_ATTACH_DISTANCE = 50;
        private const double ARCHER_ATTACK_POWER = 30;
        private static readonly TimeSpan ARCHER_ATTACKS_INTERVAL = TimeSpan.FromMilliseconds(500);

        public Archer(int level) : base(level, ARCHER_HP, ARCHER_ATTACH_DISTANCE, ARCHER_ATTACK_POWER, ARCHER_ATTACKS_INTERVAL)
        {
        }

        protected override double UpgradeHP()
        {
            return ARCHER_HP * (1.2 * Level);
        }

        protected override double UpgradeAttackDistance()
        {
            return ARCHER_ATTACH_DISTANCE / (1.5 * Level);
        }

        protected override double UpgradeAttackPower()
        {
            return ARCHER_ATTACK_POWER * (2 * Level);
        }

        protected override TimeSpan UpgradeAttacksInterval()
        {
            return TimeSpan.FromMilliseconds(ARCHER_ATTACKS_INTERVAL.Milliseconds / (1.8 * Level));
        }
    }
}
