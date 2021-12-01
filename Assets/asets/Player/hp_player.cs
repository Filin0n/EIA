using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_player : MonoBehaviour
{
    [SerializeField] [Header("Здоровье")] private float max_hp;
    [SerializeField] private float curent_hp; //текущее здоровье

    [SerializeField] private Image HalthBar; //Полоска здоровья

    private void Start()
    {
        curent_hp = max_hp;
    }

    void Update()
    {
        if (curent_hp < 1) Debug.Log("you are ded");

        HalthBar.fillAmount = curent_hp / max_hp;// управление полоской хп
    }

    //Считывание урона
    private void OnTriggerEnter(Collider weapon)
    {
        if (weapon.tag == "Sword")
        {
            curent_hp -= 5;
            return;
        }
        if (weapon.tag == "Kick")
        {
            curent_hp -= 2;
            return;
        }
    }
}