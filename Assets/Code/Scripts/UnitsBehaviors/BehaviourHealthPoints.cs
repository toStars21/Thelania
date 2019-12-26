using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Scripts.UnitsBehaviors
{
    public class BehaviourHealthPoints : MonoBehaviour
    {
        [SerializeField]private int StartingHealth;

        private bool _isDamaged;
        private bool _isDead;
        private int _currentHealth;
        
        private void Awake()
        {
            _currentHealth = StartingHealth;
        }
        
        private void TakeDamage(int amount)
        {
            _isDamaged = true;
            _currentHealth -= amount;
            
            if (_currentHealth <= 0 && !_isDead)
            {
                Death();
            }
        }

        private void Death()
        {
            _isDead = true;
            //do smthing
        }
    }
}
