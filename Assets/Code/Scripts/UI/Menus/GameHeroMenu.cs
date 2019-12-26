using System.Collections;
using Assets.Code.Scripts.Units;
using Assets.Code.Scripts.UnitsBehaviors;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Scripts.UI.Menus
{
    public class GameHeroMenu : MonoBehaviour
    {
        public Unit unit;

        public Text hp;
        public Text attack;
        public Image orc;
        public Image archer;
        public Image aliance;

        private BehaviourHealthPoints _health;
        private BehaviourPower _power;

        void Start()
        {
            orc.gameObject.SetActive(false);
            aliance.gameObject.SetActive(false);
            archer.gameObject.SetActive(false);
            switch (unit.Type)
            {
                case UnitTypes.Aliance:
                    aliance.gameObject.SetActive(true);
                    break;
                case UnitTypes.Orc:
                    orc.gameObject.SetActive(true);
                    break;
                case UnitTypes.Archer:
                    archer.gameObject.SetActive(true);
                    break;
            }
            _health = unit.GetComponent<BehaviourHealthPoints>();
            _power = unit.GetComponent<BehaviourPower>();
            hp.text = $"{_health.CurrentHealth}/{_health.StartingHealth}";
            attack.text = $"{_power.AttackPower}";
        }

        void Update()
        {
            hp.text = $"{_health.CurrentHealth}/{_health.StartingHealth}";
        }
    }
}
