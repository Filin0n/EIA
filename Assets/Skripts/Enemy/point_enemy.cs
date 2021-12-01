using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class point_enemy: MonoBehaviour
{
    [SerializeField] private GameObject[] _points;

    private bool[] _pointActive;
    private Transform _targetPoint;
    private Animator _animator;
    private NavMeshAgent _navmeshAgent;

    void Start()
    {
        _navmeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _pointActive = new bool[_points.Length];

        if (_pointActive.Length == 0) _targetPoint = transform; 
        else
        {
            _pointActive[0] = true;
            _animator.SetBool("Walk", true);
        }
    }

    void Update()
    {
       _navmeshAgent.SetDestination(Point().position);  
    }

    private Transform Point()
    {
        for (int i = 0; i <= _points.Length-1; i++ )
        {
            if (_pointActive[i]) _targetPoint = _points[i].transform;
        }
        return _targetPoint.transform;
    }

    private void OnTriggerEnter(Collider point)
    {
        for (int i = 0; i <= _points.Length - 1; i++)
        {
            if (point.name == _points[i].name)
            {
                _pointActive[i] = false;
                if ((i + 1) == _points.Length) _pointActive[0] = true;
                else _pointActive[i + 1] = true;
            }
        }
    }
}
