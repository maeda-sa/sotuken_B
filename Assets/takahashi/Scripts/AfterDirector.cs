using UnityEngine;

//�ړ���V�[���p
public class AfterDirector : MonoBehaviour
{
    [SerializeField] private Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        //�t�F�[�h�A�E�g
        fade.FadeOut(1f);
    }
}
