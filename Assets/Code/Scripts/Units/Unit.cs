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

        private void Start()
        {
            var meshRenderComponents = GetComponentsInChildren<MeshRenderer>();
            foreach (var meshRender in meshRenderComponents)
            {
                //meshRender.material.color = owner.color;
            }

            var skinMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            skinMeshRenderer.material.color = owner.color;
        }

        private void OnMouseDown()
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