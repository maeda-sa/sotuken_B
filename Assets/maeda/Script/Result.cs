using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//public record ResultSceneParameter(GameManager Game,int StopCount ,int SpeedCount ,int IntrusionCount) : SceneParameterBase;
public class Result :MonoBehaviour
{
    private GameManager GM;
    private int TC = 0,stop = 0, IC = 0 , speed = 0;
    [SerializeField] private TextMeshProUGUI text;
    private bool[] dis = { false, false, false, false };
    private int sum;

    void Start()
    {
        TC = PlayerPrefs.GetInt("TC", 0);
        stop = PlayerPrefs.GetInt("stop", 0);
        speed = PlayerPrefs.GetInt("speed", 0);
        IC = PlayerPrefs.GetInt("IC",0);
        TrafCheck();
        StopCheck();
        SpeedCheck();
        IntrusionCheck();
        text.text += $"���v:{sum + 100}";
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
            text.text += $"�M������:{TC * -10}\n";
            sum += TC * -10;
        }
    }

    public void StopCheck()
    {
        if (stop > 0)
        {
            dis[1] = true;
            text.text += $"�ꎞ�s��~:{stop * -10}\n";
            sum += stop * -10;
        }
    }

    public void SpeedCheck()
    {
        if (speed > 0)
        {
            dis[2] = true;
            text.text += $"���x�ᔽ:{speed * -5}\n";
            sum += speed * -5;
        }
    }

    public void IntrusionCheck()
    {
        if (IC > 0)
        {
            dis[3] = true;
            text.text += $"�i���֎~:{IC * -5}\n";
            sum += IC * -5;
        }
    }

    public void Chenge(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
