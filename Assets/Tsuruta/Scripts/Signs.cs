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
                Debug.Log("êNì¸à·îΩ");
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
                        Debug.Log("ë¨ìxí¥âﬂ");
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
                    Debug.Log("îÒí‚é~");
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
