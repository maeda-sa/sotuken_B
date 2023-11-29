using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("�M�������̉�")]
    [SerializeField] private int _trafficCount;
    [Header("�ꎞ��~�����̉�")]
    [SerializeField] private int _stopCount;
    [Header("���x���߂̉�")]
    [SerializeField] private int _speedCount;
    [Header("�N���֎~�����̉�")]
    [SerializeField] private int _intrusionCount;
    [Header("�ԂƂ̏Փ�")]
    [SerializeField] private bool _carCollision;
    [Header("���s�҂Ƃ̏Փ�")]
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
