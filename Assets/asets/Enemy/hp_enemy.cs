using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_enemy : MonoBehaviour
{     
    [SerializeField] [Header("��������")] private float hp;
    [SerializeField] private GameObject Ragdoll;

    void Update()
    {
        if (hp < 1) {  //������
            Destroy(gameObject);
            Instantiate(Ragdoll, transform.position,transform.rotation);          
        } 
    }
    public void Injury(float damage)//���������� ����
    {
        hp -= damage;
    }
}
