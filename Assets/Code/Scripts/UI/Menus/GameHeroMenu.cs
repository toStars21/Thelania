using System.Collections;
using Assets.Code.Scripts.Units;
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

        void Start()
        {
            orc.gameObject.SetActive(false);
            aliance.gameObject.SetActive(false);
            archer.gameObject.SetActive(false);
            StartCoroutine(TrackUnit());
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
        }

        IEnumerator TrackUnit()
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
