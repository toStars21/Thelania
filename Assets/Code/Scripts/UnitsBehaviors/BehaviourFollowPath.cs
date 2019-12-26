using Assets.Code.Scripts.Path;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Scripts.UnitsBehaviors
{
    public class BehaviourFollowPath : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        private Trail _currentTrail;
        private int _currentTrailIndex;
        private int _currentTrailDirection;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            var trailHolder = GameObject.Find("GameMap(Clone)").GetComponent<GameMap>().trailHolder;
            _currentTrail = trailHolder.GetNearestTrail(transform.position);
            var currentMinDistance = Vector3.Distance(transform.position, _currentTrail.Nodes[0].transform.position);
            for (var i = 1; i < _currentTrail.Nodes.Length; i++)
            {
                var checkingDistance = Vector3.Distance(_currentTrail.Nodes[i].transform.position, transform.position);
                if (currentMinDistance > checkingDistance)
                {
                    currentMinDistance = checkingDistance;
                    _currentTrailIndex = i;
                }
            }

            var nextTrailIndex = 0;
            var currentMinDistance2 = Vector3.Distance(transform.position + transform.forward * 50, _currentTrail.Nodes[0].transform.position);
            for (var i = 1; i < _currentTrail.Nodes.Length; i++)
            {
                var checkingDistance = Vector3.Distance(_currentTrail.Nodes[i].transform.position, transform.position + transform.forward * 100);
                if (currentMinDistance2 > checkingDistance)
                {
                    currentMinDistance2 = checkingDistance;
                    nextTrailIndex = i;
                }
            }

            _currentTrailDirection = Mathf.Clamp(nextTrailIndex - _currentTrailIndex, -1, 1);
            _animator.SetTrigger("Walk");

        }

        private void Update()
        {
            if (_currentTrailDirection == 0)
                return;
            navMeshAgent.destination = _currentTrail.Nodes[_currentTrailIndex].Position;
            if (Vector3.Distance(transform.position, _currentTrail.Nodes[_currentTrailIndex].transform.position) < 15)
            {
                _currentTrailIndex += _currentTrailDirection;
                if (_currentTrailIndex < 0)
                {
                    _currentTrailIndex = _currentTrail.Nodes.Length - 1;
                }

                if (_currentTrailIndex >= _currentTrail.Nodes.Length)
                {
                    _currentTrailIndex = 0;
                }
            }
        }
    }
}