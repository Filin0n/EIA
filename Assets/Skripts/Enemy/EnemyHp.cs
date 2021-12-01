using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{     
    [SerializeField] private float _hp;
    [SerializeField] private GameObject _ragdoll;

    void Update()
    {
        if (_hp < 1) {  
            Destroy(gameObject);
            Instantiate(_ragdoll, transform.position,transform.rotation);          
        } 
    }

    public void ApplyDamage(float damage)
    {
        _hp -= damage;
    }
}
