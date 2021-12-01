using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private Transform _leftWeapoMenu;
    [SerializeField] private Transform _rightWeaponMenu;
    [SerializeField] private Transform _selectedWeaponMenu;
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private GameObject _leftHand;

    [HideInInspector] public bool weaponChaingeMenuIsActive = false;//если меню выбора оружия активно

    private Text _leftWeaponNameInMenu;
    private Text _leftDamageInMenu;
    private Text _leftWeaponWeight;

    private Text _rightWeaponNameInMenu;
    private Text _rightDamageInMenu;
    private Text _rightWeaponWeight;

    private Text _selectionWeaponNameInMenu;
    private Text _selectionWeapDamageInMenu;

    private List<Transform> _weaponsInLeftHand = new List<Transform>();

    private CameraController _cameraController;
    private FirstPersonController _firstPersonController;
    private PlayerAtackController _atackController;


    void Start()
    {
        _leftWeaponNameInMenu = _leftWeapoMenu.GetChild(0).GetComponent<Text>();
        _leftDamageInMenu = _leftWeapoMenu.GetChild(1).GetComponent<Text>();
        _leftWeaponWeight = _leftWeapoMenu.GetChild(2).GetComponent<Text>();

        _rightWeaponNameInMenu = _rightWeaponMenu.GetChild(0).GetComponent<Text>();
        _rightDamageInMenu = _rightWeaponMenu.GetChild(1).GetComponent<Text>();
        _rightWeaponWeight = _rightWeaponMenu.GetChild(2).GetComponent<Text>();

        _selectionWeaponNameInMenu = _selectedWeaponMenu.GetChild(0).GetComponent<Text>();
        _selectionWeapDamageInMenu = _selectedWeaponMenu.GetChild(1).GetComponent<Text>();

        _cameraController = GetComponent<CameraController>();
        _firstPersonController = GetComponent<FirstPersonController>();
        _atackController = GetComponent<PlayerAtackController>();

        foreach (Transform child in _leftHand.transform)
        {
            _weaponsInLeftHand.Add(child);
        }
    }

    private void Update()
    {
        OutputToMenu();

        if (Input.GetKeyDown(KeyCode.Tab)) EnteringTheMenu();
        else if(Input.GetKeyUp(KeyCode.Tab)|| Input.GetKeyUp(KeyCode.Escape)) WeaponMenuExit();
    }

    public void OutputToDropWeaponMenu(string dropWeaponName)
    {
        foreach (Transform weapon in _weaponsInLeftHand)
        {   
            if (weapon.name == dropWeaponName)
            {
                _selectionWeaponNameInMenu.text = "Name: " + weapon.GetComponent<weapon_characteristiks>().weaponName;
                _selectionWeapDamageInMenu.text = "Damage: " + weapon.GetComponent<weapon_characteristiks>().damage;
            }
        }
    }

    private void OutputToMenu()
    {
        if (_leftHand.GetComponentInChildren<weapon_characteristiks>() != null)
        {
            string leftWeaponName = _leftHand.GetComponentInChildren<weapon_characteristiks>().weaponName;
            float damageLHand = _leftHand.GetComponentInChildren<weapon_characteristiks>().damage;
            int weight_weapon = _leftHand.GetComponentInChildren<weapon_characteristiks>().weight;

            _leftWeaponNameInMenu.text = "Name: " + leftWeaponName;
            _leftDamageInMenu.text = "Damage: " + damageLHand.ToString();
            _leftWeaponWeight.text = "Weight: " + weight_weapon.ToString();
        }

        if (_rightHand.GetComponentInChildren<weapon_characteristiks>() != null)
        {
            string RightWeaponName = _rightHand.GetComponentInChildren<weapon_characteristiks>().weaponName;
            float damageRHand = _rightHand.GetComponentInChildren<weapon_characteristiks>().damage;
            int weightWeapon = _rightHand.GetComponentInChildren<weapon_characteristiks>().weight;

            _rightWeaponNameInMenu.text = "Name: " + RightWeaponName;
            _rightDamageInMenu.text = "Damage: " + damageRHand.ToString();
            _rightWeaponWeight.text = "Weight: " + weightWeapon.ToString();
        }
    }

    public void WeaponMenuEnther()
    {
        _selectedWeaponMenu.gameObject.SetActive(true);
        _leftWeapoMenu.gameObject.SetActive(true);
        _rightWeaponMenu.gameObject.SetActive(true);

        weaponChaingeMenuIsActive = true;

        _cameraController.enabled = false;
        _firstPersonController.enabled = false;
        _atackController.enabled = false;
    }

    public void WeaponMenuExit()
    {
        _cameraController.enabled = true;
        _firstPersonController.enabled = true;
        _atackController.enabled = true;

        weaponChaingeMenuIsActive = false;
        _selectedWeaponMenu.gameObject.SetActive(false);
        _leftWeapoMenu.gameObject.SetActive(false);
        _rightWeaponMenu.gameObject.SetActive(false);
    }
    
    public void EnteringTheMenu()
    {
        _leftWeapoMenu.gameObject.SetActive(true);
        _rightWeaponMenu.gameObject.SetActive(true);
    }
}
