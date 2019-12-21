using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Code.Core
{
    public class AspectsContainer
    {
        private IDictionary<Type, IAspect> _aspects = new Dictionary<Type, IAspect>();

        public TAspect Get<TAspect>() where TAspect : IAspect
        {
            if (!_aspects.TryGetValue(typeof(TAspect), out var aspect))
                throw new KeyNotFoundException($"{typeof(TAspect)}");

            return (TAspect)aspect;
        }

        public void Add<TAspect>(IAspect aspect) where TAspect : IAspect
        {
            if (_aspects.ContainsKey(typeof(TAspect)))
                throw new InvalidOperationException($"Duplicate key {typeof(TAspect)}");

            _aspects.Add(typeof(TAspect), aspect);
        }

        public void Remove<TAspect>() where TAspect : IAspect
        {
            _aspects.Remove(typeof(TAspect));
        }

        public IReadOnlyCollection<IAspect> Aspects => _aspects.Values.ToList();
    }
}
