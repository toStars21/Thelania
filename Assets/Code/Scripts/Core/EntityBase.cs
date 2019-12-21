using System.Collections.Generic;
using Assets.Code.Core;
using Thelania.Core;
using UnityEngine;

namespace Assets.Code.Scripts.Core
{
    public abstract class EntityBase : MonoBehaviour, IAspectsHolder
    {
        protected readonly AspectsContainer Aspects = new AspectsContainer();

        IReadOnlyCollection<IAspect> IAspectsHolder.Aspects => Aspects.Aspects;
    }
}
