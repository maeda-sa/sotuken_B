using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "sign",menuName = "signname")]
public class Sign : ScriptableObject
{
    //標識名
    public string signName;
    //標識の画像
    public Sprite signImage;
    //標識の説明
    [TextArea]public string exposition;
}
