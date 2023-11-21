using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerCheck_Child : MonoBehaviour
{
    private string _tagName;

    private void OnTriggerStay(Collider other)
    {
        _tagName = other.gameObject.tag;
        Debug.Log(_tagName);
    }

    public string GetTag()
    {
        return _tagName;
    }
}
