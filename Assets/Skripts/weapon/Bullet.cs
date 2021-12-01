using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void Update()
    {
        StartCoroutine(dellBullet()); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bulet hit "+ collision.gameObject.name);
       
        GetComponent<Rigidbody>().useGravity = true;

        EnemyHp enemy = collision.gameObject.GetComponent<EnemyHp>(); 

        if (enemy) 
        {
            enemy.ApplyDamage(_damage); 
        }
    }

    IEnumerator dellBullet() 
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
