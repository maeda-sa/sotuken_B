using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//public record ResultSceneParameter(GameManager Game,int StopCount ,int SpeedCount ,int IntrusionCount) : SceneParameterBase;
public class Result :MonoBehaviour
{
    private GameState _gs;
    private int TC = 0,stop = 0, IC = 0 , speed = 0;
    [SerializeField] private TextMeshProUGUI text;
    private bool[] dis = { false, false, false, true };
    private int sum= 0;
    [SerializeField] private GameObject _traffic;
    [SerializeField] private GameObject _nonStop;
    [SerializeField] private GameObject _speed;
    [SerializeField] private GameObject _intru;

    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SE;
    [SerializeField] private Image hanko;
    [SerializeField] private List<Sprite> hankos;
    [SerializeField]private Vector3 targetpos;

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
        hangos();
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
        _traffic.SetActive(dis[0]);
    }

    public void StopCheck()
    {
        if (stop > 0)
        {
            dis[1] = true;
            text.text += $"一時不停止：{stop * -10}\n";
            sum += stop * -10;
        }
        _nonStop.SetActive(dis[1]);
    }

    public void SpeedCheck()
    {
        if (speed > 0)
        {
            dis[2] = true;
            text.text += $"速度違反：{speed * -5}\n";
            sum += speed * -5;
        }
        _speed.SetActive(dis[2]);
    }

    public void IntrusionCheck()
    {
        if (IC > 0)
        {
            dis[3] = true;
            text.text += $"進入禁止：{IC * -5}\n";
            sum += IC * -5;
        }
        _intru.SetActive(dis[3]);
    }

    public void Chenge(string SceneName)
    {
        _gs._trafficCount = 0;
        _gs._stopCount = 0;
        _gs._speedCount = 0;
        _gs._intrusionCount = 0;
        Initiate.Fade(SceneName, Color.black, 1.0f);
    }
    public void Option(GameObject item)
    {
        
            

            SE.Play();
            item.SetActive(true);
        
    }

    public void Back(GameObject item)
    {
        

            SE.Play();
            item.SetActive(false);
        
    }

    public void hangos()
    {
        int sums = int.Parse(text.text);
        if(sums == 100)
        {
            hanko.sprite = hankos[3];
        }else if(sums < 75)
        {
            hanko.sprite = hankos[2];
        }
        else if(sums < 50)
        {
            hanko.sprite = hankos[1];
        }
        else if(sums < 25)
        {
            hanko.sprite = hankos[0];
        }

        hanko.transform.position = Vector3.MoveTowards(hanko.transform.position, targetpos, 5f * Time.deltaTime);
    }
}
