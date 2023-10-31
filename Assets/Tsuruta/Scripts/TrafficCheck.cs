using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCheck : MonoBehaviour
{
    public List<TrafficCheck_Child> _tcc;

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
            for(int i = 0; i < _tcc.Count; i++)
            {
                if (_tcc[i].RedCheck())
                {
                    Debug.Log("M†–³Ž‹");
                }
            }
        }
    }
}
