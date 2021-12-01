using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpcCamera; //������
    private Ray _ray; //���
    private RaycastHit _hit; //�������� ������ �����������
    [SerializeField] private float _maxDistanceRay; //����� ����

    [SerializeField] private GameObject press_e;

    [SerializeField] private List<GameObject> DropEwaponsPrefabs;//������ �������� �������������� ������


    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }

    private void Ray()
    {
        _ray = _fpcCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2)); //����� ���������� ����
    }

    private void DrawRay() //��������� ����
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay)) //���� ��� ������������
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue); //��������� ����
        }
        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red); //��������� ����

        }
    }

    private void Interact()//����� �������������� � ���������
    {
        OpenDoor();
        pick_up();

    }

    private void OpenDoor()//�������� �����
    {
        if (_hit.transform != null && _hit.transform.GetComponent<Door>()) //���� ��� �����
        {
            press_e.SetActive(true);
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);//��������� �������� ����
           
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hit.transform.GetComponent<Door>().Open();//�������� �����
            }
        }
        else press_e.SetActive(false);

    }

    private void pick_up()//���������
    {

        if (_hit.transform != null && _hit.transform.GetComponent<weapon_characteristiks>()) //���� ��� ������
        {
            press_e.SetActive(true);
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);//��������� �������� ����

            if (Input.GetKeyDown(KeyCode.E)) //������� �� ������� �
            {
                string weaponName = _hit.transform.GetComponent<weapon_characteristiks>().weapon_name; //������ ��� ������
                weapon_characteristiks drop_weapon = _hit.transform.GetComponent<weapon_characteristiks>();//������ �� ������ � �����

                GetComponent<Interface>().OutputToDropWeaponMenu(weaponName); //��������� ���� ������������ ������

                GetComponent<Player_weapon>().ChaingeWeapon(weaponName , drop_weapon);//�������� ����� � ������ � ������ ����� ������
               
            }
        }
       
    }

    public void DropWeapon(Transform dropObj)//���������
    {
        //Debug.Log("�� ��������� " + dropObj.name);

        foreach (GameObject weapon in DropEwaponsPrefabs)
        {
            if (dropObj.name == weapon.name)
            {
                //��������� ������ �� �����
                Instantiate(weapon, dropObj.position, dropObj.rotation);
            }
           
        }
    }

   

}
