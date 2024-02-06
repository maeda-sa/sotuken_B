using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] private List<GameObject> bike;
    [SerializeField] private GameObject selectUi;
   
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SESlider;
    [SerializeField]private AudioSource BGM;
    [SerializeField]private AudioSource SE;
    [SerializeField] private AudioClip _se;
    [SerializeField] private TextMeshProUGUI BGMVol;
    [SerializeField] private TextMeshProUGUI SEVol;
    [SerializeField] private PlayerInput _player;
    [SerializeField] private List<GameObject> _lengthObj;
    [SerializeField] private List<GameObject> _widthObj;
    [SerializeField] private GameObject _select;
    [SerializeField] private GameObject _option;
    [SerializeField] private GameObject _sign;
    [SerializeField] private GameObject _tutorial;

    private double bg, se;

    private InputAction _input_up;
    private InputAction _input_down;
    private InputAction _input_right;
    private InputAction _input_left;
    private InputAction _input_check;
    private InputAction _input_cancel;

    private int _length = 0;
    private int _width = 0;
    private GameObject _setObj;

    private void Awake()
    {
        
        
    }

    private void Start()
    {
        for (int i = 0; i < bike.Count; i++)
        {
            bike[i].transform.Rotate(new Vector3(0, 0, 0));
        }

        BGMSlider.value = PlayerPrefs.GetFloat("BgmVol", 0.1f);
        SESlider.value = PlayerPrefs.GetFloat("SeVol", 0.1f);

        BGM.volume = BGMSlider.value;
        SE.volume = SESlider.value;

        _length = 0;
        _width = -10;
        _setObj = _select;

        _input_up = _player.actions["Up"];
        _input_down = _player.actions["Down"];
        _input_right = _player.actions["Right"];
        _input_left = _player.actions["Left"];
        _input_check = _player.actions["Check"];
        _input_cancel = _player.actions["Cancel"];
    }
    private void Update()
    {
        for (int i = 0; i < _lengthObj.Count; i++)
        {
            if (i == _length) _lengthObj[i].GetComponent<Image>().enabled = false;
            else _lengthObj[i].GetComponent<Image>().enabled = true;

            if(_width != -10 && _length != 2) _lengthObj[i].GetComponent<Image>().enabled = true;
        }

        for (int i = 0; i < _widthObj.Count; i++)
        {
            if (i == _width) _widthObj[i].GetComponent<Image>().enabled = false;
            else _widthObj[i].GetComponent<Image>().enabled = true;

            if(_length != -10 && _width != 2) _widthObj[i].GetComponent<Image>().enabled = true;
        }

        for (int i = 0; i < bike.Count-1; i++)
        {
            bike[i].transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        }

        if (_input_down.WasPressedThisFrame())
        {
            if (!_setObj.activeSelf && _length != -10)
            {
                SE.PlayOneShot(_se);
                _width = -10;
                _length++;
                if (_length == 2) _width = 2;
                if (_length == 3) _length = 0;
            }
        }

        if (_input_up.WasPressedThisFrame())
        {
            if (!_setObj.activeSelf && _length != -10)
            {
                SE.PlayOneShot(_se);
                _width = -10;
                _length--;
                if (_length == 2) _width = 2;
                if (_length == -1) _length = 2;
            }
        }

        if (_input_right.WasPressedThisFrame())
        {
            if (!_setObj.activeSelf)
            {
                SE.PlayOneShot(_se);
                if (_width == -10) _width = 1;
                _length = -10;
                _width++;
                if (_width == 2) _length = 2;
                if (_width == 3) _width = 0;
            }
        }

        if (_input_left.WasPressedThisFrame())
        {
            if (!_setObj.activeSelf)
            {
                SE.PlayOneShot(_se);
                if (_width == -10) _width = 2;
                _length = -10;
                _width--;
                if (_width == -1) _width = 2;
                if (_width == 2) _length = 2;
            }
        }

        if (_input_check.WasPressedThisFrame())
        {
            if (!_setObj.activeSelf)
            {
                Option(_setObj);
            }
        }

        if (_input_cancel.WasPressedThisFrame())
        {
            if(_setObj.activeSelf) Back(_setObj);
        }

        if (!_setObj.activeSelf)
        {
            switch (_length)
            {
                case 0:
                    _setObj = _select;
                    break;
                case 1:
                    _setObj = _option;
                    break;
                case 2:
                    break;
                case -10:
                    switch (_width)
                    {
                        case 0:
                            _setObj = _sign;
                            break;
                        case 1:
                            _setObj = _tutorial;
                            break;
                        case 2:
                            break;
                        case -10:
                            break;
                    }
                    break;
            }
        }
    }

    
    public void Option(GameObject item)
    {
        
            if (_length == 2 || _width == 2)
            {
                SE.Play();
                EndGame();
            }
            else
            {
                selectUi.SetActive(false);

                SE.Play();
                item.SetActive(true);
                }
        
    }

    public void Back(GameObject item)
    {

            selectUi.SetActive(true);   
           
            SE.Play();
            item.SetActive(false) ;
        
    }

    public void EndGame()
    {
        
            Debug.Log("アッセンブル");
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

    public void Length(int i)
    {
        _length = i;
        _width = -10;
        if (_length == 2) _width = 2;
    }

    public void Width(int i)
    {
        _width = i;
        _length = -10;
        if (_width == 2) _length = 2;
    }

}
