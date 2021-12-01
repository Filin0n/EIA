using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    //����
    //[SerializeField] private GameObject WeaponChaigeMenu;
    [SerializeField] private Transform l_weapon_menu;//���� ������ ����� ����
    [SerializeField]private Transform r_weapon_menu;//���� ������ ������ ����
    [SerializeField] private Transform selected_weapon_menu;//���� ������������ ������

    //���� ����� ����
    private Text LWeaponNameInMenu; //����� ����� ������ � ����� ���� 
    private Text LDamageInMenu;
    private Text LWeaponWeight;

    //���� ������ ����
    private Text RWeaponNameInMenu; //����� ����� ������ � ������ ���� 
    private Text RDamageInMenu;
    private Text RWeaponWeight;


    //���� ��� ������ ���������� � ���� ������������ ������
    private Text Sel_WeaponNameInMenu;
    private Text Sel_WeapDamageInMenu;

    //���� � ������
    [SerializeField] private GameObject right_hand;
    [SerializeField] private GameObject left_hand;

    private List<Transform> weaponsInLeftHand = new List<Transform>();//��� ������ � ����� ����

    private CameraController camera_controller;//������
    private FirstPersonController FPC;//���������� ������
    private PlayerAtackController atackController;//������ ���������� �� �����

    public bool _WeaponChaingeMenuIsActive = false;//���� ���� ������ ������ �������

    void Start()
    {
        //���� ��� ����� ����
        LWeaponNameInMenu = l_weapon_menu.GetChild(0).GetComponent<Text>();
        LDamageInMenu = l_weapon_menu.GetChild(1).GetComponent<Text>();
        LWeaponWeight = l_weapon_menu.GetChild(2).GetComponent<Text>();

        //���� ��� ������ ����
        RWeaponNameInMenu = r_weapon_menu.GetChild(0).GetComponent<Text>();
        RDamageInMenu = r_weapon_menu.GetChild(1).GetComponent<Text>();
        RWeaponWeight = r_weapon_menu.GetChild(2).GetComponent<Text>();


        //���� ��� ���� ������������ ������
        Sel_WeaponNameInMenu = selected_weapon_menu.GetChild(0).GetComponent<Text>();
        Sel_WeapDamageInMenu = selected_weapon_menu.GetChild(1).GetComponent<Text>();

        //�������
        camera_controller = GetComponent<CameraController>();
        FPC = GetComponent<FirstPersonController>();
        atackController = GetComponent<PlayerAtackController>();

        foreach (Transform child in left_hand.transform)//������ ������ �� ����� ����
        {
            weaponsInLeftHand.Add(child);
        }
    }

    private void Update()
    {
        OutputToMenu();//����� � ���������� ���������� � ����

        //���� � ����� �� ����
        if (Input.GetKeyDown(KeyCode.Tab)) EnteringTheMenu();
        else if(Input.GetKeyUp(KeyCode.Tab)|| Input.GetKeyUp(KeyCode.Escape)) WeaponMenuExit();
    }

    //����� ������������� ������������ ������
    public void OutputToDropWeaponMenu(string DropWeaponName)
    {
        foreach (Transform weapon in weaponsInLeftHand)
        {   
            if (weapon.name == DropWeaponName)
            {
                //������� �������������� � ���� 
                Sel_WeaponNameInMenu.text = "Name: " + weapon.GetComponent<weapon_characteristiks>().weapon_name;
                Sel_WeapDamageInMenu.text = "Damage: " + weapon.GetComponent<weapon_characteristiks>().damage;
            }
            
        }
    }

    //����� ������ � ����
    private void OutputToMenu()
    {

        if (left_hand.GetComponentInChildren<weapon_characteristiks>() != null) //���� ������ � ����� ����
        {
            //��������� ��������������
            string LeftWeaponName = left_hand.GetComponentInChildren<weapon_characteristiks>().weapon_name;
            float DamageLHand = left_hand.GetComponentInChildren<weapon_characteristiks>().damage;
            int Weight_weapon = left_hand.GetComponentInChildren<weapon_characteristiks>().weight;

            //������� �������������� � ���� 
            LWeaponNameInMenu.text = "Name: " + LeftWeaponName;
            LDamageInMenu.text = "Damage: " + DamageLHand.ToString();
            LWeaponWeight.text = "Weight: " + Weight_weapon.ToString();
        }

        if (right_hand.GetComponentInChildren<weapon_characteristiks>() != null)//���� ������ � ������ ����
        {
            //��������� ��������������
            string RightWeaponName = right_hand.GetComponentInChildren<weapon_characteristiks>().weapon_name;
            float DamageRHand = right_hand.GetComponentInChildren<weapon_characteristiks>().damage;
            int Weight_weapon = right_hand.GetComponentInChildren<weapon_characteristiks>().weight;


            //������� �������������� � ���� 
            RWeaponNameInMenu.text = "Name: " + RightWeaponName;
            RDamageInMenu.text = "Damage: " + DamageRHand.ToString();
            RWeaponWeight.text = "Weight: " + Weight_weapon.ToString(); ;

        }
    }

    //��������� ���� ������
    public void WeaponMenuEnther()
    {
        //��������� ����������� ���� ������
        selected_weapon_menu.gameObject.SetActive(true);
        l_weapon_menu.gameObject.SetActive(true);
        r_weapon_menu.gameObject.SetActive(true);

        _WeaponChaingeMenuIsActive = true;

        //���������� �������� ������ � ������ � ������� �����
        camera_controller.enabled = false;
        FPC.enabled = false;
        atackController.enabled = false;
    }

    //���������� ���� ������
    public void WeaponMenuExit()
    {
        //��������� �������� ������ � ������ � ������� �����
        camera_controller.enabled = true;
        FPC.enabled = true;
        atackController.enabled = true;

        _WeaponChaingeMenuIsActive = false;

        selected_weapon_menu.gameObject.SetActive(false);
        l_weapon_menu.gameObject.SetActive(false);
        r_weapon_menu.gameObject.SetActive(false);
    }
    
    //���� � ����
    public void EnteringTheMenu()
    {
        l_weapon_menu.gameObject.SetActive(true);
        r_weapon_menu.gameObject.SetActive(true);
    }
}
