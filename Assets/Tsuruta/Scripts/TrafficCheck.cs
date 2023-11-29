using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCheck : MonoBehaviour
{
    public List<TrafficCheck_Child> _tcc;

    private int i;

    private GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gm = GameObject.Find("GameManager");
        _gm = gm.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            for(i = 0; i < _tcc.Count; i++)
            {
                if (_tcc[i].BlueCheck())
                {
                    _tcc[i].CheckReset();
                    i = 10;
                    break;
                }
            }

            if(i != 10)
            {
                Debug.Log("�M������");
                _gm.TrafficViolation();
            }
        }
    }
}
