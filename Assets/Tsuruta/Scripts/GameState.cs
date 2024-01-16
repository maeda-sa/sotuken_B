using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GameState : MonoBehaviour
{
    public static GameState instance;

    [Header("�t���[�v���C")]
    public bool _practice;
    [Header("�M�������̉�")]
    public int _trafficCount;
    [Header("�ꎞ��~�����̉�")]
    public int _stopCount;
    [Header("���x���߂̉�")]
    public int _speedCount;
    [Header("�N���֎~�����̉�")]
    public int _intrusionCount;
    [Header("�ԂƂ̏Փ�")]
    public bool _carCollision;
    [Header("���s�҂Ƃ̏Փ�")]
    public bool _walkerCollision;

    [Header("�S�[���̈ʒu")]
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
