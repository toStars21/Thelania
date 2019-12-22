using System;
using Assets.Code.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Scripts.UI.Screens
{
    public class ScreenMainMenuHandler : MonoBehaviour
    {
        private Button _exitButtonComponent;

        private Button _startButtonComponent;

        [SerializeField] public GameObject exitGameButton;

        [SerializeField] public GameObject startGameButton;

        [SerializeField] public GameObject gameManager;

        // Start is called before the first frame update
        private void Start()
        {
            var startButtonComponent = startGameButton.GetComponent<Button>();
            _startButtonComponent = startButtonComponent ??
                                    throw new ArgumentException("Passed GameObject without button component");
            var exitButtonComponent = exitGameButton.GetComponent<Button>();
            _exitButtonComponent = exitButtonComponent ??
                                   throw new ArgumentException("Passed GameObject without button component");

            _startButtonComponent.onClick.AddListener(ProcessStartGameButtonClick);
            _exitButtonComponent.onClick.AddListener(ProcessExitGameButtonClick);
        }

        private void ProcessStartGameButtonClick()
        {
            gameObject.SetActive(false);
            Instantiate(gameManager, null);
        }

        private void ProcessExitGameButtonClick()
        {
            Application.Quit();
        }
    }
}