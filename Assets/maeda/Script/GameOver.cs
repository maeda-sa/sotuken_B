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
            guilt.text = "過失致死傷罪\n障害を与えた場合、30万円以下の罰金又は科料\n死亡させてしまった場合は50万円以下の罰金となっている。";

        }

        public  void SceneChange(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}