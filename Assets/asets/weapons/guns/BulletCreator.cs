using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject BulletStartPosition;
    public float BulletVelocity;

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //нажатие на ЛКМ
        {
            GameObject newBullet = Instantiate(BulletPrefab, BulletStartPosition.transform.position, transform.rotation); //создать пулю
            
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletVelocity; //задать пуле скорость
        }


   

    }
}
