﻿using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Scripts.UnitsBehaviors.StateMachineBehaviors
{
    public class BehaviourFindEnemy : StateMachineBehaviour
    {
        private BehaviourSelectedTarget _behaviourSelectedTarget;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger("Attack");
            _behaviourSelectedTarget = animator.gameObject.GetComponent<BehaviourSelectedTarget>();
            _behaviourSelectedTarget.SelectedTarget = null;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var unit in GameObject.FindGameObjectsWithTag("Unit"))
            {
                if (unit.gameObject == animator.gameObject)
                    continue;
                var behaviourHealthPoints = unit.GetComponent<BehaviourHealthPoints>();
                if (behaviourHealthPoints == null || behaviourHealthPoints.IsDead)
                    continue;
                if (Vector3.Distance(unit.transform.position, animator.transform.position) <= 50f)
                {
                    if (unit.gameObject == animator.gameObject)
                        continue;
                    _behaviourSelectedTarget.SelectedTarget = unit;
                    animator.SetTrigger("Attack");
                    animator.ResetTrigger("Walk");
                    return;
                }
            }
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