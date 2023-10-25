using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutputBikeSpeed : MonoBehaviour
{
    private CalcVelocityExample _ce;

    [SerializeField]private TextMeshProUGUI speedText = null;

    // Start is called before the first frame update
    void Start()
    {
        _ce = GetComponent<CalcVelocityExample>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = Mathf.Abs(_ce.speed).ToString("00") + "km/h";
    }
}
