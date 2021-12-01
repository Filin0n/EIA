using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_characteristiks : MonoBehaviour
{
    [SerializeField] private List<string> Skills;

    public string weaponName;
    public float damage;
    public int weight;  

    private void OnTriggerEnter(Collider other)
    {
        EnemyHp enemy = other.gameObject.GetComponent<EnemyHp>();
        if (enemy)
        {
            enemy.ApplyDamage(damage);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
