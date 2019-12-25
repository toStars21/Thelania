using UnityEngine;

namespace Assets.Code.Scripts.Path
{
    public class Trail : MonoBehaviour
    {
        public Node[] Nodes { get; private set; }

        private void Start()
        {
            Nodes = GetComponentsInChildren<Node>();
        }
    }
}
