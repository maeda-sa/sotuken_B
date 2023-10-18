using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] string SceneName;
    CustomLoadScene CustomLoadScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            CustomLoadScene.LoadScene(SceneName);
        }
    }

 
}
