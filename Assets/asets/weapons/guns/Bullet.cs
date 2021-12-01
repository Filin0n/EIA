using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private bool isActive = true;
    [SerializeField] private float damage;

    private void Update()
    {
        StartCoroutine(dellBullet());//запуск корутины для удаления обЪекта 
    }

    private void OnCollisionEnter(Collision collision) //если объект сталкивается с чем-то
    {
      //  if (!isActive) return;
      //isActive = false;
        Debug.Log("Bulet hit "+ collision.gameObject.name); //вывести в консоль имя обьекта с которм было столкновение
       
        GetComponent<Rigidbody>().useGravity = true; //включение гравитации

       hp_enemy enemy = collision.gameObject.GetComponent<hp_enemy>(); 
        if (enemy) //если это враг
        {
            enemy.Injury(damage); //урон по врагу
        }
      
    }

    IEnumerator dellBullet() //корутина для удаление обЪекта со сцены
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
