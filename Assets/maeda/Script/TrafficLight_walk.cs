using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TrafficLight_walk : MonoBehaviour
{
    [Header("���΂��Ă���F")]
    [SerializeField] private LightType _type;
    private LightType _wtype;

    [Header("�o�ߎ���")]
    [SerializeField] private float time;

    [Header("�؂�ւ�鎞��")]
    [SerializeField] private float change;

    [Header("���s�ҐM���t����")]
    [SerializeField] private bool _worker;

    [Header("�ԐM��")]
    [SerializeField] private GameObject _workerRed;

    
    
    [Header("�M��")]
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
            // �Ԑ�
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
