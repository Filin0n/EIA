using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_characteristiks : MonoBehaviour
{
    [Header("Имя оружия")] public string weapon_name;
    [Header("Урон")] public float damage;

    [SerializeField] private List<string> Skills;

    public int weight; //вес оружия 
    private void OnTriggerEnter(Collider other)//урон по врагу
    {
        hp_enemy enemy = other.gameObject.GetComponent<hp_enemy>();
        if (enemy) //если это враг
        {
            enemy.Injury(damage); //урон по врагу
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
