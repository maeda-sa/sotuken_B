using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCheck_Child : MonoBehaviour
{
    [SerializeField] private TrafficLight _light;

    private float _carSpeed = 20;
    private bool _blue;
    private bool _red;
    private bool _car;

    private void Update()
    {
        try
        {
            if (_light.CarCheck() != LightType.blue)
            {
                _blue = false;
            }
            if (_light.CarCheck() != LightType.red)
            {
                _red = false;
            }
        }
        catch(Exception e) { }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_light.CarCheck() == LightType.blue && other.gameObject.tag == "Player")
        {
            _blue = true;
        }
        if (_light.CarCheck() == LightType.red && other.gameObject.tag == "Player")
        {
            _red = true;
        }
    }

    public bool BlueCheck()
    {
        return _blue;
    }

    public bool RedCheck()
    {
        return _red;
    }

    public LightType Light()
    {
        return _light.CarCheck();
    }

    public void CheckReset()
    {
        _blue = false;
        _red = false;
    }
}
