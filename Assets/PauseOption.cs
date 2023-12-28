using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseOption : MonoBehaviour
{
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SESlider;
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SE;
    [SerializeField] private TextMeshProUGUI BGMVol;
    [SerializeField] private TextMeshProUGUI SEVol;
    private double bg, se;


    // Start is called before the first frame update
    void Start()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BgmVol", 0);
        SESlider.value = PlayerPrefs.GetFloat("SeVol", 0);
    }

    // Update is called once per frame
    void Update()
    {
        bg = BGMSlider.value * 100;
        se = SESlider.value * 100;
        BGM.volume = BGMSlider.value;
        SE.volume = SESlider.value;
        BGMVol.text = $"{(int)bg}";
        SEVol.text = $"{(int)se}";
       
    }


    public void Close(GameObject option)
    {
        option.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("BgmVol", BGMSlider.value);
        PlayerPrefs.SetFloat("SeVol", SESlider.value);
        PlayerPrefs.Save();
    }
}
