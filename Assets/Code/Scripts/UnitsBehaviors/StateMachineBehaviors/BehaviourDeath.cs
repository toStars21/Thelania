using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Scripts.UnitsBehaviors.StateMachineBehaviors
{
    public class BehaviourDeath : StateMachineBehaviour
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("Walk");
            var navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
            navMeshAgent.radius = 0f;
            navMeshAgent.height = 0f;
            navMeshAgent.enabled = false;
            var collider = animator.gameObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
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
    }
}
