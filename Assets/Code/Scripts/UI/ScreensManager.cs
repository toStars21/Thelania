using UnityEngine;

namespace Assets.Code.Scripts.UI
{
    internal class ScreensManager : MonoBehaviour
    {
        public GameObject mainMenuScreen;

        private void Start()
        {
            Instantiate(mainMenuScreen, transform);
        }
    }
}