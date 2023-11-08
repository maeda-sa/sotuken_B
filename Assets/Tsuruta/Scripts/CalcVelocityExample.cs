using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcVelocityExample : MonoBehaviour
{
    // 1�t���[���O�̈ʒu
    private Vector3 _prevPosition;
    public float speed;

    private Rigidbody _rb;

    private void Start()
    {
        // �����ʒu��ێ�
        _prevPosition = transform.position;

        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // deltaTime��0�̏ꍇ�͉������Ȃ�
        if (Mathf.Approximately(Time.deltaTime, 0))
            return;

        // ���݈ʒu�擾
        var position = transform.position;

        // ���ݑ��x�v�Z
        var velocity = (position - _prevPosition) / Time.deltaTime;
        speed = _rb.velocity.magnitude;

        // ���ݑ��x�����O�o��
        // print($"velocity = {velocity}");

        // �O�t���[���ʒu���X�V
        _prevPosition = position;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
