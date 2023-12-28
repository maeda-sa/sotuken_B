using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image image;
    public List<Sprite> Timage;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField,TextArea]private List<string> Tuttext;
    [SerializeField] private List<GameObject> _buttons;
    [SerializeField] private AudioSource SE;
    [SerializeField] private PlayerInput _player;
    private int i = 0;

    private InputAction _input_right;
    private InputAction _input_left;

    void Start()
    {
        i = 0;
        image.sprite = Timage[i];
        text.text = Tuttext[i];

        _input_right = _player.actions["Right"];
        _input_left = _player.actions["Left"];
    }

    // Update is called once per frame
    void Update()
    {
        if (_input_right.WasPressedThisFrame())
        {
            SE.Play();
            if (i >= Timage.Count - 1)
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

        if (_input_left.WasPressedThisFrame())
        {
            SE.Play();
            if (i <= 0)
            {
                i = 0;
                image.sprite = Timage[i];
                text.text = Tuttext[i];
            }
            else
            {
                i--;
                image.sprite = Timage[i];
                text.text = Tuttext[i];
            }
        }

        if (i == 0) _buttons[0].SetActive(false);
        else _buttons[0].SetActive(true);

        if (i == Timage.Count - 1) _buttons[1].SetActive(false);
        else _buttons[1].SetActive(true);
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
