using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_weapon_controller : MonoBehaviour
{
    
    [SerializeField][Header("ќружие колайдер которого зависит от анимации")]
    private GameObject weapon_1;
    [SerializeField]
    [Header("¬торое оружие колайдер которого зависит от анимации")]
    private GameObject weapon_2;

    private BoxCollider weapon_1_colider;
    private BoxCollider weapon_2_colider;

    private void Start()
    {
        weapon_1_colider = weapon_1.GetComponent<BoxCollider>();
        weapon_2_colider = weapon_2.GetComponent<BoxCollider>();
    }

    public void Weapon_1_col_on()
    {
        weapon_1_colider.enabled = true;
    }
    public void Weapon_1_col_off()
    {
        weapon_1_colider.enabled = false;
    }

    public void Weapon_2_col_on()
    {
        weapon_2_colider.enabled = true;
    }
    public void Weapon_2_col_off()
    {
        weapon_2_colider.enabled = false;
    }
}
