using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCheck_Child : MonoBehaviour
{
    [SerializeField] private TrafficLight _light;

    private float _carSpeed = 50;
    private bool _blue;

    private void Update()
    {
        try
        {
            if (_light.CarCheck() == LightType.red)
            {
                _blue = false;
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
    }

    private void OnTriggerStay(Collider other)
    {
        try
        {
            if (_light.CarCheck() == LightType.red || _light.CarCheck() == LightType.yellow &&
           other.gameObject.tag == "Car")
            {
                CinemachineDollyCart cdc = other.GetComponent<CinemachineDollyCart>();

                cdc.m_Speed = 0;
            }

            if (_light.CarCheck() == LightType.blue && other.gameObject.tag == "Car")
            {
                CinemachineDollyCart cdc = other.GetComponent<CinemachineDollyCart>();

                cdc.m_Speed = _carSpeed;
            }
        } catch(Exception e) { }
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
