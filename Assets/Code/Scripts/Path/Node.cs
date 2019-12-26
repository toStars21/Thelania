using UnityEngine;

namespace Assets.Code.Scripts.Path
{
    public class Node : MonoBehaviour
    {
        private const bool IS_MESH_RENDERED = false;

        public Vector3 Position => transform.position;

        private void Awake()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer == null)
                return;
            meshRenderer.enabled = IS_MESH_RENDERED;
        }
    }
}
