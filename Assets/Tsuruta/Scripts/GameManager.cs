using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("信号無視の回数")]
    [SerializeField] private int _trafficCount;
    [Header("一時停止無視の回数")]
    [SerializeField] private int _stopCount;
    [Header("速度超過の回数")]
    [SerializeField] private int _speedCount;
    [Header("侵入禁止無視の回数")]
    [SerializeField] private int _intrusionCount;
    [Header("車との衝突")]
    [SerializeField] private bool _carCollision;
    [Header("歩行者との衝突")]
    [SerializeField] private bool _walkerCollision;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrafficViolation()
    {
        _trafficCount++;
    }

    public void StopViolation()
    {
        _stopCount++;
    }

    public void SpeedViolation()
    {
        _speedCount++;
    }

    public void IntrusionViolation()
    {
        _intrusionCount++;
    }

    public void CarViolation()
    {
        _carCollision = true;
    }

    public void WalkerViolation()
    {
        _walkerCollision = true;
    }
}
