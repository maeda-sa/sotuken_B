using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asset.maeda.script
{
    [CreateAssetMenu(fileName = "Guilt", menuName = "Guilt")]
    public class GuiltItem:ScriptableObject
    {
        [Tooltip("ì‡óe")]
        public string Crime;
        [Tooltip("ì_êî")]
        public int dpoint;
        [Tooltip("î±ë•ì‡óe"),TextArea]
        public string PD;
    }
}