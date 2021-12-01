using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_enemy : MonoBehaviour
{     
    [SerializeField] [Header("Здоровье")] private float hp;
    [SerializeField] private GameObject Ragdoll;

    void Update()
    {
        if (hp < 1) {  //смерть
            Destroy(gameObject);
            Instantiate(Ragdoll, transform.position,transform.rotation);          
        } 
    }
    public void Injury(float damage)//получаемый урон
    {
        hp -= damage;
    }
}
