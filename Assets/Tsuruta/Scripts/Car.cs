using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private GameManager _gm;
    public CarCheck cc;
    public bool _debug;
    public bool car;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gm = GameObject.Find("GameManager");
        _gm = gm.GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _gm.CarViolation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Traffic" && !car)
        {
            car = true;
            TrafficCheck_Child tc = other.GetComponent<TrafficCheck_Child>();

            if (tc.Light() == LightType.red || tc.Light() == LightType.yellow) cc.Stop();
            if (tc.Light() == LightType.blue) Invoke("TrafficSet", 3);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Traffic")
        {
            TrafficCheck_Child tc = other.GetComponent<TrafficCheck_Child>();

            if (tc.Light() == LightType.blue)
            {
                cc.Accel();
                Invoke("TrafficSet", 3);
            }
        }
    }

    private void TrafficSet()
    {
        car = false;
    }
}
