using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCheck_Child : MonoBehaviour
{
    [SerializeField] private TrafficLight _light;

    private bool _red;

    private void Update()
    {
        if (_light.CarCheck() == LightType.blue)
        {
            _red = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_light.CarCheck() == LightType.red && other.gameObject.tag == "Player")
        {
            _red = true;
        }
    }

    public bool RedCheck()
    {
        return _red;
    }
}
