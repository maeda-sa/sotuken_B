using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameState _gs;

    [Header("©“]Ô")]
    [SerializeField] private Bike _player;

    [Header("M†–³‹‚Ì‰ñ”")]
    [SerializeField] private int _trafficCount;
    [Header("ˆê’â~–³‹‚Ì‰ñ”")]
    [SerializeField] private int _stopCount;
    [Header("‘¬“x’´‰ß‚Ì‰ñ”")]
    [SerializeField] private int _speedCount;
    [Header("N“ü‹Ö~–³‹‚Ì‰ñ”")]
    [SerializeField] private int _intrusionCount;
    [Header("Ô‚Æ‚ÌÕ“Ë")]
    [SerializeField] private bool _carCollision;
    [Header("•àsÒ‚Æ‚ÌÕ“Ë")]
    [SerializeField] private bool _walkerCollision;

    [SerializeField] private GameObject _goal;
    [SerializeField] private ViolationWindow _vw;

    // Start is called before the first frame update
    void Start()
    {
        _gs = GameObject.Find("GameState").GetComponent<GameState>();

        _goal.gameObject.transform.position = _gs.pos;
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
        _gs._carCollision = true;
        _player.OnGoal();
        Initiate.Fade("GameOver", Color.red, 0.25f);
    }

    public void WalkerViolation()
    {
        _walkerCollision = true;
        _gs._walkerCollision = true;
        _player.OnGoal();
        Initiate.Fade("GameOver", Color.black, 0.25f);
    }

    public void PlayerGoal()
    {
        _player.OnGoal();
        _gs._trafficCount = _trafficCount;
        _gs._stopCount = _stopCount;
        _gs._speedCount = _speedCount;
        _gs._intrusionCount = _intrusionCount;
        Initiate.Fade("Result", Color.white, 0.5f);
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
