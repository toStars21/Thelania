﻿using Assets.Code.Scripts.Path;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Node[] Nodes { get; private set; }

    private void Start()
    {
        Nodes = GetComponentsInChildren<Node>();
    }
}
