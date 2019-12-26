using System.Linq;
using UnityEngine;

namespace Assets.Code.Scripts.UnitsBehaviors.StateMachineBehaviors
{
    public class BehaviourAttack : StateMachineBehaviour
    {
        private BehaviourSelectedTarget _behaviourSelectedTarget;
        private BehaviourHealthPoints _enemyBehaviourHealthPoints;
        private BehaviourPower _power;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger("Walk");
            _behaviourSelectedTarget = animator.gameObject.GetComponent<BehaviourSelectedTarget>();
            _enemyBehaviourHealthPoints = _behaviourSelectedTarget.SelectedTarget.GetComponent<BehaviourHealthPoints>();
            _power = _behaviourSelectedTarget.SelectedTarget.GetComponent<BehaviourPower>();
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var clipInfo = animator.GetCurrentAnimatorClipInfo(0).FirstOrDefault(cl => cl.clip.name.Contains("Attack"));
            animator.speed = (1f * clipInfo.clip.length) / _power.AttackIntervalSeconds;
            if (_behaviourSelectedTarget.SelectedTarget == null || _enemyBehaviourHealthPoints.IsDead)
            {
                return;
            }
            animator.transform.LookAt(_behaviourSelectedTarget.SelectedTarget.transform);
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.speed = 1f;
            if (_enemyBehaviourHealthPoints.IsDead || _behaviourSelectedTarget.SelectedTarget == null)
            {
                animator.SetTrigger("Walk");
                animator.ResetTrigger("Attack");
                _behaviourSelectedTarget.SelectedTarget = null;
                return;
            }
            _enemyBehaviourHealthPoints.GiveDamage(_power.AttackPower);
            animator.SetTrigger("Attack");
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
