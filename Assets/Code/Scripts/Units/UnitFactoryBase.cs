using Assets.Code.Extensions;
using UnityEngine;

namespace Assets.Code.Scripts.Units
{
    public abstract class UnitFactoryBase : MonoBehaviour
    {
        private readonly float _spawnIntervalSeconds;

        private float _nextSpawnTime = 0f;

        public GameObject prototype;

        protected UnitFactoryBase(float spawnIntervalSeconds)
        {
            spawnIntervalSeconds.AssertGreaterThan(0);
            _spawnIntervalSeconds = spawnIntervalSeconds;
        }

        void Start()
        {
            _nextSpawnTime = Time.time;
        }

        void Update()
        {
            if (Time.time > _nextSpawnTime)
            {
                Instantiate(prototype, transform);
                _nextSpawnTime += _spawnIntervalSeconds;
            }
        }
    }
}
