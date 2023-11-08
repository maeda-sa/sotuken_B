using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCheck_Child : MonoBehaviour
{
    [SerializeField] private TrafficLight _light;

    private bool _blue;

    private void Update()
    {
        if (_light.CarCheck() == LightType.red)
        {
            _blue = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_light.CarCheck() == LightType.blue && other.gameObject.tag == "Player")
        {
            _blue = true;
        }
    }

    public bool BlueCheck()
    {
        return _blue;
    }

    public void CheckReset()
    {
        _blue = false;
    }
}
