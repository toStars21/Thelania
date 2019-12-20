namespace Thelania.Units.Archer
{
    public class ArcherFactory : UnitFactoryBase
    {
        public ArcherFactory(int level) : base(level)
        {
        }

        protected override UnitBase SpawnInternal()
        {
            return new Archer(Level);
        }
    }
}
