using System;
using Assets.Code.Scripts.Camera;
using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    internal class GameManager : MonoBehaviour
    {
        [SerializeField] public GameObject gameMap;

        private GameObject _currentGameMap;
        private RTS_Camera _camera;

        private void Start()
        {
            _currentGameMap = Instantiate(gameMap, transform);
            var cameraGameObject = GameObject.FindWithTag("MainCamera");
            _camera = cameraGameObject.GetComponent<RTS_Camera>();
            if (_camera == null)
            {
                Debug.LogError("Failed to find main camera");
                throw new NullReferenceException();
            }
            SetCameraProperties();
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
        }

        private Vector3 GetMapSize()
        {
            var terrainComponent = _currentGameMap.GetComponentInChildren(typeof(Terrain)) as Terrain;
            if (terrainComponent == null)
            {
                Debug.LogError("Failed to find terrain");
                throw new NullReferenceException();
            }

            return terrainComponent.terrainData.size;
        }
    }
}
