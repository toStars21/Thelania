using Assets.Code.Extensions;

namespace Assets.Code.Core.Aspects
{
    public class CanUpgradeAspect : IAspect, ICanUpgrade
    {
        public CanUpgradeAspect(int level)
        {
            level.AssertGreaterThan(0);

            Level = level;
        }

        public int Level { get; private set; }

        public void Upgrade()
        {
            Level++;
        }
    }
}