using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    //меню
    //[SerializeField] private GameObject WeaponChaigeMenu;
    [SerializeField] private Transform l_weapon_menu;//меню оружия левой руки
    [SerializeField]private Transform r_weapon_menu;//меню оружия правой руки
    [SerializeField] private Transform selected_weapon_menu;//меню подбираемого оружия

    //поля левой руки
    private Text LWeaponNameInMenu; //вывод имени оружия в левой руке 
    private Text LDamageInMenu;
    private Text LWeaponWeight;

    //Поля правой руки
    private Text RWeaponNameInMenu; //вывод имени оружия в правой руке 
    private Text RDamageInMenu;
    private Text RWeaponWeight;


    //поля для вывода информации в меню подбираемого оружия
    private Text Sel_WeaponNameInMenu;
    private Text Sel_WeapDamageInMenu;

    //руки и оружие
    [SerializeField] private GameObject right_hand;
    [SerializeField] private GameObject left_hand;

    private List<Transform> weaponsInLeftHand = new List<Transform>();//все оружие в левой руке

    private CameraController camera_controller;//камера
    private FirstPersonController FPC;//контроллер игрока
    private PlayerAtackController atackController;//Скрипт отвечающий за атаку

    public bool _WeaponChaingeMenuIsActive = false;//если меню выбора оружия активно

    void Start()
    {
        //поля для левой руки
        LWeaponNameInMenu = l_weapon_menu.GetChild(0).GetComponent<Text>();
        LDamageInMenu = l_weapon_menu.GetChild(1).GetComponent<Text>();
        LWeaponWeight = l_weapon_menu.GetChild(2).GetComponent<Text>();

        //поля для правой руки
        RWeaponNameInMenu = r_weapon_menu.GetChild(0).GetComponent<Text>();
        RDamageInMenu = r_weapon_menu.GetChild(1).GetComponent<Text>();
        RWeaponWeight = r_weapon_menu.GetChild(2).GetComponent<Text>();


        //поля для меню подбираемого оружия
        Sel_WeaponNameInMenu = selected_weapon_menu.GetChild(0).GetComponent<Text>();
        Sel_WeapDamageInMenu = selected_weapon_menu.GetChild(1).GetComponent<Text>();

        //скрипты
        camera_controller = GetComponent<CameraController>();
        FPC = GetComponent<FirstPersonController>();
        atackController = GetComponent<PlayerAtackController>();

        foreach (Transform child in left_hand.transform)//список оружия из левой руки
        {
            weaponsInLeftHand.Add(child);
        }
    }

    private void Update()
    {
        OutputToMenu();//Вывод и обновление информации в меню

        //вход и выход из меню
        if (Input.GetKeyDown(KeyCode.Tab)) EnteringTheMenu();
        else if(Input.GetKeyUp(KeyCode.Tab)|| Input.GetKeyUp(KeyCode.Escape)) WeaponMenuExit();
    }

    //Вывод характеристик подбираемого оружия
    public void OutputToDropWeaponMenu(string DropWeaponName)
    {
        foreach (Transform weapon in weaponsInLeftHand)
        {   
            if (weapon.name == DropWeaponName)
            {
                //Вывести характеристики в меню 
                Sel_WeaponNameInMenu.text = "Name: " + weapon.GetComponent<weapon_characteristiks>().weapon_name;
                Sel_WeapDamageInMenu.text = "Damage: " + weapon.GetComponent<weapon_characteristiks>().damage;
            }
            
        }
    }

    //вывод данных в меню
    private void OutputToMenu()
    {

        if (left_hand.GetComponentInChildren<weapon_characteristiks>() != null) //если оружие в левой руке
        {
            //Запомнить характеристики
            string LeftWeaponName = left_hand.GetComponentInChildren<weapon_characteristiks>().weapon_name;
            float DamageLHand = left_hand.GetComponentInChildren<weapon_characteristiks>().damage;
            int Weight_weapon = left_hand.GetComponentInChildren<weapon_characteristiks>().weight;

            //Вывести характеристики в меню 
            LWeaponNameInMenu.text = "Name: " + LeftWeaponName;
            LDamageInMenu.text = "Damage: " + DamageLHand.ToString();
            LWeaponWeight.text = "Weight: " + Weight_weapon.ToString();
        }

        if (right_hand.GetComponentInChildren<weapon_characteristiks>() != null)//если оружие в правой руке
        {
            //Запомнить характеристики
            string RightWeaponName = right_hand.GetComponentInChildren<weapon_characteristiks>().weapon_name;
            float DamageRHand = right_hand.GetComponentInChildren<weapon_characteristiks>().damage;
            int Weight_weapon = right_hand.GetComponentInChildren<weapon_characteristiks>().weight;


            //Вывести характеристики в меню 
            RWeaponNameInMenu.text = "Name: " + RightWeaponName;
            RDamageInMenu.text = "Damage: " + DamageRHand.ToString();
            RWeaponWeight.text = "Weight: " + Weight_weapon.ToString(); ;

        }
    }

    //включение меню оружия
    public void WeaponMenuEnther()
    {
        //Включение отображения меню оружия
        selected_weapon_menu.gameObject.SetActive(true);
        l_weapon_menu.gameObject.SetActive(true);
        r_weapon_menu.gameObject.SetActive(true);

        _WeaponChaingeMenuIsActive = true;

        //отключение движения игрока и камеры и скрипта атаки
        camera_controller.enabled = false;
        FPC.enabled = false;
        atackController.enabled = false;
    }

    //Выключение меню оружия
    public void WeaponMenuExit()
    {
        //Включение движения игрока и камеры и скрипта атаки
        camera_controller.enabled = true;
        FPC.enabled = true;
        atackController.enabled = true;

        _WeaponChaingeMenuIsActive = false;

        selected_weapon_menu.gameObject.SetActive(false);
        l_weapon_menu.gameObject.SetActive(false);
        r_weapon_menu.gameObject.SetActive(false);
    }
    
    //вход в меню
    public void EnteringTheMenu()
    {
        l_weapon_menu.gameObject.SetActive(true);
        r_weapon_menu.gameObject.SetActive(true);
    }
}
