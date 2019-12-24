using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Scripts
{
    public class MoveX : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        private Trail _currentTrail;
        private int _currentTrailIndex;

        private void Start()
        {
            var trailHolder = GameObject.Find("GameMap(Clone)").GetComponent<GameMap>().trailHolder;
            _currentTrail = trailHolder.GetNearestTrail(transform.position);
            var currentMinDistance = Vector3.Distance(transform.position, _currentTrail.nodes[0].transform.position);
            for (int i = 1; i < _currentTrail.nodes.Length; i++)
            {
                var checkingDistance = Vector3.Distance(_currentTrail.nodes[i].transform.position, transform.position);
                if (currentMinDistance > checkingDistance)
                {
                    _currentTrailIndex = i;
                }
            }
        }

        private void Update()
        {
            navMeshAgent.destination = _currentTrail.nodes[_currentTrailIndex].position;
            if (Vector3.Distance(transform.position, _currentTrail.nodes[_currentTrailIndex].transform.position) < 10)
            {
                if (_currentTrailIndex + 1 < _currentTrail.nodes.Length)
                {
                    _currentTrailIndex += 1;
                }
                else
                {
                    _currentTrailIndex = 0;
                }
            }
        }
    }
}