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
    [Header("���΂��Ă���F")]
    [SerializeField] private LightType _type;

    [Header("�o�ߎ���")]
    [SerializeField] private float time;

    [Header("���s�ҐM���t����")]
    [SerializeField] private bool _worker;

    [Header("�ԐM��")]
    [SerializeField] private GameObject _frontRed;
    [SerializeField] private GameObject _backRed;
    [SerializeField] private GameObject _workerRed;

    [Header("���M��")]
    [SerializeField] private GameObject _frontYellow;
    [SerializeField] private GameObject _backYellow;
    
    [Header("�M��")]
    [SerializeField] private GameObject _frontBlue;
    [SerializeField] private GameObject _backBlue;
    [SerializeField] private GameObject _workerBlue;

    // [Header("�M����������")]
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
