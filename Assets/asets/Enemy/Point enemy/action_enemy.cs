using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class action_enemy : MonoBehaviour
{
    [Header("��������� �� ������")] public float dist; //��������� �� ������
    private NavMeshAgent nav;
    private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField] [Header("�������� �����")] private float radius; //������ ��������� �����

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");// ���� ������� � ����� Player
        dist = Vector3.Distance(player.transform.position,transform.position);//������ ��������� ����� ������ � �������

        if(dist > radius)
        {
            gameObject.GetComponent<point_enemy>().enabled = true; 
        }
        if(dist < radius & dist > 2f)
        {
            gameObject.GetComponent<point_enemy>().enabled = false;
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
            anim.SetBool("Run",true);
        }
        else   anim.SetBool("Run",false);

        if (dist < 2) //�����
        {
            anim.SetBool("Atack", true);
            nav.enabled = false;
        }
        else anim.SetBool("Atack", false);

    }
}
