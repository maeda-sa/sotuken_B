using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum UI_Type
{
    Pause,
    End
}

public class MouseCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UI_Type _ui;

    [SerializeField] private int _count = 0;
    [SerializeField] private Pause _pause;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (_ui)
        {
            case UI_Type.Pause:
                _pause.Icon(_count);
                break;
            case UI_Type.End:
                _pause.Check(_count);
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}