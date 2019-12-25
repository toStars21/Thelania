using System;
using Assets.Code.Scripts.Camera;
using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    internal class GameManager : MonoBehaviour
    {
        [SerializeField] private GameMap _gameMapPrefab;
        [SerializeField] private GameObject _villagePrefab;

        private GameMap _currentGameMap;
        private RTS_Camera _camera;

        private void Start()
        {
            _currentGameMap = Instantiate(_gameMapPrefab, transform);

            var cameraGameObject = GameObject.FindWithTag("MainCamera");
            _camera = cameraGameObject.GetComponent<RTS_Camera>();
            if (_camera == null)
            {
                Debug.LogError("Failed to find main camera");
                throw new NullReferenceException();
            }
            SetCameraProperties();
            SpawnVillages();
        }

        private void SpawnVillages()
        {
            foreach (var spawnPosition in _currentGameMap.villageSpawnPositions)
            {
                Instantiate(_villagePrefab, spawnPosition.position, spawnPosition.rotation, _currentGameMap.transform);
            }
        }

        private void Update()
        {

        }

        private void SetCameraProperties()
        {
            var mapSize = GetMapSize();
            _camera.limitX = mapSize.x;
            _camera.limitY = mapSize.z;
            var newCameraPos = new Vector3(mapSize.x / 2f, mapSize.y * 2f, mapSize.z / 2f);
            _camera.transform.SetPositionAndRotation(newCameraPos, _camera.transform.rotation);
            var mapDiagonal = Vector3.Distance(mapSize, Vector3.zero);
            _camera.keyboardMovementSpeed = mapDiagonal / 4f;
            _camera.followingSpeed = mapDiagonal / 4f;
            _camera.mouseRotationSpeed = mapDiagonal / 4f;
            _camera.panningSpeed = mapDiagonal / 4f;
            _camera.screenEdgeMovementSpeed = mapDiagonal / 2f;
        }

        private Vector3 GetMapSize()
        {
            return GetTerrainComponent().terrainData.size;
        }

        private Terrain GetTerrainComponent()
        {
            var terrainComponent = _currentGameMap.GetComponentInChildren(typeof(Terrain)) as Terrain;
            if (terrainComponent == null)
            {
                Debug.LogError("Failed to find terrain");
                throw new NullReferenceException();
            }

            return terrainComponent;
        }
    }
}
