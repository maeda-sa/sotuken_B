using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private GameManager _gm;

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
}
