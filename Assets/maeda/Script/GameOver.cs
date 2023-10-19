using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asset.maeda
{
    public class GameOver : MonoBehaviour
    {
        TextMeshProUGUI guilt;

        private void Start()
        {
            guilt.text = "‚¨‘O‚Ìß‚ğ”‚¦‚ë";

        }

        public  void SceneChange(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}