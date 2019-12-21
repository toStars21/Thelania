using System;
using Assets.Code.Extensions;

namespace Assets.Code.Core.Aspects
{
    public class KillableAspect : IAspect, IKillable
    {
        private Action _onDestroy;
        public double HP { get; private set; }

        public KillableAspect(double hp, Action onDestroy)
        {
            hp.AssertGreaterThan(0);

            _onDestroy = onDestroy ?? throw new ArgumentNullException(nameof(onDestroy));
            HP = hp;
        }

        public void Damage(double value)
        {
            value.AssertGreaterThan(0);
            HP -= value;

            if (HP <= 0)
            {
                _onDestroy();
            }
        }
    }
}
