using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] private List<GameObject> bike;
    private bool isStop = false;
    //[SerializeField] private Slider BGMSlider;
    //[SerializeField] private Slider SESlider;
    [SerializeField]private AudioSource BGM;
    [SerializeField]private AudioSource SE;

    private void Awake()
    {
        BGM.Play();
    }

    private void Start()
    {
        for (int i = 0; i < bike.Count; i++)
        {
            bike[i].transform.Rotate(new Vector3(0, 0, 0));
        }


       
    }
    private void Update()
    {
        for (int i = 0; i < bike.Count; i++)
        {
            bike[i].transform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime);
        }

       // BGM.volume = BGMSlider.value;
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
