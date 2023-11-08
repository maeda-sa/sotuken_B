using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    private float time = 0;
    [SerializeField] private float _span;

    private int _reverse = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time > _span)
        {
            _reverse++;

            if (_reverse == 229)
            {
                gameObject.transform.Translate(-1.145f, 0, 0);
                _reverse = 0;
            }
            else gameObject.transform.Translate(0.005f, 0, 0);

            time = 0;
        }
    }
}
