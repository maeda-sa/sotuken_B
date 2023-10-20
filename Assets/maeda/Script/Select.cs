using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] private List<GameObject> bike;
    private bool isStop = false;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SESlider;
    [SerializeField]private AudioSource BGM;
    [SerializeField]private AudioSource SE;
    [SerializeField] private TextMeshProUGUI BGMVol;
    [SerializeField] private TextMeshProUGUI SEVol;
    private double bg, se;

    private void Awake()
    {
        BGM.Play();
        BGMSlider.value = 1;
        SESlider.value = 1;
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
        bg = BGMSlider.value * 100;
        se = SESlider.value * 100;
        BGM.volume = BGMSlider.value;
        SE.volume = SESlider.value;
        BGMVol.text = $"{(int)bg}";
        SEVol.text = $"{(int)se}";
    }


    public void Option(GameObject item)
    {
        if(!isStop)
        {
            SE.Play();
            item.SetActive(true);
            isStop = true;
        }
    }

    public void Back(GameObject item)
    {
        if (isStop)
        {
            SE.Play();
            item.SetActive(false) ;
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
