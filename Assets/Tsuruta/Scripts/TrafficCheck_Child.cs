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
        try
        {
            if (_light.CarCheck() == LightType.red || _light.CarCheck() == LightType.yellow &&
                other.gameObject.tag == "Car")
            {
                if (!other.GetComponent<Car>().car)
                {
                    CinemachineDollyCart cdc = other.GetComponent<CinemachineDollyCart>();

                    cdc.m_Speed = 0;
                }
            }
        } catch (Exception e) { }
    }


    private void OnTriggerStay(Collider other)
    {
        try
        {
            if (_light.CarCheck() == LightType.blue && other.gameObject.tag == "Car")
            {
                CinemachineDollyCart cdc = other.GetComponent<CinemachineDollyCart>();

                cdc.m_Speed = _carSpeed;
                other.GetComponent<Car>().car = true;
            }
        } catch(Exception e) { }
    }

    private void OnTriggerExit(Collider other)
    {
        try
        {
            if (_light.CarCheck() == LightType.red || _light.CarCheck() == LightType.yellow &&
                other.gameObject.tag == "Car")
            {
                other.GetComponent<Car>().car = false;
            }
        } catch (Exception e) { }
    }

    public bool BlueCheck()
    {
        return _blue;
    }

    public bool RedCheck()
    {
        return _red;
    }

    public void CheckReset()
    {
        _blue = false;
        _red = false;
    }
}
