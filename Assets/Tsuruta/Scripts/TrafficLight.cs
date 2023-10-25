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

    // [Header("信号無視判定")]
    // [SerializeField] private List<BoxCollider> stopBc;
    // [SerializeField] private BoxCollider goBc;
    // [SerializeField] private TrafficLight tl;

    private bool _caution;

    void Start()
    {
        switch (_type)
        {
            case LightType.red:
                _frontRed.SetActive(true);
                _backRed.SetActive(true);
                if (_worker) _workerRed.SetActive(true);
                break;
            case LightType.blue:
                _frontBlue.SetActive(true);
                _backBlue.SetActive(true);
                if (_worker) _workerBlue.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


    }
}
