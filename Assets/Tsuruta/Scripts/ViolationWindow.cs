using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolationWindow : MonoBehaviour
{
    private List<GameObject> _icons = new List<GameObject>();
    private GameObject _icon;

    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _se;

    [SerializeField] private GameObject _trafficIcon;
    [SerializeField] private GameObject _speedIcon;
    [SerializeField] private GameObject _stopIcon;
    [SerializeField] private GameObject _intrusionIcon;

    public void Traffic()
    {
        _as.PlayOneShot(_se);
        _icon = Instantiate(_trafficIcon);
        _icon.transform.parent = gameObject.transform;
        _icons.Add(_icon);
    }

    public void TrafficOn(TrafficLight tl)
    {
        _trafficIcon.SetActive(true);
        _trafficIcon.GetComponent<Traffic_UI>().TLSet(tl);
    }

    public void TrafficOFF()
    {
        _trafficIcon.SetActive(false);
    }

    public void Speed()
    {
        _as.PlayOneShot(_se);
        _icon = Instantiate(_speedIcon);
        _icon.transform.parent = gameObject.transform;
        _icons.Add(_icon);
    }

    public void SpeedOn(Signs sign)
    {
        _speedIcon.SetActive(true);
        _speedIcon.GetComponent<SpeedLimit_UI>().SpeedSet(sign);
    }

    public void SpeedOFF()
    {
        _speedIcon.SetActive(false);
    }

    public void Stop()
    {
        _as.PlayOneShot(_se);
        _icon = Instantiate(_stopIcon);
        _icon.transform.parent = gameObject.transform;
        _icons.Add(_icon);
    }

    public void StopOn()
    {
        _stopIcon.SetActive(true);
    }

    public void StopOFF()
    {
        _stopIcon.SetActive(false);
    }

    public void Intrusion()
    {
        _as.PlayOneShot(_se);
        _icon = Instantiate(_intrusionIcon);
        _icon.transform.parent = gameObject.transform;
        _icons.Add(_icon);
    }

    public void IntrusionOn()
    {
        _intrusionIcon.SetActive(true);
    }

    public void IntrusionOFF()
    {
        _intrusionIcon.SetActive(false);
    }
}
