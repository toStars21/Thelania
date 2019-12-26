using Assets.Code.Scripts.Path;
using UnityEngine;
using UnityEngine.AI;

public class BehaviourWalk : StateMachineBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Trail _currentTrail;
    private int _currentTrailIndex;
    private int _currentTrailDirection;
    private Vector3 previousPosition;
    private float _curSpeed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
        var trailHolder = GameObject.Find("GameMap(Clone)").GetComponent<GameMap>().trailHolder;
        _currentTrail = trailHolder.GetNearestTrail(animator.transform.position);
        var currentMinDistance = Vector3.Distance(animator.transform.position, _currentTrail.Nodes[0].transform.position);
        for (var i = 1; i < _currentTrail.Nodes.Length; i++)
        {
            var checkingDistance = Vector3.Distance(_currentTrail.Nodes[i].transform.position, animator.transform.position);
            if (currentMinDistance > checkingDistance)
            {
                currentMinDistance = checkingDistance;
                _currentTrailIndex = i;
            }
        }

        var nextTrailIndex = 0;
        var currentMinDistance2 = Vector3.Distance(animator.transform.position + animator.transform.forward * 50, _currentTrail.Nodes[0].transform.position);
        for (var i = 1; i < _currentTrail.Nodes.Length; i++)
        {
            var checkingDistance = Vector3.Distance(_currentTrail.Nodes[i].transform.position, animator.transform.position + animator.transform.forward * 100);
            if (currentMinDistance2 > checkingDistance)
            {
                currentMinDistance2 = checkingDistance;
                nextTrailIndex = i;
            }
        }

        _currentTrailDirection = Mathf.Clamp(nextTrailIndex - _currentTrailIndex, -1, 1);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_currentTrailDirection == 0)
            return;
        
        _navMeshAgent.destination = _currentTrail.Nodes[_currentTrailIndex].Position;
        if (Vector3.Distance(animator.transform.position, _currentTrail.Nodes[_currentTrailIndex].transform.position) < 15)
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
        
        UpdateAnimationSpeed(animator.transform, animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }

    private void UpdateAnimationSpeed(Transform transform, Animator animator)
    {
        var curMove = transform.position - previousPosition;
        _curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        animator.speed = Mathf.Clamp((_curSpeed / _navMeshAgent.speed), 0f, 1f);
    }
}
