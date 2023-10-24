using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "sign",menuName = "signname")]
public class Sign : ScriptableObject
{
    //�W����
    public string signName;
    //�W���̉摜
    public Sprite signImage;
    //�W���̐���
    [TextArea]public string exposition;
}
