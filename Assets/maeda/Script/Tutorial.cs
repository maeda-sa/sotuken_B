using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image image;
    public List<Sprite> Timage;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField,TextArea]private List<string> Tuttext;
    [SerializeField] private AudioSource SE;
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

    public void pageUp()
    {
        SE.Play();
        if (i >= Timage.Count-1)
        {
            i = 1;
            image.sprite = Timage[i];
            text.text = Tuttext[1];
            
        }
        else
        {
            i++;
            image.sprite = Timage[i];
            text.text = Tuttext[i];
        }
    }

    public void pageDown()
    {
        SE.Play();
        if (i <= 0)
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
