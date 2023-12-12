using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCheck_UI : MonoBehaviour
{
    [SerializeField] private TrafficLight _light;
    [SerializeField] private ViolationWindow _vw;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _vw.TrafficOn(_light);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _vw.TrafficOFF();
        }
    }
}
