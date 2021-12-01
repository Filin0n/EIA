using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtackController : MonoBehaviour
{
    //Анимации рук
    [SerializeField]private Animator animRightHand;
    [SerializeField]private Animator animLeftHand;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) animRightHand.SetTrigger("Atack1");
        if (Input.GetKeyDown(KeyCode.Mouse1)) animLeftHand.SetTrigger("Atack1");

    }
}
