using Thelania.Units.Archer;

namespace Thelania.Buildings.Archers
{
    public class ArcherBuilding : BuildingBase
    {
        public ArcherBuilding() : base(new ArcherFactory(), 1, 1000)
        {
        }
    }
}
