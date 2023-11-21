using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] private List<GameObject> bike;
    [SerializeField] private GameObject selectUi;
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
        
    }

    private void Start()
    {
        for (int i = 0; i < bike.Count; i++)
        {
            bike[i].transform.Rotate(new Vector3(0, 0, 0));
        }

        BGMSlider.value = PlayerPrefs.GetFloat("BgmVol", 0);
        SESlider.value = PlayerPrefs.GetFloat("SeVol", 0);
    }
    private void Update()
    {

        for (int i = 0; i < bike.Count-1; i++)
        {
            bike[i].transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        }
      
    }

    
    public void Option(GameObject item)
    {
        if(!isStop)
        {
            selectUi.SetActive(false);
           
            SE.Play();
            item.SetActive(true);
            isStop = true;
        }
    }

    public void Back(GameObject item)
    {
        if (isStop)
        {
            selectUi.SetActive(true);   
           
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
