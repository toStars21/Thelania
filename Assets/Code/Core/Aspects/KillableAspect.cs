using Assets.Code.Extensions;

namespace Thelania.Core.Aspects
{
    public class KillableAspect : IAspect, IKillable
    {
        public double HP { get; private set; }

        public KillableAspect(double hp)
        {
            hp.AssertGreaterThan(0);

            HP = hp;
        }

        public void Damage(double value)
        {
            value.AssertGreaterThan(0);
            HP -= value;
        }
    }
}
