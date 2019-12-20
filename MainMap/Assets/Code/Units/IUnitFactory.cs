using Assets.Code.Core;
using Thelania.Core;

namespace Thelania.Units
{
    public interface IUnitFactory : ICanUpgrade
    {
        UnitBase Spawn();
    }
}
