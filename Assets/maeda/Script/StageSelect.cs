using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Asset.maeda.script;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> stageName;
    [SerializeField] private List<TextMeshProUGUI> diff;
    [SerializeField] private List<Stageitem> item;

    void Start()
    {
        for(int i = 0; i < item.Count; i++)
        {
            stageName[i].text = item[i].stageName;
            diff[i].text = $"“ïˆÕ“x : {item[i].diff}";
        }
    }

    public void game(int StageId)
    {
        Initiate.Fade("Low Poly Road Pack Demo", Color.black, 1.0f); 
    }
}
