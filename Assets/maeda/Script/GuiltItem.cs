using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asset.maeda.script
{
    [CreateAssetMenu(fileName = "Guilt", menuName = "Guilt")]
    public class GuiltItem:ScriptableObject
    {
        [Tooltip("内容")]
        public string Crime;
        [Tooltip("点数")]
        public int dpoint;
        [Tooltip("罰則内容"),TextArea]
        public string PD;
    }
}