using System;
using Assets.Code.Core;
using Thelania.Core;

namespace Thelania.Units
{
    public abstract class UnitBase : IKillable, ICanAttack, ICanUpgrade
    {
        public int Level { get; private set; }
        public double HP { get; private set; }
        public double AttackDistance { get; private set; }
        public double AttackPower { get; private set; }
        public TimeSpan AttacksInterval { get; private set;}

        protected UnitBase(int level, double hp, double attackDistance, double attackPower, TimeSpan attacksInterval)
        {
            AssertGreaterThan0(level);
            AssertGreaterThan0(hp);
            AssertGreaterThan0(attackDistance);
            AssertGreaterThan0(attackPower);
            AssertGreaterThan0(attacksInterval.Milliseconds);

            Level = level;
            HP = hp;
            AttackDistance = attackDistance;
            AttackPower = attackPower;
            AttacksInterval = attacksInterval;
        }

        public void Damage(double value)
        {
            HP -= value;
        }

        public void Upgrade()
        {
            var upgradedHp = UpgradeHP();
            var upgradedAttackDistace = UpgradeAttackDistance();
            var upgradedAttackPower = UpgradeAttackPower();
            var upgradedAttacksInterval = UpgradeAttacksInterval();

            AssertGreaterThan0(upgradedHp);
            AssertGreaterThan0(upgradedAttackDistace);
            AssertGreaterThan0(upgradedAttackPower);
            AssertGreaterThan0(upgradedAttacksInterval.Milliseconds);

            Level++;
            HP = upgradedHp;
            AttackDistance = upgradedAttackDistace;
            AttackPower = upgradedAttackPower;
            AttacksInterval = upgradedAttacksInterval;
        }

        protected abstract double UpgradeHP();
        protected abstract double UpgradeAttackDistance();
        protected abstract double UpgradeAttackPower();
        protected abstract TimeSpan UpgradeAttacksInterval();

        private static void AssertGreaterThan0(double value)
        {
            if (value <= 0)
                throw new ArgumentNullException($"{nameof(value)} must be greater than 0");
        }
    }
}