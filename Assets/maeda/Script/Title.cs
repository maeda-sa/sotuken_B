using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private PlayerInput _player;
    [SerializeField] string SceneName;
    CustomLoadScene CustomLoadScene;
    [SerializeField] TextMeshProUGUI start;
    private float time;
    public float speed = 1.0f;

    private InputAction _input_check;

    private void Start()
    {
        _input_check = _player.actions["Check"];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Initiate.Fade(SceneName, Color.black, 1.0f);
        }

        if (_input_check.WasPressedThisFrame())
        {
            Initiate.Fade(SceneName, Color.black, 1.0f);
        }

        start.color = GetAlphaColor(start.color);
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
