using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject right_hand;
    [SerializeField] private GameObject left_hand;

    private List<Transform> _weaponsInRightHand = new List<Transform>();
    private List<Transform> _weaponsInLeftHand = new List<Transform>();

    private string _weaponName = "EmptyHand";

    private Interface _interface;
    private Interactive _interactive;

    private weapon_characteristiks _dropWeapon;
    private bool _weaponChaingeMenuIsActive = false;
    private void Start()
    {
        _interface = GetComponent<Interface>();
        _interactive = GetComponent<Interactive>();

        foreach (Transform child in right_hand.transform)
        {            
            _weaponsInRightHand.Add(child);
        }
        foreach (Transform child in left_hand.transform)
        {
            _weaponsInLeftHand.Add(child);
        }
    }

    private void Update()
    {
        _weaponChaingeMenuIsActive = _interface.weaponChaingeMenuIsActive;
        if (Input.GetKeyDown(KeyCode.Mouse0) && _weaponChaingeMenuIsActive)ToLeftHand();
        if (Input.GetKeyDown(KeyCode.Mouse1) && _weaponChaingeMenuIsActive)ToRightHand();
    }

    public void ChaingeWeapon(string WeaponName, weapon_characteristiks drop_weapon)
    {
        _weaponName = WeaponName;
        _dropWeapon = drop_weapon;
        _interface.WeaponMenuEnther();
    }

   public void ToLeftHand()
   {
        weapon_characteristiks RH_Charact = right_hand.GetComponentInChildren<weapon_characteristiks>();
        int r_handWeight = RH_Charact != null ? RH_Charact.weight : 0;

        if ((_dropWeapon.weight + r_handWeight) <= 4)
        { 
            foreach (Transform weapon in _weaponsInLeftHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
                else if (weapon.name == _weaponName)
                {
                    weapon.gameObject.SetActive(true);
                    _dropWeapon.Destroy();
                }
            }
        }
        else
        {
            foreach (Transform weapon in _weaponsInLeftHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
                else if (weapon.name == _weaponName)
                {
                    weapon.gameObject.SetActive(true);
                    _dropWeapon.Destroy();
                }
            }

            foreach (Transform weapon in _weaponsInRightHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
            }

                Debug.Log("Выбросить оружие из правой руки");
        }
        _weaponName = "EmptyHand";
        _interface.WeaponMenuExit();
   } 
   public void ToRightHand()
    { 
        weapon_characteristiks LH_Charact = left_hand.GetComponentInChildren<weapon_characteristiks>();
        int l_handWeight = LH_Charact != null ? LH_Charact.weight : 0;

        if ((_dropWeapon.weight + l_handWeight) <= 4)
        {
            foreach (Transform weapon in _weaponsInRightHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }

                if (_weaponName == "EmptyHand")
                {
                    return;
                }
                else if (weapon.name == _weaponName)
                {
                    weapon.gameObject.SetActive(true);
                    _dropWeapon.Destroy();
                }
            }
        }
        else
        {
            foreach (Transform weapon in _weaponsInRightHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }

                if (_weaponName == "EmptyHand") return;
                else if (weapon.name == _weaponName)
                {
                    weapon.gameObject.SetActive(true);
                    _dropWeapon.Destroy();
                }
            }
            foreach (Transform weapon in _weaponsInLeftHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
            }
        }
        _weaponName = "EmptyHand";
        _interface.WeaponMenuExit();
   }
}
