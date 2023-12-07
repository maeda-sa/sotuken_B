using UnityEngine;

//移動後シーン用
public class AfterDirector : MonoBehaviour
{
    [SerializeField] private Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        //フェードアウト
        fade.FadeOut(1f);
    }
}
