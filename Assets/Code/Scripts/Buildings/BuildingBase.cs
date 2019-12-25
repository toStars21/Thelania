using Assets.Code.Scripts.Core;

namespace Assets.Code.Scripts.Buildings
{
    public abstract class BuildingBase : EntityBase
    {
        protected BuildingBase(double hp)
        {
            Aspects.Add<IKillable>(new KillableAspect(hp, () => Destroy(gameObject)));
        }
    }
}