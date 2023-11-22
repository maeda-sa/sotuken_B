using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlowOff : MonoBehaviour
{
    [SerializeField] private Walker _walker;
    [SerializeField] private NavMeshAgent _nma;
    [SerializeField]
    float impulse = 300;

    bool isCollision = false;

    Rigidbody rigidBody;
    Rigidbody playerRigidBody;
    GameObject player;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        //�v���C���[���^�O�Ō������ARigidbody���擾
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            try { 
                _nma.enabled = false;
                _walker.GetStop();
            } catch(Exception e) { }

            Debug.Log("�ڐG");

            //������΂�
            Vector3 playerVelocity = playerRigidBody.velocity;
            rigidBody.AddForce(playerVelocity * impulse, ForceMode.Impulse);
            rigidBody.AddForce(Vector3.up * impulse, ForceMode.Impulse);

            isCollision = true;
        }
    }
}
