using UnityEngine;

namespace Assets.Code.Scripts.Path
{
    public class TrailHolder : MonoBehaviour
    {
        private Trail[] trails;

        private void Start()
        {
            trails = GetComponentsInChildren<Trail>();
        }

        public Trail GetNearestTrail(Vector3 pos)
        {
            var currentTrail = trails[0];
            var currentMinDistance = Vector3.Distance(pos, currentTrail.Nodes[0].transform.position);
            foreach (var trail in trails)
            {
                foreach (var node in trail.Nodes)
                {
                    var checkingDistance = Vector3.Distance(node.transform.position, pos);
                    if (currentMinDistance > checkingDistance)
                    {
                        currentMinDistance = checkingDistance;
                        currentTrail = trail;
                    }
                }
            }

            return currentTrail;
        }
    }
}
