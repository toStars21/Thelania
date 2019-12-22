using System;

namespace Assets.Code.Scripts.Units.Archer
{
    public class Archer : UnitBase
    {
        public Archer() : base(1, 100, 80, 30, TimeSpan.FromMilliseconds(300))
        {
        }
    }
}