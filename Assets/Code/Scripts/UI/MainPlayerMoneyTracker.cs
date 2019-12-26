using System.Collections;
using Assets.Code.Scripts.Players;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Scripts.UI
{
    public class MainPlayerMoneyTracker : MonoBehaviour
    {
        public Text Money;

        void Start()
        {
            StartCoroutine(TrackMoney());
        }

        private IEnumerator TrackMoney()
        {
            while (true)
            {
                string money = PlayersManager.MainPlayer?.money.ToString() ?? "undefined";
                Money.text = money;

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
