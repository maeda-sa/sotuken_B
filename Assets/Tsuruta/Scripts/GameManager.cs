using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("���]��")]
    [SerializeField] private Bike _player;

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
        _player.OnGoal();
    }

    public void WalkerViolation()
    {
        _walkerCollision = true;
        _player.OnGoal();
    }

    public void PlayerGoal()
    {
        _player.OnGoal();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("TC", _trafficCount);
        PlayerPrefs.SetInt("stop", _stopCount);
        PlayerPrefs.SetInt("speed", _speedCount);
        PlayerPrefs.SetInt("IC", _intrusionCount);
        PlayerPrefs.Save();
    }
}
