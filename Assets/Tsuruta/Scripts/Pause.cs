using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private Bike _bike;
    [SerializeField] private PlayerInput _player;
    private InputAction _input;
    private bool _pause;
    private bool _pauseCheck;

    // Start is called before the first frame update
    void Start()
    {
        _input= _player.actions["Pause"];
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.WasPressedThisFrame())
        {
            if (_pauseCheck)
            {
                Debug.Log("í‚é~èIóπ");
                _bike.OffGoal();
                Time.timeScale = 1;
                _pauseCheck = false;
            }
            else
            {
                Debug.Log("í‚é~");
                _bike.OnGoal();
                Time.timeScale = 0;
                _pauseCheck = true;
            }
        }
    }
}
