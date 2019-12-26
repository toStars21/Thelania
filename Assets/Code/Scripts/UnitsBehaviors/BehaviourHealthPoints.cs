using UnityEngine;

namespace Assets.Code.Scripts.UnitsBehaviors
{
    public class BehaviourHealthPoints : MonoBehaviour
    {
        [SerializeField] public int StartingHealth;

        private Animator _animator;

        public bool IsDead { get; private set; }
        public int CurrentHealth { get; private set; }

        private void Awake()
        {
            CurrentHealth = StartingHealth;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void GiveDamage(int amount)
        {
            CurrentHealth -= amount;
            
            if (CurrentHealth <= 0 && !IsDead)
            {
                Death();
            }
        }

        private void Death()
        {
            IsDead = true;
            _animator.SetTrigger("Death");
        }
    }
}
