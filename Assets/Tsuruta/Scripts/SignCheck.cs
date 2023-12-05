using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignCheck : MonoBehaviour
{
    [SerializeField] private Signs _sign;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _sign.Check();
        }
    }
}
