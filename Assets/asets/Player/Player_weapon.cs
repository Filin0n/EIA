using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_weapon : MonoBehaviour
{
    [SerializeField] private GameObject right_hand;
    [SerializeField] private GameObject left_hand;

     private List<Transform> weaponsInRightHand = new List<Transform>();//все оружие в правой руке
     private List<Transform> weaponsInLeftHand = new List<Transform>();//все оружие в левой руке

    private string weaponName = "EmptyHand"; //имя оружия которое подобрал игрок

    private Interface _interface;//скрипт игрового интерфейса
    private interactive _interactive;//Скрипт взаимодействия с окружением

    weapon_characteristiks dropWeapon;//подбираемое оружие
    private bool WeaponChaingeMenuIsActive = false;//если меню выбора оружия активно

    private void Start()
    {
        _interface = GetComponent<Interface>();
        _interactive = GetComponent<interactive>();

        //заполнение списков оружия
        foreach (Transform child in right_hand.transform)//список оружия из правой руки
        {            
            weaponsInRightHand.Add(child);
        }
        foreach (Transform child in left_hand.transform)//список оружия из левой руки
        {
            weaponsInLeftHand.Add(child);
        }
    }

    private void Update()
    {
        //если меню выбора оружия активно
        WeaponChaingeMenuIsActive = _interface._WeaponChaingeMenuIsActive;
        if (Input.GetKeyDown(KeyCode.Mouse0) && WeaponChaingeMenuIsActive)ToLeftHand();
        if (Input.GetKeyDown(KeyCode.Mouse1) && WeaponChaingeMenuIsActive)ToRightHand();
    }

    public void ChaingeWeapon(string WeaponName, weapon_characteristiks drop_weapon)//смена оружия в зависимости от еого имени
    {
        weaponName = WeaponName;
        dropWeapon = drop_weapon;
        _interface.WeaponMenuEnther();//Включение мею оружия
    }

   public void ToLeftHand()//в левую руку
   {
        //Узнать вес оружия в правой руке
        weapon_characteristiks RH_Charact = right_hand.GetComponentInChildren<weapon_characteristiks>();
        int r_handWeight = RH_Charact != null ? RH_Charact.weight : 0;

        // если общий вес оружия в обеих руках не больше допустимого веса
        if ((dropWeapon.weight + r_handWeight) <= 4)
        { 
            foreach (Transform weapon in weaponsInLeftHand)//поочередный пекребор оружия в руке
            {
                if (weapon.gameObject.activeSelf)//Если оружие активно отключить его
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    //Выбросить оружие
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
                else if (weapon.name == weaponName) //Иначе если имя оружия равно имени подбираемого оружия, включить его
                {
                    weapon.gameObject.SetActive(true);
                    dropWeapon.Destroy();
                }

            }
        }
        // если общий вес оружия в обеих руках больше допустимого веса
        else
        {
            foreach (Transform weapon in weaponsInLeftHand)//поочередный пекребор оружия в руке
            {
                if (weapon.gameObject.activeSelf)//Если оружие активно отключить его
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    //Выбросить оружие
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
                else if (weapon.name == weaponName) //Иначе если имя оружия равно имени подбираемого оружия, включить его
                {
                    weapon.gameObject.SetActive(true);
                    dropWeapon.Destroy();
                }
            }

            //Выюросить оружие из правой руки
            foreach (Transform weapon in weaponsInRightHand)//поочередный пекребор оружия в руке
            {
                if (weapon.gameObject.activeSelf)//Если оружие активно отключить его
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    //Выбросить оружие
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
            }

                Debug.Log("Выбросить оружие из правой руки");
        }
        weaponName = "EmptyHand";
        _interface.WeaponMenuExit();//Выключение мею оружия
   } 
   public void ToRightHand()//в правую руку
   {
        //Узнать вес оружия в левой руке
        weapon_characteristiks LH_Charact = left_hand.GetComponentInChildren<weapon_characteristiks>();
        int l_handWeight = LH_Charact != null ? LH_Charact.weight : 0;

        // если общий вес оружия в обеих руках не больше допустимого веса
        if ((dropWeapon.weight + l_handWeight) <= 4)
        {
            //смена оружия
            foreach (Transform weapon in weaponsInRightHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);//Выбросить оружие
                    weapon.gameObject.SetActive(false);
                }

                if (weaponName == "EmptyHand") return;
                else if (weapon.name == weaponName)
                {
                    weapon.gameObject.SetActive(true);
                    dropWeapon.Destroy();
                }

            }
        }
        // если общий вес оружия в обеих руках больше допустимого веса
        else
        {
            foreach (Transform weapon in weaponsInRightHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);//Выбросить оружие
                    weapon.gameObject.SetActive(false);
                }

                if (weaponName == "EmptyHand") return;
                else if (weapon.name == weaponName)
                {
                    weapon.gameObject.SetActive(true);
                    dropWeapon.Destroy();
                }
            }
            foreach (Transform weapon in weaponsInLeftHand)//Выбросить оружие из левой руки
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("Вы выбросили " + weapon.name);
                    _interactive.DropWeapon(weapon);//Выбросить оружие
                    weapon.gameObject.SetActive(false);
                }
            }
        }
        weaponName = "EmptyHand";
        _interface.WeaponMenuExit();//Выключение меню оружия
   }

}
