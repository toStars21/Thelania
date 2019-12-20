using System.Timers;
using UnityEngine;

public class ArcherBuilding : MonoBehaviour
{
    private int count;
    public GameObject _archerPrototype;

    private Timer _factory;

    void Start()
    {
        _factory = new Timer(3000) {AutoReset = true, Enabled = true};

        _factory.Elapsed += (_, __) => { Instantiate(_archerPrototype, transform); };

        //_factory.Start();
    }
}
