using UnityEngine;

namespace Assets.Code.Scripts
{
    public class MoveX : MonoBehaviour
    {
        public Transform transform;

        void Update()
        {
            transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        }
    }
}