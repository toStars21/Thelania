using System;
using Assets.Code.Scripts.Players;
using UnityEngine;

namespace Assets.Code.Scripts.Units
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] private float spawnIntervalSeconds;
        [SerializeField] private Unit prototype;

        private float _nextSpawnTime;

        private Player _owner;

        private void Start()
        {
            _nextSpawnTime = Time.time;

            _owner = GetComponentInParent<Player>();

            if (_owner == null)
                throw new InvalidOperationException($"Cannot spawn units without Player component");
        }

        private void Update()
        {
            if (Time.time > _nextSpawnTime)
            {
                var unit = Instantiate(prototype, transform.position + transform.forward * 25, transform.rotation, transform);
                unit.owner = _owner;

                _nextSpawnTime += spawnIntervalSeconds;
            }
        }
    }
}