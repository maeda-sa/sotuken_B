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

            switch (_sign)
            {
                case SignType.stop :
                    StopCheck();
                    break;
                case SignType.limit:
                    LimitCheck();
                    break;
                case SignType.intrusion:
                    Debug.Log("êNì¸à·îΩ");
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (_sign)
            {
                case SignType.stop:
                    if (!_stop)
                    {
                        Debug.Log("îÒí‚é~");
                    }
                    break;
                case SignType.limit:
                    if (_limit)
                    {
                        Debug.Log("ë¨ìxí¥âﬂ");
                    }
                    break;
            }

            _break = true;
        }
    }

    private void StopCheck()
    {
        while (!_stop)
        {
            if (cve.GetSpeed() < 1) _stop = true;
            if (_break) break;
        }
    }

    private void LimitCheck()
    {
        while (!_limit)
        {
            if (cve.GetSpeed() > _speedLimit) _limit = true;
            if (_break) break;
        }
    }
}
