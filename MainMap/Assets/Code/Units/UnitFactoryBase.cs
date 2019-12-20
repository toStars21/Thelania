using System;
using Assets.Code.Core;
using Assets.Code.Extensions;
using Thelania.Core.Aspects;

namespace Thelania.Units
{
    public abstract class UnitFactoryBase : IUnitFactory
    {
        private readonly AspectsContainer _aspects = new AspectsContainer();

        public int Level => _aspects.Get<ICanUpgrade>().Level;

        protected UnitFactoryBase(int level)
        {
            level.AssertGreaterThan(0);
            _aspects.Add<ICanUpgrade>(new CanUpgradeAspect(level));
        }

        public void Upgrade()
        {
            _aspects.Get<ICanUpgrade>().Upgrade();
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
