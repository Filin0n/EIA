using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class action_enemy : MonoBehaviour
{
    [Header("Дистанция до игрока")] public float dist; //дистанция до игрока
    private NavMeshAgent nav;
    private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField] [Header("Агрозона врага")] private float radius; //радиус видимости врага

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");// поис обЪекта с тегом Player
        dist = Vector3.Distance(player.transform.position,transform.position);//расчет дистанции между врагом и игроком

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

        if (dist < 2) //атака
        {
            anim.SetBool("Atack", true);
            nav.enabled = false;
        }
        else anim.SetBool("Atack", false);

    }
}
