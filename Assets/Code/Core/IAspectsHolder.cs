using System.Collections.Generic;

namespace Assets.Code.Core
{
    public interface IAspectsHolder
    {
        IReadOnlyCollection<IAspect> Aspects { get; }
    }
}