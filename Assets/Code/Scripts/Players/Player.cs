using Assets.Code.Scripts.Color;
using UnityEngine;

namespace Assets.Code.Scripts.Players
{
    public class Player : MonoBehaviour
    {
        public PlayerInfo info;
        public GameObject village;
        public UnityEngine.Color color;

        public void Awake()
        {
            color = ColorManager.GetNextColor();
        }
    }
}
