using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ����ɕK�{

//�ړ��O�V�[���p
public class BeforeDirector : MonoBehaviour
{
    // �t�F�[�h�L�����o�X�擾
    [SerializeField] private Fade fade;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //�X�y�[�X�L�[�������ꂽ��
        {
            //�t�F�[�h�C��������V�[���ړ�����i�����_���j
            fade.FadeIn(1f, () => {
                SceneManager.LoadScene("AfterTransScene");
            });
        }
    }
}
