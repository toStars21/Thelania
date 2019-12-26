using UnityEngine;

namespace Assets.Code.Scripts.UnitsBehaviors
{
    public class BehaviourHealthPoints : MonoBehaviour
    {
        [SerializeField] private int StartingHealth;

        private Animator _animator;

        public bool IsDead { get; private set; }
        private int CurrentHealth { get; set; }

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
