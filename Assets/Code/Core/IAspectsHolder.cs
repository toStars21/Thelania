using System.Collections.Generic;
using Thelania.Core;

namespace Assets.Code.Core
{
    public interface IAspectsHolder
    {
        IReadOnlyCollection<IAspect> Aspects { get; }
    }
}
