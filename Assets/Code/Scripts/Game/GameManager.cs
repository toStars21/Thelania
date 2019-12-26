using System;
using System.Collections.Generic;
using Assets.Code.Scripts.Camera;
using Assets.Code.Scripts.Players;
using UnityEngine;
using Random = System.Random;

namespace Assets.Code.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameMap _gameMapPrefab;
        [SerializeField] private Player _playerPrefab;

        private GameMap _currentGameMap;
        private Player _mainPlayer;
        private RTS_Camera _camera;

        public int opponentsCount;
        public string mainPlayerName;

        private Random _rand = new Random();

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
            SpawnPlayers();
            //GameTimeController.Instance.BeginTimer();
        }

        private void SpawnPlayers()
        {
            var mainPlayerVillageIndex = _rand.Next(0, _currentGameMap.spawnPoints.Length);

            _mainPlayer = Instantiate(
                _playerPrefab,
                _currentGameMap.spawnPoints[mainPlayerVillageIndex].position,
                _currentGameMap.spawnPoints[mainPlayerVillageIndex].rotation,
                _currentGameMap.transform);
            _mainPlayer.info = PlayerInfo.Create(mainPlayerName);
            PlayersManager.MainPlayer = _mainPlayer;

            var opponentSpawnPoints = new List<Transform>();
            for (int spawnPointIndex = 0; spawnPointIndex < _currentGameMap.spawnPoints.Length; spawnPointIndex++)
            {
                if (spawnPointIndex!=mainPlayerVillageIndex)
                    opponentSpawnPoints.Add(_currentGameMap.spawnPoints[spawnPointIndex]);
            }

            for (int opponentIndex = 0; opponentIndex < opponentsCount; opponentIndex++)
            {
                var spawnPoint = opponentSpawnPoints[opponentIndex];
                var opponent = Instantiate(_playerPrefab, spawnPoint.position, spawnPoint.rotation, _currentGameMap.transform);
                opponent.info = PlayerInfo.Create($"Player{opponentIndex + 1}" == mainPlayerName
                    ? "Vitia"
                    : $"Player{opponentIndex + 1}");
                PlayersManager.Opponents.Add(opponent);
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
            _camera.minHeight = mapSize.y;
            _camera.maxHeight = mapSize.y * 4f;
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
