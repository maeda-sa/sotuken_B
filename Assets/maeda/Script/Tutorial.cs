using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image image;
    public List<Sprite> Timage;
    [SerializeField] private TextMeshPro text;
    [SerializeField,TextArea]private List<string> Tuttext;
    private int i = 0;

    void Start()
    {
        image.sprite = Timage[i];
        text.text = Tuttext[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void pageUp()
    {
        if (i > Timage.Count)
        {
            i++;
            image.sprite = Timage[i];
            text.text = Tuttext[i];
        }
    }

    private void pageDown()
    {
        if (i < 0)
        {
            i = 0;
            image.sprite = Timage[i];
            text.text = Tuttext[i];
        }else
        {
            i--;
            image.sprite = Timage[i];
            text.text = Tuttext[i];
        }
    }
}
