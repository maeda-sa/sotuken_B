using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] private GameObject bike;
    private bool isStop = false;

    private void Start()
    {
        bike.transform.Rotate(new Vector3(0, 0, 0)); 
    }

    private void Update()
    {
        bike.transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);
    }


    public void Option(GameObject item)
    {
        if(!isStop)
        {
            item.SetActive(true);
            isStop = true;
        }
    }

    public void Back(GameObject item)
    {
        if (isStop)
        {
            item.SetActive(true);
            isStop = false;
        }
    }

    public void EndGame()
    {
        if (!isStop)
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
    }
}
