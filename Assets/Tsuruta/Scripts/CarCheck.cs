using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheck : MonoBehaviour
{
    private Rigidbody rb;
    private CinemachineDollyCart cdc;
    public bool debug;

    private Ray ray; // ��΂����C
    private float distance = 6f; // ���C���΂�����
    private RaycastHit hit; // ���C�������ɓ����������̏��
    private Vector3 rayPosition; // ���C�𔭎˂���ʒu

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cdc = gameObject.GetComponentInParent<CinemachineDollyCart>();
    }

    // Update is called once per frame
    void Update()
    {
        rayPosition = transform.position + new Vector3(0, -0.25f, 0); // ���C�𔭎˂���ʒu�̒���
        ray = new Ray(rayPosition, -transform.forward); // ���C�����ɔ�΂�
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red); // ���C��ԐF�ŕ\��������

        if (Physics.Raycast(ray, out hit, distance)) // ���C�������������̏���
        {
            if (hit.collider.tag == "Car" && hit.collider.name != gameObject.name) // ���C���n�ʂɐG�ꂽ��A
            {
                if(debug) Debug.Log(hit.collider.name);
                CinemachineDollyCart _cdc = hit.collider.gameObject.GetComponentInParent<CinemachineDollyCart>();
                _cdc.m_Speed = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            if (other.gameObject.tag == "Car")
            {
                Invoke("Accel",2);
            }
        }
    }

    public void Stop()
    {
        cdc.m_Speed = 0;
    }

    public void Accel()
    {
        cdc.m_Speed = 20;
    }
}
