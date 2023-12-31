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
    private bool _check;

    private GameManager _gm;
    private CalcVelocityExample cve;

    private void Start()
    {
        GameObject gm = GameObject.Find("GameManager");
        _gm = gm.GetComponent<GameManager>();
    }

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
                _gm.IntrusionViolation();
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
                    if (!_check) _stop = true;
                    break;
                case SignType.limit:
                    if (cve.GetSpeed() > _speedLimit && !_limit)
                    {
                        Debug.Log("速度超過");
                        _gm.SpeedViolation();
                        _limit = true;
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
                if (!_stop && _check)
                {
                    Debug.Log("非停止");
                    _gm.StopViolation();
                }
            }

            _check = false;
            _limit = false;
        }
    }

    public void Check()
    {
        _check = true;
    }

    public float Speed()
    {
        return _speedLimit;
    }

    public SignType Type()
    {
        return _sign;
    }
}
