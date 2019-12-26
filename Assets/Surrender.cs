using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Surrender : MonoBehaviour
    {
        private Button _surrenderButtonComponent;
        [SerializeField] private GameObject surrenderButton;
        public GameObject defeatMenu;

        public void Start()
        {
            var surrenderButtonComponent = surrenderButton.GetComponent<Button>();
            _surrenderButtonComponent = surrenderButtonComponent ??
                                     throw new ArgumentException("Passed GameObject without button component");
            _surrenderButtonComponent.onClick.AddListener(ProcessReturnButtonClick);
        }

        public void ProcessReturnButtonClick()
        {
            gameObject.SetActive(true);
            Instantiate(defeatMenu, null);
            gameObject.SetActive(false);
        }
    }
}
