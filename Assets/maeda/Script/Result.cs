using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//public record ResultSceneParameter(GameManager Game,int StopCount ,int SpeedCount ,int IntrusionCount) : SceneParameterBase;
public class Result :MonoBehaviour
{
    private GameState _gs;
    private int TC = 0,stop = 0, IC = 0 , speed = 0;
    [SerializeField] private TextMeshProUGUI text;
    private bool[] dis = { false, false, false, false };
    private int sum, _count;

    [SerializeField] private List<GameObject> _button;
    [SerializeField] private PlayerInput _player;
    private InputAction _input_right;
    private InputAction _input_left;
    private InputAction _input_check;

    void Start()
    {
        _gs = GameObject.Find("GameState").GetComponent<GameState>();

        TC = _gs.TrafficCountget();
        stop = _gs.stopCountget();
        speed = _gs.speedCountget();
        IC = _gs.intrusionCountget();
        TrafCheck();
        StopCheck();
        SpeedCheck();
        IntrusionCheck();
        text.text += $"合計：{sum + 100}";

        _input_right = _player.actions["Right"];
        _input_left = _player.actions["Left"];
        _input_check = _player.actions["Check"];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _button.Count; i++)
        {
            if (i == _count) _button[i].GetComponent<Image>().enabled = false;
            else _button[i].GetComponent<Image>().enabled = true;
        }

        if (_input_right.WasPressedThisFrame())
        {
            if(_count < _button.Count - 1) _count++;
        }

        if (_input_left.WasPressedThisFrame())
        {
            if (_count > 0) _count--;
        }

        if (_input_check.WasPressedThisFrame())
        {
            switch (_count)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }

    public void TrafCheck()
    {
        if (TC > 0)
        {
            dis[0] = true;
            text.text += $"信号無視：{TC * -10}\n";
            sum += TC * -10;
        }
    }

    public void StopCheck()
    {
        if (stop > 0)
        {
            dis[1] = true;
            text.text += $"一時不停止：{stop * -10}\n";
            sum += stop * -10;
        }
    }

    public void SpeedCheck()
    {
        if (speed > 0)
        {
            dis[2] = true;
            text.text += $"速度違反：{speed * -5}\n";
            sum += speed * -5;
        }
    }

    public void IntrusionCheck()
    {
        if (IC > 0)
        {
            dis[3] = true;
            text.text += $"進入禁止：{IC * -5}\n";
            sum += IC * -5;
        }
    }

    public void Chenge(string SceneName)
    {
        _gs._trafficCount = 0;
        _gs._stopCount = 0;
        _gs._speedCount = 0;
        _gs._intrusionCount = 0;
        Initiate.Fade(SceneName, Color.black, 1.0f);
    }
}
