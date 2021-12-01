using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpcCamera; //Камера
    private Ray _ray; //луч
    private RaycastHit _hit; //Значения обекта сталкивания
    [SerializeField] private float _maxDistanceRay; //Длина луча

    [SerializeField] private GameObject press_e;

    [SerializeField] private List<GameObject> DropEwaponsPrefabs;//Список префабов выбрасывоемого оружия


    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }

    private void Ray()
    {
        _ray = _fpcCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2)); //точка выпускания луча
    }

    private void DrawRay() //Отрисовка луча
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay)) //Если луч сталкивается
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue); //отрисовка луча
        }
        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red); //отрисовка луча

        }
    }

    private void Interact()//Метод взаимодействия с обьектами
    {
        OpenDoor();
        pick_up();

    }

    private void OpenDoor()//открытие двери
    {
        if (_hit.transform != null && _hit.transform.GetComponent<Door>()) //Если это дверь
        {
            press_e.SetActive(true);
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);//отрисовка зеленого луча
           
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hit.transform.GetComponent<Door>().Open();//открытие двери
            }
        }
        else press_e.SetActive(false);

    }

    private void pick_up()//подобрать
    {

        if (_hit.transform != null && _hit.transform.GetComponent<weapon_characteristiks>()) //если это оружие
        {
            press_e.SetActive(true);
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);//отрисовка зеленого луча

            if (Input.GetKeyDown(KeyCode.E)) //Нажатие на клавишу Е
            {
                string weaponName = _hit.transform.GetComponent<weapon_characteristiks>().weapon_name; //узнать имя оружия
                weapon_characteristiks drop_weapon = _hit.transform.GetComponent<weapon_characteristiks>();//ссылка на объект в сцене

                GetComponent<Interface>().OutputToDropWeaponMenu(weaponName); //заполнить меню подобранного оружия

                GetComponent<Player_weapon>().ChaingeWeapon(weaponName , drop_weapon);//отправка имени и ссылки в скрипт смены оружия
               
            }
        }
       
    }

    public void DropWeapon(Transform dropObj)//Выбросить
    {
        //Debug.Log("Вы выбросили " + dropObj.name);

        foreach (GameObject weapon in DropEwaponsPrefabs)
        {
            if (dropObj.name == weapon.name)
            {
                //выбросить обьект на сцену
                Instantiate(weapon, dropObj.position, dropObj.rotation);
            }
           
        }
    }

   

}
