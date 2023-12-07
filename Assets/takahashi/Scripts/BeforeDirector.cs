using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替え時に必須

//移動前シーン用
public class BeforeDirector : MonoBehaviour
{
    // フェードキャンバス取得
    [SerializeField] private Fade fade;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //スペースキーが押されたら
        {
            //フェードインした後シーン移動する（ラムダ式）
            fade.FadeIn(1f, () => {
                SceneManager.LoadScene("AfterTransScene");
            });
        }
    }
}
