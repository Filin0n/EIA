using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject _weapon1;
    [SerializeField] private GameObject _weapon2;

    private BoxCollider _weapon1Colider;
    private BoxCollider _weapon2Colider;

    private void Start()
    {
        _weapon1Colider = _weapon1.GetComponent<BoxCollider>();
        _weapon2Colider = _weapon2.GetComponent<BoxCollider>();
    }

    public void Weapon_1_col_on()
    {
        _weapon1Colider.enabled = true;
    }
    public void Weapon_1_col_off()
    {
        _weapon1Colider.enabled = false;
    }

    public void Weapon_2_col_on()
    {
        _weapon2Colider.enabled = true;
    }
    public void Weapon_2_col_off()
    {
        _weapon2Colider.enabled = false;
    }
}
