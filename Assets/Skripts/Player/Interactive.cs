using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistanceRay;
    [SerializeField] private GameObject _pressE;
    [SerializeField] private List<GameObject> _dropWaponsPrefabs;

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }

    private void Ray()
    {
        _ray = _camera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);
        }
        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);
        }
    }

    private void Interact()
    {
        OpenDoor();
        PickUp();

    }

    private void OpenDoor()
    {
        if (_hit.transform != null && _hit.transform.GetComponent<Door>())
        {
            _pressE.SetActive(true);

            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);

            if (Input.GetKeyDown(KeyCode.E))
            {
                _hit.transform.GetComponent<Door>().Open();
            }
        }
        else
        {
            _pressE.SetActive(false);
        }
    }

    private void PickUp()
    {

        if (_hit.transform != null && _hit.transform.GetComponent<weapon_characteristiks>())
        {
            _pressE.SetActive(true);
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);

            if (Input.GetKeyDown(KeyCode.E))
            {
                string weaponName = _hit.transform.GetComponent<weapon_characteristiks>().weaponName;
                weapon_characteristiks drop_weapon = _hit.transform.GetComponent<weapon_characteristiks>();

                GetComponent<Interface>().OutputToDropWeaponMenu(weaponName);
                GetComponent<PlayerWeapon>().ChaingeWeapon(weaponName , drop_weapon);
            }
        }
       
    }

    public void DropWeapon(Transform dropObj)
    {
        foreach (GameObject weapon in _dropWaponsPrefabs)
        {
            if (dropObj.name == weapon.name)
            {
                Instantiate(weapon, dropObj.position, dropObj.rotation);
            }
        }
    }
}
