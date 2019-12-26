using System;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMainMenu : MonoBehaviour
{
    private Button _returnButtonComponent;
    [SerializeField] public GameObject returnButton;
    public GameObject screenMainMenu;

    public void Start()
    {
        var returnButtonComponent = returnButton.GetComponent<Button>();
        _returnButtonComponent =  returnButtonComponent ??
                                    throw new ArgumentException("Passed GameObject without button component");
        _returnButtonComponent.onClick.AddListener(ProcessReturnButtonClick);
    }

    public void ProcessReturnButtonClick()
    {
        gameObject.SetActive(true);
        Instantiate(screenMainMenu, null);
    }
}
