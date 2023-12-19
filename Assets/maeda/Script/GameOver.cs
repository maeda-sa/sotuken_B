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
            guilt.text = "�ߎ��v������\n��Q��^�����ꍇ�A30���~�ȉ��̔������͉ȗ�\n���S�����Ă��܂����ꍇ��50���~�ȉ��̔����ƂȂ��Ă���B";

        }

        public  void SceneChange(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}