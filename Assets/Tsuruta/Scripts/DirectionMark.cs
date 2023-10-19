using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMark : MonoBehaviour
{
    [SerializeField, Tooltip("�v���C���[�I�u�W�F�N�g")]
    private Transform player = null;

    [SerializeField, Tooltip("�v���C���[���f���J����")]
    private Transform Camera = null;

    [SerializeField, Tooltip("�ǂ�������^�[�Q�b�g")]
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
        // �v���C���[����^�[�Q�b�g�܂ł̃x�N�g�����v�Z
        Vector3 Direction = (Target.position - player.transform.position).normalized;

        // ���߂������ւ̉�]�ʂ����߂�
        Quaternion RotationalVolume = Quaternion.LookRotation(Direction, Vector3.up);

        // �J�����������ɉ�]�ʂ̕␳
        Quaternion CorrectionVolume = Quaternion.FromToRotation(Camera.transform.forward, Vector3.forward);

        // �������v�Z
        Vector3 vec = (RotationalVolume * CorrectionVolume).eulerAngles;

        // �����𔽉f
        transform.rotation = Quaternion.Euler(0, vec.y, 0);
    }
}
