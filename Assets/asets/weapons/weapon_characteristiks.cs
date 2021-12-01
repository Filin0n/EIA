using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_characteristiks : MonoBehaviour
{
    [Header("��� ������")] public string weapon_name;
    [Header("����")] public float damage;

    [SerializeField] private List<string> Skills;

    public int weight; //��� ������ 
    private void OnTriggerEnter(Collider other)//���� �� �����
    {
        hp_enemy enemy = other.gameObject.GetComponent<hp_enemy>();
        if (enemy) //���� ��� ����
        {
            enemy.Injury(damage); //���� �� �����
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
