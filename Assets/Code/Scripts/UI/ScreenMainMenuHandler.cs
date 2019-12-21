using System;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMainMenuHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject startGameButton;

    [SerializeField]
    public GameObject exitGameButton;

    private Button _startButtonComponent;
    private Button _exitButtonComponent;

    // Start is called before the first frame update
    void Start()
    {
        var startButtonComponent = startGameButton.GetComponent<Button>();
        _startButtonComponent = startButtonComponent ?? throw new ArgumentException("Passed GameObject without button component");
        var exitButtonComponent = exitGameButton.GetComponent<Button>();
        _exitButtonComponent = exitButtonComponent ?? throw new ArgumentException("Passed GameObject without button component");

        _startButtonComponent.onClick.AddListener(ProcessStartGameButtonClick);
        _exitButtonComponent.onClick.AddListener(ProcessExitGameButtonClick);
    }

    private void ProcessStartGameButtonClick()
    {
        gameObject.SetActive(false);
    }

    private void ProcessExitGameButtonClick()
    {
        Application.Quit();
    }
}
