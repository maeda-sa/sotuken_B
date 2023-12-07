using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TrafficLight_walk : MonoBehaviour
{
    [Header("灯火している色")]
    [SerializeField] private LightType _type;
    private LightType _wtype;

    [Header("経過時間")]
    [SerializeField] private float time;

    [Header("切り替わる時間")]
    [SerializeField] private float change;

    [Header("歩行者信号付きか")]
    [SerializeField] private bool _worker;

    [Header("赤信号")]
    [SerializeField] private GameObject _workerRed;

    
    
    [Header("青信号")]
    [SerializeField] private GameObject _workerBlue;


    private bool _caution;
    private bool _stop;

    void Start()
    {
        switch (_type)
        {
            case LightType.red:
                _wtype = LightType.red;
                if (_worker) _workerRed.SetActive(true);
                break;
            case LightType.blue:
                _wtype = LightType.blue;
                if (_worker) _workerBlue.SetActive(true);
                break;
        }

        StartCoroutine(TrafficLightCoRoutine());
        StartCoroutine(WorkerTraffic());
    }

    // Update is called once per frame
    void Update()
    {
        SetTrafficLightState(_type);

        time += Time.deltaTime;

        if (time > 32) time = 0;
    }

    private IEnumerator TrafficLightCoRoutine()
    {
        while (true)
        {
            // 車青
            yield return new WaitForSeconds(change - 10);

            _wtype = LightType.red;

            if (_worker)
            {
                _workerBlue.SetActive(false);
                _workerRed.SetActive(true);
            }

            yield return new WaitForSeconds(7);

            if(_type == LightType.blue) _type = LightType.yellow;

            yield return new WaitForSeconds(3);

            if (_type == LightType.red) Invoke("Blue", 2f);
            _type = LightType.red;

            yield return new WaitForSeconds(2);
        }
    }

    private void SetTrafficLightState(LightType lightType)
    {
        bool isBlue = lightType == LightType.blue;
        bool isYellow = lightType == LightType.yellow;
        bool isRed = lightType == LightType.red;

        
    }




    private void Blue()
    {
        if (_worker)
        {
            _workerRed.SetActive(false);
            _workerBlue.SetActive(true);
        }

        _type = LightType.blue;
        _wtype = LightType.blue;
    }

    IEnumerator WorkerTraffic()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (time > 15 && _worker && _wtype == LightType.blue)
            {
                if(_workerBlue.activeSelf) _workerBlue.SetActive(false);
                else _workerBlue.SetActive(true);
            }
        }
    }

    public LightType CarCheck()
    {
        return _type;
    }

    public LightType WorkerCheck()
    {
        return _wtype;
    }
}
