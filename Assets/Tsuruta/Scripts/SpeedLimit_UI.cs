using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLimit_UI : MonoBehaviour
{
    [SerializeField] private Sprite _30;
    [SerializeField] private Sprite _40;
    [SerializeField] private Sprite _50;
    [SerializeField] private Sprite _60;
    [SerializeField] private Sprite _80;
    [SerializeField] private Sprite _100;

    public void SpeedSet(Signs signs)
    {
        switch (signs.Speed())
        {
            case  30:
                gameObject.GetComponent<Image>().sprite = _30;
                break;
            case  40:
                gameObject.GetComponent<Image>().sprite = _40;
                break;
            case  50:
                gameObject.GetComponent<Image>().sprite = _50;
                break;
            case  60:
                gameObject.GetComponent<Image>().sprite = _60;
                break;
            case  80:
                gameObject.GetComponent<Image>().sprite = _80;
                break;
            case 100:
                gameObject.GetComponent<Image>().sprite = _100;
                break;
        }
    }
}
