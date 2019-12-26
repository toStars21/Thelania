using UnityEngine;

namespace Assets.Code.Scripts.UnitsBehaviors
{
    public class BehaviourAttackEnemy : MonoBehaviour
    {
        private void Update()
        {
            var troops = GameObject.FindGameObjectsWithTag("Unit");
            foreach (var troop in troops)
            {
                if (troop.transform == transform)
                    continue;
                if (Vector3.Distance(transform.position, troop.transform.position) < 25)
                {
                    GetComponent<Animator>()?.SetTrigger("Attack");
                }
            }
        }
    }
}
