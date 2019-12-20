using System;
using Assets.Code.Extensions;

namespace Assets.Code.Core.Aspects
{
    public class CanAttackAspect : ICanAttack
    {
        public double AttackDistance { get; }
        public double AttackPower { get; }
        public TimeSpan AttacksInterval { get; }

        public CanAttackAspect(double attackDistance, double attackPower, TimeSpan attacksInterval)
        {
            attackDistance.AssertGreaterThan(0);
            attackPower.AssertGreaterThan(0);
            attacksInterval.AssertGreaterThan(TimeSpan.Zero);

            AttackPower = attackPower;
            AttackDistance = attackDistance;
            AttacksInterval = attacksInterval;
        }
    }
}
