using UnityEngine;

public class MoveX : MonoBehaviour
{
    public Transform transform;

    void Update()
    {
        transform.position = new Vector3(transform.position.x - (10 * Time.deltaTime), transform.position.y, transform.position.z);
    }
}