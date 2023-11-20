using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SignType
{
    stop,      // àÍéûí‚é~
    limit,     // ë¨ìxêßå¿
    intrusion  // êNì¸
}

public class Signs : MonoBehaviour
{
    [Header("ïWéØÇÃéÌóﬁ")]
    [SerializeField] private SignType _sign;
    [Header("êßå¿ë¨ìx")]
    [SerializeField] private float _speedLimit;

    private bool _stop;
    private bool _limit;
    private bool _break;

    CalcVelocityExample cve;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cve = other.GetComponent<CalcVelocityExample>();
            _stop  = false;
            _limit = false;
            _break = false;

            if(_sign == SignType.intrusion)
            {
                Debug.Log("êNì¸à·îΩ");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (_sign)
            {
                case SignType.stop:
                    if (cve.GetSpeed() < 1) _stop = true;
                    break;
                case SignType.limit:
                    if (cve.GetSpeed() > _speedLimit)
                    {
                        Debug.Log("ë¨ìxí¥âﬂ");
                    }
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_sign == SignType.stop)
            {
                if (!_stop)
                {
                    Debug.Log("îÒí‚é~");
                }
            }
        }
    }
}
