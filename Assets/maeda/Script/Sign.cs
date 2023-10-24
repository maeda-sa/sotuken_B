using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "sign",menuName = "signname")]
public class Sign : ScriptableObject
{
    //•W¯–¼
    public string signName;
    //•W¯‚Ì‰æ‘œ
    public Sprite signImage;
    //•W¯‚Ìà–¾
    [TextArea]public string exposition;
}
