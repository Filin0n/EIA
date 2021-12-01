using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActionEnemy : MonoBehaviour
{
    [SerializeField] private float _agroRadius;

    private float _distanceToPlayer;
    private GameObject _player;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _distanceToPlayer = Vector3.Distance(_player.transform.position,transform.position);

        if(_distanceToPlayer > _agroRadius)
        {
            gameObject.GetComponent<point_enemy>().enabled = true;
            _animator.SetBool("Run", false);
        }

        if (_distanceToPlayer < _agroRadius & _distanceToPlayer > 2f)
        {
            gameObject.GetComponent<point_enemy>().enabled = false;
            _navMeshAgent.enabled = true;
            _navMeshAgent.SetDestination(_player.transform.position);
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }

        if (_distanceToPlayer < 2)
        {
            _animator.SetBool("Atack", true);
            _navMeshAgent.enabled = false;
        }
        else
        {
            _animator.SetBool("Atack", false);
        }
    }
}
