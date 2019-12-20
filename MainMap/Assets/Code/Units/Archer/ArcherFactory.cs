namespace Thelania.Units.Archer
{
    public class ArcherFactory : UnitFactoryBase
    {
        protected override UnitBase SpawnInternal(int level)
        {
            return new Archer(level);
        }
    }
}
