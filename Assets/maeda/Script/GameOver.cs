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
            guilt.text = "‰ß¸’v€ß\náŠQ‚ğ—^‚¦‚½ê‡A30–œ‰~ˆÈ‰º‚Ì”±‹à–”‚Í‰È—¿\n€–S‚³‚¹‚Ä‚µ‚Ü‚Á‚½ê‡‚Í50–œ‰~ˆÈ‰º‚Ì”±‹à‚Æ‚È‚Á‚Ä‚¢‚éB";

        }

        public  void SceneChange(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}