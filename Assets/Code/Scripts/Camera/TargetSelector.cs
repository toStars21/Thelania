﻿using UnityEngine;

namespace Assets.Code.Scripts.Camera
{
    [RequireComponent(typeof(RTS_Camera))]
    public class TargetSelector : MonoBehaviour
    {
        private RTS_Camera cam;
        private new UnityEngine.Camera camera;
        public string targetsTag;

        private void Start()
        {
            cam = gameObject.GetComponent<RTS_Camera>();
            camera = gameObject.GetComponent<UnityEngine.Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag(targetsTag))
                        cam.SetTarget(hit.transform);
                    else
                        cam.ResetTarget();
                }
            }
        }
    }
}