using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
 ��� ������ ����� ������� ����� �� ����� � ������������ ���� ����� ��� ������
 */


public class Enemy : MonoBehaviour
{
    
    [Header("��������� �� ������")] public float dist; //��������� �� ������
    private NavMeshAgent nav;
    private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField] [Header("�������� �����")] private float radius; //������ ��������� �����
   // [SerializeField] [Header("��������")] private float hp;
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       // movePoint = GetComponent<point_enrmy>();
    }

    void Update()
    {
        AtackTo();
      //  if (hp <= 0) Destroy(gameObject);//������
    }

    private void AtackTo()//��� ����������� �����
    {
        dist = Vector3.Distance(player.transform.position, transform.position); //������ ��������� �� ������
     
        if (dist < radius & dist >2)//������������ � ������
        {
            nav.enabled = true;
           
            anim.SetBool("Run",true);
            nav.SetDestination(player.transform.position); //������ �������������
        }
        else anim.SetBool("Run", false);

        if (dist > radius)//��� ���� ���������
        {
            anim.SetBool("Idle",true);
            nav.enabled = false;
            
        }
        else anim.SetBool("Idle", false);

        if (dist < 2) //�����
        {
            anim.SetBool("Atack", true);
            nav.enabled = false;
        }
        else anim.SetBool("Atack",false);
        
    }

   /* public void OnHit() //���������� ����
    {
        hp -= 1;
    }*/
}
