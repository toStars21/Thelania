using System;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMainMenuHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject StartGameButton;

    [SerializeField]
    public GameObject ExitGameButton;

    private Button _startButtonComponent;
    private Button _exitButtonComponent;

    // Start is called before the first frame update
    void Start()
    {
        var startButtonComponent = StartGameButton.GetComponent<Button>();
        _startButtonComponent = startButtonComponent ?? throw new ArgumentException("Passed GameObject without button component");
        var exitButtonComponent = ExitGameButton.GetComponent<Button>();
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
