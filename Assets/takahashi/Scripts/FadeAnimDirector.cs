using UnityEngine;

public class FadeAnimDirector : MonoBehaviour
{
    // フェードキャンバス取得
    [SerializeField] private Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        //フェードインした後フェードアウトする（ラムダ式）
        fade.FadeIn(1f, () =>
        {
            //フェードアウト
            fade.FadeOut(1f);
        });
    }
}
