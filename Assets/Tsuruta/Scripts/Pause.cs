using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    private bool _pause;
    private bool _pauseCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_pause)
        {
            if (_pauseCheck)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        _pause = context.ReadValueAsButton();
    }
}
