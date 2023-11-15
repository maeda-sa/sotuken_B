using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCheck : MonoBehaviour
{
    public List<TrafficCheck_Child> _tcc;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        
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
                    i = 0;
                    _tcc[i].CheckReset();
                    break;
                }
            }

            if(i != 0)
            {
                Debug.Log("M†–³Ž‹");
            }
        }
    }
}
