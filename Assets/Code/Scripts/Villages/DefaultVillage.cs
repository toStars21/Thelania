using System.Collections.Generic;
using Assets.Code.Scripts.Buildings;
using UnityEngine;

namespace Assets.Code.Scripts.Villages
{
    public class DefaultVillage : MonoBehaviour
    {
        [SerializeField] private List<Barrack> barracks;

        [SerializeField] private Ancient ancient;
    }
}
