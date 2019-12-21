using System;
using Assets.Code.Core;
using Assets.Code.Core.Aspects;
using Assets.Code.Extensions;
using Thelania.Core;
using Thelania.Core.Aspects;
using UnityEngine;

namespace Assets.Code.Scripts.Units
{
    public abstract class UnitBase : MonoBehaviour
    {
        private readonly AspectsContainer _aspects = new AspectsContainer();

        protected UnitBase(int level, double hp, double attackDistance, double attackPower, TimeSpan attacksInterval)
        {
            hp.AssertGreaterThan(0);
            level.AssertGreaterThan(0);
            attackDistance.AssertGreaterThan(0);
            attackPower.AssertGreaterThan(0);
            attacksInterval.AssertGreaterThan(TimeSpan.Zero);

            _aspects.Add<IKillable>(new KillableAspect(hp, () => Destroy(gameObject)));
            _aspects.Add<ICanAttack>(new CanAttackAspect(attackDistance, attackPower, attacksInterval));
            _aspects.Add<ICanUpgrade>(new CanUpgradeAspect(level));
        }
    }
}
