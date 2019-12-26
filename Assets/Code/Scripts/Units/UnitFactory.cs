using UnityEngine;

namespace Assets.Code.Scripts.Units
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] private float spawnIntervalSeconds;
        [SerializeField] private GameObject prototype;

        private float _nextSpawnTime;

        private void Start()
        {
            _nextSpawnTime = Time.time;
        }

        private void Update()
        {
            if (Time.time > _nextSpawnTime)
            {
                Instantiate(prototype, transform.position + transform.forward * 25, transform.rotation, transform);
                _nextSpawnTime += spawnIntervalSeconds;
            }
        }
    }
}