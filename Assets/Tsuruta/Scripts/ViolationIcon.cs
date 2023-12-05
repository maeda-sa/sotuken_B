using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ViolationIcon : MonoBehaviour
{
    public bool flgFade;
    Color color;

    void Start()
    {
        color = gameObject.GetComponent<Image>().color;
        color.r = 0.0f;
        color.g = 0.0f;
        color.b = 0.0f;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;

        StartCoroutine("FadeOn");
    }

    //EventTrigger�ɂ��쓮
    IEnumerator FadeOn()
    {
        yield return new WaitForSeconds(5);

        while (true)
        {
            color.a -= 0.1f;
            gameObject.GetComponent<Image>().color = color;
            Debug.Log("�t�F�[�h�A�E�g");

            //�Â��Ȃ���
            if (color.a <= 0)
            {
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
