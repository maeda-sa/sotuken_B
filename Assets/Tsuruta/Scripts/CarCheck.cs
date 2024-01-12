using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheck : MonoBehaviour
{
    private Rigidbody rb;
    private CinemachineDollyCart cdc;
    public bool debug;

    private Ray ray; // 飛ばすレイ
    private float distance = 6f; // レイを飛ばす距離
    private RaycastHit hit; // レイが何かに当たった時の情報
    private Vector3 rayPosition; // レイを発射する位置

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cdc = gameObject.GetComponentInParent<CinemachineDollyCart>();
    }

    // Update is called once per frame
    void Update()
    {
        rayPosition = transform.position + new Vector3(0, -0.25f, 0); // レイを発射する位置の調整
        ray = new Ray(rayPosition, -transform.forward); // レイを下に飛ばす
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red); // レイを赤色で表示させる

        if (Physics.Raycast(ray, out hit, distance)) // レイが当たった時の処理
        {
            if (hit.collider.tag == "Car" && hit.collider.name != gameObject.name) // レイが地面に触れたら、
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
