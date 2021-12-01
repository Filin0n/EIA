using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_weapon : MonoBehaviour
{
    [SerializeField] private GameObject right_hand;
    [SerializeField] private GameObject left_hand;

     private List<Transform> weaponsInRightHand = new List<Transform>();//��� ������ � ������ ����
     private List<Transform> weaponsInLeftHand = new List<Transform>();//��� ������ � ����� ����

    private string weaponName = "EmptyHand"; //��� ������ ������� �������� �����

    private Interface _interface;//������ �������� ����������
    private interactive _interactive;//������ �������������� � ����������

    weapon_characteristiks dropWeapon;//����������� ������
    private bool WeaponChaingeMenuIsActive = false;//���� ���� ������ ������ �������

    private void Start()
    {
        _interface = GetComponent<Interface>();
        _interactive = GetComponent<interactive>();

        //���������� ������� ������
        foreach (Transform child in right_hand.transform)//������ ������ �� ������ ����
        {            
            weaponsInRightHand.Add(child);
        }
        foreach (Transform child in left_hand.transform)//������ ������ �� ����� ����
        {
            weaponsInLeftHand.Add(child);
        }
    }

    private void Update()
    {
        //���� ���� ������ ������ �������
        WeaponChaingeMenuIsActive = _interface._WeaponChaingeMenuIsActive;
        if (Input.GetKeyDown(KeyCode.Mouse0) && WeaponChaingeMenuIsActive)ToLeftHand();
        if (Input.GetKeyDown(KeyCode.Mouse1) && WeaponChaingeMenuIsActive)ToRightHand();
    }

    public void ChaingeWeapon(string WeaponName, weapon_characteristiks drop_weapon)//����� ������ � ����������� �� ���� �����
    {
        weaponName = WeaponName;
        dropWeapon = drop_weapon;
        _interface.WeaponMenuEnther();//��������� ��� ������
    }

   public void ToLeftHand()//� ����� ����
   {
        //������ ��� ������ � ������ ����
        weapon_characteristiks RH_Charact = right_hand.GetComponentInChildren<weapon_characteristiks>();
        int r_handWeight = RH_Charact != null ? RH_Charact.weight : 0;

        // ���� ����� ��� ������ � ����� ����� �� ������ ����������� ����
        if ((dropWeapon.weight + r_handWeight) <= 4)
        { 
            foreach (Transform weapon in weaponsInLeftHand)//����������� �������� ������ � ����
            {
                if (weapon.gameObject.activeSelf)//���� ������ ������� ��������� ���
                {
                    Debug.Log("�� ��������� " + weapon.name);
                    //��������� ������
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
                else if (weapon.name == weaponName) //����� ���� ��� ������ ����� ����� ������������ ������, �������� ���
                {
                    weapon.gameObject.SetActive(true);
                    dropWeapon.Destroy();
                }

            }
        }
        // ���� ����� ��� ������ � ����� ����� ������ ����������� ����
        else
        {
            foreach (Transform weapon in weaponsInLeftHand)//����������� �������� ������ � ����
            {
                if (weapon.gameObject.activeSelf)//���� ������ ������� ��������� ���
                {
                    Debug.Log("�� ��������� " + weapon.name);
                    //��������� ������
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
                else if (weapon.name == weaponName) //����� ���� ��� ������ ����� ����� ������������ ������, �������� ���
                {
                    weapon.gameObject.SetActive(true);
                    dropWeapon.Destroy();
                }
            }

            //��������� ������ �� ������ ����
            foreach (Transform weapon in weaponsInRightHand)//����������� �������� ������ � ����
            {
                if (weapon.gameObject.activeSelf)//���� ������ ������� ��������� ���
                {
                    Debug.Log("�� ��������� " + weapon.name);
                    //��������� ������
                    _interactive.DropWeapon(weapon);
                    weapon.gameObject.SetActive(false);
                }
            }

                Debug.Log("��������� ������ �� ������ ����");
        }
        weaponName = "EmptyHand";
        _interface.WeaponMenuExit();//���������� ��� ������
   } 
   public void ToRightHand()//� ������ ����
   {
        //������ ��� ������ � ����� ����
        weapon_characteristiks LH_Charact = left_hand.GetComponentInChildren<weapon_characteristiks>();
        int l_handWeight = LH_Charact != null ? LH_Charact.weight : 0;

        // ���� ����� ��� ������ � ����� ����� �� ������ ����������� ����
        if ((dropWeapon.weight + l_handWeight) <= 4)
        {
            //����� ������
            foreach (Transform weapon in weaponsInRightHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("�� ��������� " + weapon.name);
                    _interactive.DropWeapon(weapon);//��������� ������
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
        // ���� ����� ��� ������ � ����� ����� ������ ����������� ����
        else
        {
            foreach (Transform weapon in weaponsInRightHand)
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("�� ��������� " + weapon.name);
                    _interactive.DropWeapon(weapon);//��������� ������
                    weapon.gameObject.SetActive(false);
                }

                if (weaponName == "EmptyHand") return;
                else if (weapon.name == weaponName)
                {
                    weapon.gameObject.SetActive(true);
                    dropWeapon.Destroy();
                }
            }
            foreach (Transform weapon in weaponsInLeftHand)//��������� ������ �� ����� ����
            {
                if (weapon.gameObject.activeSelf)
                {
                    Debug.Log("�� ��������� " + weapon.name);
                    _interactive.DropWeapon(weapon);//��������� ������
                    weapon.gameObject.SetActive(false);
                }
            }
        }
        weaponName = "EmptyHand";
        _interface.WeaponMenuExit();//���������� ���� ������
   }

}
