using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolationWindow : MonoBehaviour
{
    private List<GameObject> _icons = new List<GameObject>();
    private GameObject _icon;

    [SerializeField] private GameObject _trafficIcon;
    [SerializeField] private GameObject _speedIcon;
    [SerializeField] private GameObject _stopIcon;
    [SerializeField] private GameObject _intrusionIcon;

    public void Traffic()
    {
        _icon = Instantiate(_trafficIcon);
        _icon.transform.parent = gameObject.transform;
        _icons.Add(_icon);
    }

    public void Speed()
    {
        _icon = Instantiate(_speedIcon);
        _icon.transform.parent = gameObject.transform;
        _icons.Add(_icon);
    }

    public void Stop()
    {
        _icon = Instantiate(_stopIcon);
        _icon.transform.parent = gameObject.transform;
        _icons.Add(_icon);
    }

    public void Intrusion()
    {
        _icon = Instantiate(_intrusionIcon);
        _icon.transform.parent = gameObject.transform;
        _icons.Add(_icon);
    }
}
