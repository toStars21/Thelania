using System;
using Assets.Code.Core;
using Assets.Code.Extensions;
namespace Thelania.Units
{
    public abstract class UnitFactoryBase : IUnitFactory
    {
        protected UnitFactoryBase()
        {
        }

        public UnitBase Spawn(int level)
        {
            level.AssertGreaterThan(0);

            var unit = SpawnInternal(level);

            if (unit == null)
                throw new ArgumentNullException($"Error cannot spawn null unit");

            return unit;
        }

        protected abstract UnitBase SpawnInternal(int level);
    }
}
