using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asset.maeda
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField]TextMeshProUGUI guilt;

        private void Start()
        {
            guilt.text = "Ç®ëOÇÃçﬂÇêîÇ¶ÇÎ";

        }

        public  void SceneChange(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}