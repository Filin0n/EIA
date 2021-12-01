using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private bool isActive = true;
    [SerializeField] private float damage;

    private void Update()
    {
        StartCoroutine(dellBullet());//������ �������� ��� �������� ������� 
    }

    private void OnCollisionEnter(Collision collision) //���� ������ ������������ � ���-��
    {
      //  if (!isActive) return;
      //isActive = false;
        Debug.Log("Bulet hit "+ collision.gameObject.name); //������� � ������� ��� ������� � ������ ���� ������������
       
        GetComponent<Rigidbody>().useGravity = true; //��������� ����������

       hp_enemy enemy = collision.gameObject.GetComponent<hp_enemy>(); 
        if (enemy) //���� ��� ����
        {
            enemy.Injury(damage); //���� �� �����
        }
      
    }

    IEnumerator dellBullet() //�������� ��� �������� ������� �� �����
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
