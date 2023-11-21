using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [Header("自転車と車・歩行者")]
    [SerializeField] private GameObject _bike;
    [SerializeField] private List<GameObject> _carwalkers;

    [Header("ミニマップ上の位置")]
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _goal;
    private List<GameObject> _enemys = new List<GameObject>();

    [Header("車・歩行者用のアイコン")]
    [SerializeField] private GameObject _enemyPrefab;

    private GameObject _obj;

    // Start is called before the first frame update
    void Start()
    {
        

        for(int i = 0; i < _carwalkers.Count; i++)
        {
            _obj = Instantiate(_enemyPrefab, 
                new Vector3(_carwalkers[i].transform.position.x , 10001.5f, _carwalkers[i].transform.position.z
                ), Quaternion.identity, transform);
            _enemys.Add(_obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _camera.position = new Vector3(_bike.transform.position.x, _camera.position.y, _bike.transform.position.z);
        _player.position = new Vector3(_bike.transform.position.x, _player.position.y, _bike.transform.position.z);

        for (int i = 0; i < _carwalkers.Count; i++)
        {
            Debug.Log(_enemys);
            _enemys[i].transform.position = new Vector3(_carwalkers[i].transform.position.x, 10001.5f,
                                                        _carwalkers[i].transform.position.z);
        }
    }
}
