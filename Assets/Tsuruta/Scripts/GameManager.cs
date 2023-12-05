using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("自転車")]
    [SerializeField] private Bike _player;

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

    [SerializeField] private ViolationWindow _vw;

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
        _vw.Traffic();
    }

    public void StopViolation()
    {
        _stopCount++;
        _vw.Stop();
    }

    public void SpeedViolation()
    {
        _speedCount++;
        _vw.Speed();
    }

    public void IntrusionViolation()
    {
        _intrusionCount++;
        _vw.Intrusion();
    }

    public void CarViolation()
    {
        _carCollision = true;
    }

    public void WalkerViolation()
    {
        _walkerCollision = true;
    }

    public void PlayerGoal()
    {
        _player.OnGoal();
    }
}
