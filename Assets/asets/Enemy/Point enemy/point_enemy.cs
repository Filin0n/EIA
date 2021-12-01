using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class point_enemy: MonoBehaviour
{
    [SerializeField] [Header("���������� �����")] private GameObject[] points;//�����
    private bool[] point_active;//���������� �����
    private Transform target_point;//�������� �����
    private Animator anim;

    private NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        point_active = new bool[points.Length];//�������� ������ ������ ������� ���������� �����

        //���� ��� ����� ��� �����������
        if (point_active.Length == 0) target_point = transform; 
        else
        {
            point_active[0] = true;
            anim.SetBool("Walk", true);
        }
    }

    void Update()
    {
       nav.SetDestination(Point().position);  
    }

    private Transform Point()//����� ��� �����������
    {
        for (int i = 0; i <= points.Length-1; i++ )
        {
            if (point_active[i]) target_point = points[i].transform;
        }
        return target_point.transform;
    }

    private void OnTriggerEnter(Collider point)
    {
        for (int i = 0; i <= points.Length - 1; i++)
        {
            if (point.name == points[i].name)
            {
                //��������� �������� �����
                point_active[i] = false;
                if ((i + 1) == points.Length) point_active[0] = true;
                else point_active[i + 1] = true;
            }
        }
    }
}
