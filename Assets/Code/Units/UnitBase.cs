using System;
using Assets.Code.Core;
using Assets.Code.Core.Aspects;
using Assets.Code.Extensions;
using Thelania.Core;
using Thelania.Core.Aspects;

namespace Thelania.Units
{
    public abstract class UnitBase : IKillable, ICanAttack, ICanUpgrade
    {
        private readonly AspectsContainer _aspects = new AspectsContainer();

        public int Level => _aspects.Get<ICanUpgrade>().Level;
        public double HP => _aspects.Get<IKillable>().HP;
        public double AttackDistance => _aspects.Get<ICanAttack>().AttackDistance;
        public double AttackPower => _aspects.Get<ICanAttack>().AttackPower;
        public TimeSpan AttacksInterval => _aspects.Get<ICanAttack>().AttacksInterval;

        protected UnitBase(int level, double hp, double attackDistance, double attackPower, TimeSpan attacksInterval)
        {
            _aspects.Add<IKillable>(new KillableAspect(hp));
            _aspects.Add<ICanAttack>(new CanAttackAspect(attackDistance, attackPower, attacksInterval));
            _aspects.Add<ICanUpgrade>(new CanUpgradeAspect(level));
        }

        public void Damage(double value)
        {
            _aspects.Get<IKillable>().Damage(value);
        }

        public void Upgrade()
        {
            var upgradedHp = UpgradeHP();
            var upgradedAttackDistace = UpgradeAttackDistance();
            var upgradedAttackPower = UpgradeAttackPower();
            var upgradedAttacksInterval = UpgradeAttacksInterval();

            upgradedHp.AssertGreaterThan(0);
            upgradedAttackDistace.AssertGreaterThan(0);
            upgradedAttackPower.AssertGreaterThan(0);
            upgradedAttacksInterval.AssertGreaterThan(TimeSpan.Zero);

            _aspects.Remove<ICanAttack>();
            _aspects.Remove<IKillable>();

            _aspects.Add<ICanAttack>(new CanAttackAspect(upgradedAttackDistace, upgradedAttackPower, upgradedAttacksInterval));
            _aspects.Add<IKillable>(new KillableAspect(upgradedHp));
        }

        protected abstract double UpgradeHP();
        protected abstract double UpgradeAttackDistance();
        protected abstract double UpgradeAttackPower();
        protected abstract TimeSpan UpgradeAttacksInterval();
    }
}