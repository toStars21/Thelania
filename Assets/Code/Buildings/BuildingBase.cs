using System;
using Assets.Code.Core;
using Assets.Code.Extensions;
using Thelania.Core;
using Thelania.Core.Aspects;
using Thelania.Units;

namespace Thelania.Buildings
{
    public abstract class BuildingBase : ICanUpgrade, IKillable
    {
        private readonly AspectsContainer _aspects = new AspectsContainer();

        // TODO: will be used to spawn entities
        private readonly IUnitFactory _factory;

        private TimeSpan _spawningInterval;

        public int Level => _aspects.Get<ICanUpgrade>().Level;
        public double HP => _aspects.Get<IKillable>().HP;

        protected BuildingBase(IUnitFactory factory, int level, double hp)
        {
            //spawningInterval.AssertGreaterThan(TimeSpan.Zero);
            //_spawningInterval = spawningInterval;

            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _aspects.Add<ICanUpgrade>(new CanUpgradeAspect(level));
            _aspects.Add<IKillable>(new KillableAspect(hp));
        }

        public void Upgrade()
        {
            _aspects.Get<ICanUpgrade>().Upgrade();
        }

        public void Damage(double value) => _aspects.Get<IKillable>().Damage(value);
    }
}
