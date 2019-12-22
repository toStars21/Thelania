using System;

namespace Assets.Code.Core
{
    public interface ICanAttack : IAspect
    {
        double AttackDistance { get; }
        double AttackPower { get; }
        TimeSpan AttacksInterval { get; }
    }
}