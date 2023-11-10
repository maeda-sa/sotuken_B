using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asset.maeda.script
{
    [CreateAssetMenu(fileName = "Guilt", menuName = "Guilt")]
    public class GuiltItem:ScriptableObject
    {
        [Tooltip("���e")]
        public string Crime;
        [Tooltip("�_��")]
        public int dpoint;
        [Tooltip("�������e"),TextArea]
        public string PD;
    }
}