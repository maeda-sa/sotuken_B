using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _goal;
    [SerializeField] private Rigidbody _rb;

    private bool _move = true;

    void Start()
    {
        _agent.destination = _goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            _anim.SetBool("Move", true);
            _anim.SetBool("Stop", false);
        }
        if (!_move)
        {
            _anim.SetBool("Move", false);
            _anim.SetBool("Stop", true);
        }
    }

    public void GetStop()
    {
        _move = false;
    }
}
