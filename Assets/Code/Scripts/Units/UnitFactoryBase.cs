using Assets.Code.Extensions;
using UnityEngine;

namespace Assets.Code.Scripts.Units
{
    public abstract class UnitFactoryBase : MonoBehaviour
    {
        private readonly float _spawnIntervalSeconds;

        private float _nextSpawnTime;

        public GameObject prototype;

        protected UnitFactoryBase(float spawnIntervalSeconds)
        {
            spawnIntervalSeconds.AssertGreaterThan(0);
            _spawnIntervalSeconds = spawnIntervalSeconds;
        }

        private void Start()
        {
            _nextSpawnTime = Time.time;
        }

        private void Update()
        {
            if (Time.time > _nextSpawnTime)
            {
                Instantiate(prototype, transform.position, transform.rotation);
                _nextSpawnTime += _spawnIntervalSeconds;
            }
        }
    }
}