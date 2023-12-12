using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traffic_UI : MonoBehaviour
{
    TrafficLight tl;

    [SerializeField] private Sprite _blue;
    [SerializeField] private Sprite _yellow;
    [SerializeField] private Sprite _red;

    public void TLSet(TrafficLight _tl)
    {
        tl = _tl;
    }

    void Update()
    {
        switch (tl.CarCheck())
        {
            case LightType.blue:
                gameObject.GetComponent<Image>().sprite = _blue;
                break;
            case LightType.yellow:
                gameObject.GetComponent<Image>().sprite = _yellow;
                break;
            case LightType.red:
                gameObject.GetComponent<Image>().sprite = _red;
                break;
        }
    }
}
