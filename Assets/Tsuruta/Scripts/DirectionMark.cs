using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMark : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーオブジェクト")]
    private Transform player = null;

    [SerializeField, Tooltip("プレイヤーを映すカメラ")]
    private Transform Camera = null;

    [SerializeField, Tooltip("追いかけるターゲット")]
    private Transform Target = null;

    public Transform SetPlayer { get { return player; } set { player = value; } }
    public Transform SetCamera { get { return Camera; } set { Camera = value; } }
    public Transform SetTarget { get { return Target; } set { Target = value; } }

    void Update()
    {
        TurnAroundDirectionTarget();
    }

    private void TurnAroundDirectionTarget()
    {
        // プレイヤーからターゲットまでのベクトルを計算
        Vector3 Direction = (Target.position - player.transform.position).normalized;

        // 求めた方向への回転量を求める
        Quaternion RotationalVolume = Quaternion.LookRotation(Direction, Vector3.up);

        // カメラ情報を元に回転量の補正
        Quaternion CorrectionVolume = Quaternion.FromToRotation(Camera.transform.forward, Vector3.forward);

        // 向きを計算
        Vector3 vec = (RotationalVolume * CorrectionVolume).eulerAngles;

        // 向きを反映
        transform.rotation = Quaternion.Euler(0, vec.y, 0);
    }
}
