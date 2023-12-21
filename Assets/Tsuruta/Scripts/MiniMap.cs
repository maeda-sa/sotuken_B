using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [Header("自転車と車・歩行者")]
    [SerializeField] private GameObject _bike;
    [SerializeField] private List<GameObject> _carwalkers;

    [Header("信号")]
    [SerializeField] private List<GameObject> _traffics;

    [Header("一時停止")]
    [SerializeField] private List<GameObject> _stops;

    [Header("速度制限")]
    [SerializeField] private List<GameObject> _limits;

    [Header("侵入禁止")]
    [SerializeField] private List<GameObject> _intrusions;

    [Header("ミニマップ上の位置")]
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _goal;
    private List<GameObject> _enemys = new List<GameObject>();
    private List<GameObject> _trafficSigns = new List<GameObject>();
    private List<GameObject> _stopSigns = new List<GameObject>();
    private List<GameObject> _limitSigns = new List<GameObject>();
    private List<GameObject> _intrusionSigns = new List<GameObject>();

    [Header("車・歩行者用のアイコン")]
    [SerializeField] private GameObject _enemyPrefab;

    [Header("信号のアイコン")]
    [SerializeField] private GameObject _trafficPrefab;
    [SerializeField] private Sprite _blue;
    [SerializeField] private Sprite _yellow;
    [SerializeField] private Sprite _red;

    [Header("一時停止のアイコン")]
    [SerializeField] private GameObject _stopPrefab;

    [Header("速度制限のアイコン")]
    [SerializeField] private GameObject _limitPrefab;

    [Header("侵入禁止のアイコン")]
    [SerializeField] private GameObject _intrusionPrefab;

    [Header("ゴールの位置")]
    [SerializeField] private GameObject _goalPos;
    [SerializeField] private bool _map;

    private GameObject _obj;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            for (int i = 0; i < _carwalkers.Count; i++)
            {
                _obj = Instantiate(_enemyPrefab,
                    new Vector3(_carwalkers[i].transform.position.x, _carwalkers[i].transform.position.y, _carwalkers[i].transform.position.z
                    ), Quaternion.identity, transform);
                _enemys.Add(_obj);
            }
        }
        catch(Exception ex) { }

        try
        {
            for (int i = 0; i < _traffics.Count; i++)
            {
                _obj = Instantiate(_trafficPrefab,
                    new Vector3(_traffics[i].transform.position.x, _traffics[i].transform.position.y, _traffics[i].transform.position.z
                    ), Quaternion.Euler(-90, 0, 0) , transform);
                _trafficSigns.Add(_obj);
            }
        }
        catch (Exception ex) { }

        try
        {
            for (int i = 0; i < _stops.Count; i++)
            {
                _obj = Instantiate(_stopPrefab,
                    new Vector3(_stops[i].transform.position.x, _stops[i].transform.position.y, _stops[i].transform.position.z
                    ), Quaternion.Euler(-90, 0, 0), transform);
                _stopSigns.Add(_obj);
            }
        }
        catch (Exception ex) { }

        try
        {
            for (int i = 0; i < _limits.Count; i++)
            {
                _obj = Instantiate(_limitPrefab,
                    new Vector3(_limits[i].transform.position.x, _limits[i].transform.position.y, _limits[i].transform.position.z
                    ), Quaternion.Euler(-90, 0, 0), transform);
                _limitSigns.Add(_obj);
            }
        }
        catch (Exception ex) { }

        try
        {
            for (int i = 0; i < _intrusions.Count; i++)
            {
                _obj = Instantiate(_intrusionPrefab,
                    new Vector3(_intrusions[i].transform.position.x, _intrusions[i].transform.position.y, _intrusions[i].transform.position.z
                    ), Quaternion.Euler(-90, 0, 0), transform);
                _intrusionSigns.Add(_obj);
            }
        }
        catch (Exception ex) { }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            _camera.position = new Vector3(_bike.transform.position.x, _camera.position.y, _bike.transform.position.z);
        } catch(Exception ex) { }
        
        _player.position = new Vector3(_bike.transform.position.x, _bike.transform.position.y, _bike.transform.position.z);
        _player.rotation = Quaternion.Euler(90, _bike.transform.eulerAngles.y, 0);
        // Debug.Log(_bike.transform.rotation.y);
        if(_map) _goal.position = new Vector3(_goalPos.transform.position.x, _goalPos.transform.position.y + 5, _goalPos.transform.position.z);

        try
        {
            for (int i = 0; i < _carwalkers.Count; i++)
            {
                // Debug.Log(_enemys);
                _enemys[i].transform.position = new Vector3(_carwalkers[i].transform.position.x, _enemys[i].transform.position.y,
                                                            _carwalkers[i].transform.position.z);
            }

            for (int i = 0; i < _traffics.Count; i++)
            {
                TrafficLight tl = _traffics[i].GetComponent<TrafficLight>();
                switch (tl.CarCheck())
                {
                    case LightType.blue:
                        _trafficSigns[i].GetComponent<SpriteRenderer>().sprite = _blue;
                        break;
                    case LightType.yellow:
                        _trafficSigns[i].GetComponent<SpriteRenderer>().sprite = _yellow;
                        break;
                    case LightType.red:
                        _trafficSigns[i].GetComponent<SpriteRenderer>().sprite = _red;
                        break;
                }
            }
        }
        catch (Exception ex) { }
    }

    public Transform GetGoal()
    {
        return _goalPos.transform;
    }
}
