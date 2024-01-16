using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GameState : MonoBehaviour
{
    public static GameState instance;

    [Header("フリープレイ")]
    public bool _practice;
    [Header("信号無視の回数")]
    public int _trafficCount;
    [Header("一時停止無視の回数")]
    public int _stopCount;
    [Header("速度超過の回数")]
    public int _speedCount;
    [Header("侵入禁止無視の回数")]
    public int _intrusionCount;
    [Header("車との衝突")]
    public bool _carCollision;
    [Header("歩行者との衝突")]
    public bool _walkerCollision;

    [Header("ゴールの位置")]
    [SerializeField] private List<Vector3> _pos;
    public Vector3 pos;

    void Awake()
    {
        CheckInstance();
        DontDestroyOnLoad(this.gameObject);
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pos = _pos[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoalPosition(int _goal)
    {
        pos = _pos[_goal];
        Initiate.Fade("MapScene", Color.black, 1.0f);
    }

    public void FreePlay()
    {
        _practice = true;
        Initiate.Fade("MapScene", Color.black, 1.0f);
    }

    public int TrafficCountget()
    {
        return _trafficCount;
    }

    public int stopCountget()
    {
        return _stopCount;
    }

    public int speedCountget()
    {
        return _speedCount;
    }

    public int intrusionCountget()
    {
        return _intrusionCount;
    }
}
