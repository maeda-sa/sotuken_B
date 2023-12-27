using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum UI_Type
{
    Pause,
    End,
    Select,
    Stage
}

public class MouseCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UI_Type _ui;

    [SerializeField] private int _count = 0;
    [SerializeField] private int _length = 10;
    [SerializeField] private int _width = 10;
    [SerializeField] private Pause _pause;
    [SerializeField] private Select _select;
    [SerializeField] private StageSelect _stage;

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
            case UI_Type.Select:
                if (_length != 10) _select.Length(_length);
                else if (_width != 10) _select.Width(_width);
                break;
            case UI_Type.Stage:
                _stage.Count(_count);
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}