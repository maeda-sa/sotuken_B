using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    [Header("�M�������̉�")]
    [Disable] public int _trafficCount;
    [Header("�ꎞ��~�����̉�")]
    [Disable] public int _stopCount;
    [Header("���x���߂̉�")]
    [Disable] public int _speedCount;
    [Header("�N���֎~�����̉�")]
    [Disable] public int _intrusionCount;
    [Header("�ԂƂ̏Փ�")]
    [Disable] public bool _carCollision;
    [Header("���s�҂Ƃ̏Փ�")]
    [Disable] public bool _walkerCollision;

    [Header("�S�[���̈ʒu")]
    [SerializeField] private List<Vector3> _pos;
    [Disable] public Vector3 pos;

    void Awake()
    {
        CheckInstance();
        DontDestroyOnLoad(gameObject);
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
        Initiate.Fade("", Color.black, 1.0f);
    }
}
