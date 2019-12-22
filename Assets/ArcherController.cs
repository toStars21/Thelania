using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArcherController : MonoBehaviour
{
    public Camera Camera;
    public NavMeshAgent NavMeshAgent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                NavMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
