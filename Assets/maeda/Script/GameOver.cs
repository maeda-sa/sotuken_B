using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asset.maeda
{
    public class GameOver : MonoBehaviour
    {
        private GameState _gs;
        private int _count = 0;

        [SerializeField]TextMeshProUGUI guilt;
        [SerializeField] private List<GameObject> _button;
        [SerializeField] private PlayerInput _player;
        private InputAction _input_right;
        private InputAction _input_left;
        private InputAction _input_check;

        private void Start()
        {
            _gs = GameObject.Find("GameState").GetComponent<GameState>();
            guilt.text = "Ç®ëOÇÃçﬂÇêîÇ¶ÇÎ";

            _input_right = _player.actions["Right"];
            _input_left = _player.actions["Left"];
            _input_check = _player.actions["Check"];
        }

        private void Update()
        {
            for (int i = 0; i < _button.Count; i++)
            {
                if (i == _count) _button[i].GetComponent<Image>().enabled = false;
                else _button[i].GetComponent<Image>().enabled = true;
            }

            if (_input_right.WasPressedThisFrame())
            {
                if (_count < _button.Count - 1) _count++;
            }

            if (_input_left.WasPressedThisFrame())
            {
                if (_count > 0) _count--;
            }

            if (_input_check.WasPressedThisFrame())
            {
                switch (_count)
                {
                    case 0:
                        SceneChange("Select");
                        break;
                    case 1:
                        SceneChange("");
                        break;
                }
            }
        }

        public void Count(int c)
        {
            _count = c;
        }

        public  void SceneChange(string SceneName)
        {
            _gs._carCollision = false;
            _gs._walkerCollision = false;
            Initiate.Fade(SceneName, Color.black, 1.0f);
        }
    }
}