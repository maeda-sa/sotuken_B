using UnityEngine;

public class FadeAnimDirector : MonoBehaviour
{
    // �t�F�[�h�L�����o�X�擾
    [SerializeField] private Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        //�t�F�[�h�C��������t�F�[�h�A�E�g����i�����_���j
        fade.FadeIn(1f, () =>
        {
            //�t�F�[�h�A�E�g
            fade.FadeOut(1f);
        });
    }
}
