using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private Bike _bike;
    [SerializeField] private PlayerInput _player;

    [Header("ポーズ画面")]
    [SerializeField] private GameObject _window;
    [SerializeField] private List<GameObject> _icons;
    [SerializeField] private GameObject _mapwindow;
    [SerializeField] private GameObject _checkwindow;
    [SerializeField] private List<GameObject> _yesno;
    [SerializeField] private GameObject _option;

    [Header("選択時の効果音")]
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _ac;

    private InputAction _input_pause;
    private InputAction _input_up;
    private InputAction _input_down;
    private InputAction _input_right;
    private InputAction _input_left;
    private InputAction _input_check;
    private InputAction _input_cancel;

    private int _iconCount = 0;
    private int _checkCount = 1;
    private bool _map;
    private bool _end;
    private bool _pause = true;
    private bool _pauseCheck;

    // Start is called before the first frame update
    void Start()
    {
        _window.SetActive(false);
        
        _input_pause = _player.actions["Pause"];
        _input_up = _player.actions["Up"];
        _input_down = _player.actions["Down"];
        _input_right = _player.actions["Right"];
        _input_left = _player.actions["Left"];
        _input_check = _player.actions["Check"];
        _input_cancel = _player.actions["Cancel"];
    }

    // Update is called once per frame
    void Update()
    {
        if (_pause)
        {
            for (int i = 0; i < _icons.Count; i++)
            {
                if (i == _iconCount) _icons[i].GetComponent<Image>().enabled = false;
                else _icons[i].GetComponent<Image>().enabled = true;
            }

            for (int i = 0; i < _yesno.Count; i++)
            {
                if (i == _checkCount) _yesno[i].GetComponent<Image>().enabled = true;
                else _yesno[i].GetComponent<Image>().enabled = false;
            }

            if (_input_pause.WasPressedThisFrame())
            {
                if (_pauseCheck && !_map && !_end)
                {
                    _as.PlayOneShot(_ac);
                    
                    _bike.OffGoal();
                    Time.timeScale = 1;
                    _window.SetActive(false);
                    _pauseCheck = false;
                }
                else if(!_map && !_end)
                {
                    _as.PlayOneShot(_ac);

                    _bike.OnGoal();
                    Time.timeScale = 0;
                    _iconCount = 0;
                    _window.SetActive(true);
                    _pauseCheck = true;
                }
            }

            if (_input_down.WasPressedThisFrame())
            {
                if (_pauseCheck && !_map)
                {
                    _iconCount++;
                    if (_iconCount == _icons.Count) _iconCount = 0;
                }
            }

            if (_input_up.WasPressedThisFrame())
            {
                if (_pauseCheck && !_map)
                {
                    _iconCount--;
                    if (_iconCount < 0) _iconCount = _icons.Count - 1;
                }
            }

            if (_input_right.WasPressedThisFrame())
            {
                if (_end)
                {
                    _yesno[_checkCount].GetComponent<Image>().enabled = false;

                    _checkCount++;
                    if (_checkCount > 1) _checkCount = 0;

                    _yesno[_checkCount].GetComponent<Image>().enabled = true;
                }
            }

            if (_input_left.WasPressedThisFrame())
            {
                if (_end)
                {
                    _yesno[_checkCount].GetComponent<Image>().enabled = false;

                    _checkCount--;
                    if (_checkCount < 0) _checkCount = 1;

                    _yesno[_checkCount].GetComponent<Image>().enabled = true;
                }
            }

            if (_input_check.WasPressedThisFrame())
            {
                if (_pauseCheck)
                {
                    _as.PlayOneShot(_ac);

                    if (_map)
                    {
                        MapClose();
                        return;
                    }

                    if (_end)
                    {
                        switch (_checkCount)
                        {
                            case 0:
                                Yes();
                                break;
                            case 1:
                                No();
                                break;
                        }
                        return;
                    }

                    if(!_map && !_end)
                    {
                        switch (_iconCount)
                        {
                            case 0:
                                Close();
                                break;
                            case 1:
                                Map();
                                break;
                            case 2:
                                ReStart();
                                break;
                            case 3:
                                Option();
                                break;
                            case 4:
                                End();
                                break;
                        }
                    }
                }
            }

            if (_input_cancel.WasPressedThisFrame())
            {
                if (_pauseCheck && !_map)
                {
                    _bike.OffGoal();
                    Time.timeScale = 1;
                    _window.SetActive(false);
                    _pauseCheck = false;
                }
            }
        }
    }

    public void Close()
    {
        _bike.OffGoal();
        Time.timeScale = 1;
        _window.SetActive(false);
        _pauseCheck = false;
    }

    public void Map()
    {
        _mapwindow.SetActive(true);
        _map = true;
        _iconCount = 0;
        _window.SetActive(false);
    }

    public void MapClose()
    {
        _mapwindow.SetActive(false);
        _map = false;
        _window.SetActive(true);
    }

    public void ReStart()
    {
        Time.timeScale = 1;
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1.0f);
    }

    public void Option()
    {
        _option.SetActive(true);
    }

    public void End()
    {
        _checkwindow.SetActive(true);
        _yesno[0].GetComponent<Image>().enabled = false;
        _yesno[1].GetComponent<Image>().enabled = true;
        _end = true;
        _iconCount = 0;
        _window.SetActive(false);
    }

    public void Yes()
    {
        Time.timeScale = 1;
        Initiate.Fade("Select", Color.black, 1.0f);
    }

    public void No()
    {
        _checkwindow.SetActive(false);
        _checkCount = 1;
        _end = false;
        _window.SetActive(true);
    }

    public void NoPause()
    {
        _pause = false;
    }

    public void Icon(int _count)
    {
        _iconCount = _count;
    }

    public void Check(int _count)
    {
        _checkCount = _count;
    }
}
