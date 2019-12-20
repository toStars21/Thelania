using System;

namespace Thelania.Units
{
    public abstract class UnitFactoryBase : IUnitFactory
    {
        public int Level { get; private set; }

        protected UnitFactoryBase(int level)
        {
            Level = level;
        }

        public void Upgrade()
        {
            Level++;
        }

        public UnitBase Spawn()
        {
            var unit = SpawnInternal();

            if (unit == null)
                throw new ArgumentNullException($"Error cannot spawn null unit");

            return unit;
        }

        protected abstract UnitBase SpawnInternal();
    }
}
