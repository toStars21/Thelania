using Assets.Code.Scripts.Players;
using Assets.Code.Scripts.UI.Menus;
using UnityEngine;

namespace Assets.Code.Scripts.Units
{
    public class Unit : MonoBehaviour
    {
        public Player owner;
        public GameHeroMenu menu;
        public UnitTypes Type;

        void OnMouseDown()
        {
            if (MenuManager.CurrentGameHeroMenu != null)
                Destroy(MenuManager.CurrentGameHeroMenu.gameObject);

            menu.unit = this;
            var newMenu = Instantiate(menu, transform);
            menu.gameObject.SetActive(true);
            MenuManager.CurrentGameHeroMenu = newMenu;
        }
    }
}