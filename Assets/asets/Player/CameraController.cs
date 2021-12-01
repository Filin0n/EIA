using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float xRot, yRot;//���������� ��� ����������� ������������ ���� ��������
    private float xCurrRot, yCurrRot;//���������� ��� ����������� �������� ���� ��������
    
    [SerializeField]
    private Camera Camera; //������
    [SerializeField]
    private GameObject Object; //����������

    public float mouseSensetive = 1; //���������������� ����

    private float xRotVelociyt, yRotVelociyt; //���������������� �������� �� ��� X � Y

    private float smoothDampTime =0.1f;  //����� �����������

    //����������� �������� ������ �� ���������
    public float minimumAngle = -90; //����������� ���� 
    public float maximumAngle = 90; //������������ ����

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // �������� ������� � ������ ������
        Cursor.visible = false; // ��������� ����������� �������
    }

    void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        xRot += Input.GetAxis("Mouse Y") * mouseSensetive;
        yRot += Input.GetAxis("Mouse X") * mouseSensetive;
        xRot = Mathf.Clamp(xRot, minimumAngle, maximumAngle); //����������� ������ ����� ����

        xCurrRot = Mathf.SmoothDamp(xCurrRot, xRot, ref xRotVelociyt, smoothDampTime);
        yCurrRot = Mathf.SmoothDamp(yCurrRot, yRot, ref yRotVelociyt, smoothDampTime);

        Camera.transform.rotation = Quaternion.Euler(-xCurrRot,yCurrRot,0f);//��������� �������� ������

        Object.transform.rotation = Quaternion.Euler(0f,yCurrRot,0f);  //��������� ���� �������� ��� �������
    }

}
