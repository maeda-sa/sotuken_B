using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GameState : MonoBehaviour
{
    public static GameState instance;

    [Header("M†–³‹‚Ì‰ñ”")]
    public int _trafficCount;
    [Header("ˆê’â~–³‹‚Ì‰ñ”")]
    public int _stopCount;
    [Header("‘¬“x’´‰ß‚Ì‰ñ”")]
    public int _speedCount;
    [Header("N“ü‹Ö~–³‹‚Ì‰ñ”")]
    public int _intrusionCount;
    [Header("Ô‚Æ‚ÌÕ“Ë")]
    public bool _carCollision;
    [Header("•àsÒ‚Æ‚ÌÕ“Ë")]
    public bool _walkerCollision;

    [Header("ƒS[ƒ‹‚ÌˆÊ’u")]
    [SerializeField] private List<Vector3> _pos;
    public Vector3 pos;

    void Awake()
    {
        CheckInstance();
        //DontDestroyOnLoad(this.gameObject);
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
