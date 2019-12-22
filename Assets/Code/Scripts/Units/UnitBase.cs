using System;
using Assets.Code.Core;
using Assets.Code.Core.Aspects;
using Assets.Code.Extensions;
using Assets.Code.Scripts.Core;

namespace Assets.Code.Scripts.Units
{
    public abstract class UnitBase : EntityBase
    {
        protected UnitBase(int level, double hp, double attackDistance, double attackPower, TimeSpan attacksInterval)
        {
            hp.AssertGreaterThan(0);
            level.AssertGreaterThan(0);
            attackDistance.AssertGreaterThan(0);
            attackPower.AssertGreaterThan(0);
            attacksInterval.AssertGreaterThan(TimeSpan.Zero);

            Aspects.Add<IKillable>(new KillableAspect(hp, () => Destroy(gameObject)));
            Aspects.Add<ICanAttack>(new CanAttackAspect(attackDistance, attackPower, attacksInterval));
            Aspects.Add<ICanUpgrade>(new CanUpgradeAspect(level));
        }
    }
}