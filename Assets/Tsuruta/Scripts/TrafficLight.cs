using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightType
{
    red,
    blue
}

public class TrafficLight : MonoBehaviour
{
    [Header("灯火している色")]
    [SerializeField] private LightType _type;
    private LightType _wtype;

    [Header("経過時間")]
    [SerializeField] private float time;

    [Header("歩行者信号付きか")]
    [SerializeField] private bool _worker;

    [Header("赤信号")]
    [SerializeField] private GameObject _frontRed;
    [SerializeField] private GameObject _backRed;
    [SerializeField] private GameObject _workerRed;

    [Header("黄信号")]
    [SerializeField] private GameObject _frontYellow;
    [SerializeField] private GameObject _backYellow;
    
    [Header("青信号")]
    [SerializeField] private GameObject _frontBlue;
    [SerializeField] private GameObject _backBlue;
    [SerializeField] private GameObject _workerBlue;

    private bool _caution;
    private bool _stop;

    void Start()
    {
        switch (_type)
        {
            case LightType.red:
                _wtype = LightType.red;
                _frontRed.SetActive(true);
                _backRed.SetActive(true);
                if (_worker) _workerRed.SetActive(true);
                break;
            case LightType.blue:
                _wtype = LightType.blue;
                _frontBlue.SetActive(true);
                _backBlue.SetActive(true);
                if (_worker) _workerBlue.SetActive(true);
                break;
        }

        StartCoroutine(WorkerTraffic());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 50)
        {
            _wtype = LightType.red;

            if (_worker)
            {
                _workerBlue.SetActive(false);
                _workerRed.SetActive(true);
            }
        }

        if(time > 57 && time < 60 && !_caution && _type == LightType.blue)
        {
            _caution = true;

            _frontBlue.SetActive(false);
            _backBlue.SetActive(false);

            _frontYellow.SetActive(true);
            _backYellow.SetActive(true);
        }

        if (time > 60 && !_stop)
        {
            _stop = true;

            _frontYellow.SetActive(false);
            _backYellow.SetActive(false);

            _frontRed.SetActive(true);
            _backRed.SetActive(true);

            if (_type == LightType.red) Invoke("Blue", 2f);
            _type = LightType.red;
        }

        if (time > 62)
        {
            time = 0;
            _caution = false;
            _stop = false;
        }
    }

    private void Blue()
    {
        _frontRed.SetActive(false);
        _backRed.SetActive(false);

        _frontBlue.SetActive(true);
        _backBlue.SetActive(true);

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

            if (time > 45 && _worker && _wtype == LightType.blue)
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
