using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Asset.maeda.script;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    private GameState _gs;

    public string _sceneName;
    [SerializeField] private List<TextMeshProUGUI> stageName;
    [SerializeField] private List<TextMeshProUGUI> diff;
    [SerializeField] private List<Stageitem> item;
    [SerializeField] private PlayerInput _player;
    [SerializeField] private List<GameObject> _buttons;
    [SerializeField] private GameObject _freeButton;
    [SerializeField] private GameObject _freeButtonImage;

    private int _buttonCount = 0;
    private int _command = 0;

    private InputAction _input_up;
    private InputAction _input_down;
    private InputAction _input_right;
    private InputAction _input_left;
    private InputAction _input_check;

    void Start()
    {
        _gs = GameObject.Find("GameState").GetComponent<GameState>();

        _input_up = _player.actions["Up"];
        _input_down = _player.actions["Down"];
        _input_right = _player.actions["Right"];
        _input_left = _player.actions["Left"];
        _input_check = _player.actions["Check"];

        for (int i = 0; i < item.Count; i++)
        {
            stageName[i].text = item[i].stageName;
            diff[i].text = $"��Փx : {item[i].diff}";
        }
    }

    private void Update()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            if(i == _buttonCount) _buttons[i].GetComponent<Image>().enabled = true;
            else _buttons[i].GetComponent<Image>().enabled = false;
        }

        if (_input_down.WasPressedThisFrame() || _input_right.WasPressedThisFrame())
        {
            if (_buttonCount < _buttons.Count - 1) _buttonCount++;
        }

        if (_input_up.WasPressedThisFrame() || _input_left.WasPressedThisFrame())
        {
            if (_buttonCount > 0) _buttonCount--;
        }

        if (_input_check.WasPressedThisFrame())
        {
            if (_buttonCount != 3) game(_buttonCount);
            else Free();
        }

        if (_input_up.WasPressedThisFrame() && _command == 0 || _command == 1) _command++;

        if (_input_down.WasPressedThisFrame() && _command == 2 || _command == 3) _command++;

        if (_input_left.WasPressedThisFrame() && _command == 4 || _command == 6) _command++;

        if (_input_right.WasPressedThisFrame() && _command == 5) _command++;

        // if (_input_up.WasPressedThisFrame() && _command != 0 && _command != 1) _command = 0;

        // if (_input_down.WasPressedThisFrame() && _command != 2 && _command != 3) _command = 0;

        // if (_input_left.WasPressedThisFrame() && _command != 4 && _command != 6) _command = 0;

        // if (_input_right.WasPressedThisFrame() && _command != 5 && _command != 7) _command = 0;

        if (_input_right.WasPressedThisFrame() && _command == 7)
        {
            _buttons.Add(_freeButtonImage);
            _freeButton.SetActive(true);
        }     
    }

    public void game(int StageId)
    {
        _gs.GoalPosition(StageId);
    }

    public void Free()
    {
        _gs.FreePlay();
    }

    public void Count(int _count)
    {
        _buttonCount = _count;
    }
}
