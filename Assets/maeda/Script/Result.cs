using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//public record ResultSceneParameter(GameManager Game,int StopCount ,int SpeedCount ,int IntrusionCount) : SceneParameterBase;
public class Result :MonoBehaviour
{
    private GameState _gs;
    private int TC = 0,stop = 0, IC = 0 , speed = 0;
    [SerializeField] private TextMeshProUGUI text;
    private bool[] dis = { false, false, false, false };
    private int sum;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
