using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SignType
{
    stop,      // 一時停止
    limit,     // 速度制限
    intrusion  // 侵入
}

public class Signs : MonoBehaviour
{
    [Header("標識の種類")]
    [SerializeField] private SignType _sign;
    [Header("制限速度")]
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
                Debug.Log("侵入違反");
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
                        Debug.Log("速度超過");
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
                    Debug.Log("非停止");
                }
            }
        }
    }
}
