using UnityEngine;

public class Trail : MonoBehaviour
{
    public Transform[] nodes;

    private void Start()
    {
        nodes = GetComponentsInChildren<Transform>();
    }
}
