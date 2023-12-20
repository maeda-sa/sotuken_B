using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    [Header("M†–³‹‚Ì‰ñ”")]
    [Disable] public int _trafficCount;
    [Header("ˆê’â~–³‹‚Ì‰ñ”")]
    [Disable] public int _stopCount;
    [Header("‘¬“x’´‰ß‚Ì‰ñ”")]
    [Disable] public int _speedCount;
    [Header("N“ü‹Ö~–³‹‚Ì‰ñ”")]
    [Disable] public int _intrusionCount;
    [Header("Ô‚Æ‚ÌÕ“Ë")]
    [Disable] public bool _carCollision;
    [Header("•àsÒ‚Æ‚ÌÕ“Ë")]
    [Disable] public bool _walkerCollision;

    [Header("ƒS[ƒ‹‚ÌˆÊ’u")]
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
