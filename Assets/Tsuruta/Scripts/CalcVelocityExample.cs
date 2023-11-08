using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcVelocityExample : MonoBehaviour
{
    // 1フレーム前の位置
    private Vector3 _prevPosition;
    public float speed;

    private Rigidbody _rb;

    private void Start()
    {
        // 初期位置を保持
        _prevPosition = transform.position;

        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // deltaTimeが0の場合は何もしない
        if (Mathf.Approximately(Time.deltaTime, 0))
            return;

        // 現在位置取得
        var position = transform.position;

        // 現在速度計算
        var velocity = (position - _prevPosition) / Time.deltaTime;
        speed = _rb.velocity.magnitude;

        // 現在速度をログ出力
        // print($"velocity = {velocity}");

        // 前フレーム位置を更新
        _prevPosition = position;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
