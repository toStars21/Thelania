using Assets.Code.Scripts.Core;
using Thelania.Core;
using Thelania.Core.Aspects;

namespace Assets.Code.Scripts.Units
{
    public abstract class BuildingBase : EntityBase
    {
        protected BuildingBase(double hp)
        {
            Aspects.Add<IKillable>(new KillableAspect(hp, () => Destroy(gameObject)));
        }
    }
}
