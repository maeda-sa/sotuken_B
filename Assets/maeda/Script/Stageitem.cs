using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asset.maeda.script
{
    [System.Serializable]
    public class Stageitem
    {
        [Tooltip("ステージID")]
        public int stageId;
        [Tooltip("ステージ名")]
        public string stageName;
        [Tooltip("難易度")]
        public string diff;
    }
}
