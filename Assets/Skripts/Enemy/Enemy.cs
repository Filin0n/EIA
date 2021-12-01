using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
 это скрипт врага который стоит на месте и бездействует пока рядом нет игрока
 */


public class Enemy : MonoBehaviour
{
    
    [Header("Дистанция до игрока")] public float dist; //дистанция до игрока
    private NavMeshAgent nav;
    private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField] [Header("Агрозона врага")] private float radius; //радиус видимости врага
   // [SerializeField] [Header("Здоровье")] private float hp;
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
      //  if (hp <= 0) Destroy(gameObject);//смерть
    }

    private void AtackTo()//При обнаружении врага
    {
        dist = Vector3.Distance(player.transform.position, transform.position); //расчет дистанции до игрока
     
        if (dist < radius & dist >2)//направляется к игроку
        {
            nav.enabled = true;
           
            anim.SetBool("Run",true);
            nav.SetDestination(player.transform.position); //объект преследования
        }
        else anim.SetBool("Run", false);

        if (dist > radius)//вне зоны видимости
        {
            anim.SetBool("Idle",true);
            nav.enabled = false;
            
        }
        else anim.SetBool("Idle", false);

        if (dist < 2) //атака
        {
            anim.SetBool("Atack", true);
            nav.enabled = false;
        }
        else anim.SetBool("Atack",false);
        
    }

   /* public void OnHit() //получаемый урон
    {
        hp -= 1;
    }*/
}
