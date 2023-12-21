using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asset.maeda
{
    public class GameOver : MonoBehaviour
    {
        private GameState _gs;
        [SerializeField]TextMeshProUGUI guilt;

        private void Start()
        {
            _gs = GameObject.Find("GameState").GetComponent<GameState>();
            guilt.text = "Ç®ëOÇÃçﬂÇêîÇ¶ÇÎ";

        }

        public  void SceneChange(string SceneName)
        {
            _gs._carCollision = false;
            _gs._walkerCollision = false;
            Initiate.Fade(SceneName, Color.black, 1.0f);
        }
    }
}