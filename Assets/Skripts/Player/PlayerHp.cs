using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private float _maxHp;
    [SerializeField] private Image _halthBar; 

    private float _curentHP;
    
    private void Start()
    {
        _curentHP = _maxHp;
    }

    void Update()
    {
        if (_curentHP < 1) Debug.Log("you are ded");

        _halthBar.fillAmount = _curentHP / _maxHp;
    }

    private void OnTriggerEnter(Collider weapon)
    {
        if (weapon.tag == "Sword")
        {
            _curentHP -= 5;
            return;
        }
        if (weapon.tag == "Kick")
        {
            _curentHP -= 2;
            return;
        }
    }
}