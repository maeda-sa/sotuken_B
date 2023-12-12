using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign_UI : MonoBehaviour
{
    [SerializeField] private Signs _signs;
    [SerializeField] private ViolationWindow _vw;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch (_signs.Type())
            {
                case SignType.limit:
                    _vw.SpeedOn(_signs);
                    break;
                case SignType.stop:
                    _vw.StopOn();
                    break;
                case SignType.intrusion:
                    _vw.IntrusionOn();
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (_signs.Type())
            {
                case SignType.limit:
                    _vw.SpeedOFF();
                    break;
                case SignType.stop:
                    _vw.StopOFF();
                    break;
                case SignType.intrusion:
                    _vw.IntrusionOFF();
                    break;
            }
        }
    }
}
