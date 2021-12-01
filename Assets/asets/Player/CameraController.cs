using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float xRot, yRot;//переменные для определения необходимого угла поворота
    private float xCurrRot, yCurrRot;//переменные для определения текущего угла поворота
    
    [SerializeField]
    private Camera Camera; //камера
    [SerializeField]
    private GameObject Object; //контроллер

    public float mouseSensetive = 1; //чувствительность мыши

    private float xRotVelociyt, yRotVelociyt; //чувствительность поворота по оси X и Y

    private float smoothDampTime =0.1f;  //время сглаживания

    //ограничение поворота камеры по вертикали
    public float minimumAngle = -90; //минимальный угол 
    public float maximumAngle = 90; //максимальный угол

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // фиксация курсора в центре экрана
        Cursor.visible = false; // отключить отображение курсора
    }

    void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        xRot += Input.GetAxis("Mouse Y") * mouseSensetive;
        yRot += Input.GetAxis("Mouse X") * mouseSensetive;
        xRot = Mathf.Clamp(xRot, minimumAngle, maximumAngle); //ограничение камеры вверх вниз

        xCurrRot = Mathf.SmoothDamp(xCurrRot, xRot, ref xRotVelociyt, smoothDampTime);
        yCurrRot = Mathf.SmoothDamp(yCurrRot, yRot, ref yRotVelociyt, smoothDampTime);

        Camera.transform.rotation = Quaternion.Euler(-xCurrRot,yCurrRot,0f);//изменения поворота камеры

        Object.transform.rotation = Quaternion.Euler(0f,yCurrRot,0f);  //изменение угла поворота для объекта
    }

}
