using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private float _vertical, _horisontal;//������� ����������� 
    private CharacterController _controller; //����������

    [SerializeField] private float walkSpeed; //�������� ������ ���������
    [SerializeField] private float runSpeed; //�������� ���� ���������
    [SerializeField] [Range(0, 10)]  private float smoothSpeed; //������� ������������ ��������
    [SerializeField] private float Current_Speed;
    [SerializeField] [Range(0.0f, 2.0f)] public float jumpForce; //���� ������ ���������
    [SerializeField] [Range(0.0f, 2.0f)] public float GravityForce;  //����������
    private Vector3 _direction; //����������� �����������
    private float gravity;

    void Start()
    {
        _controller = GetComponent<CharacterController>(); //���������� �����������
    }

    void Update()
    {
        Movment(); //����� ����������� ���������
        GamingGravity();//����������
    }

    private void Movment()//����� ����������� ���������
    {
        if (_controller.isGrounded) //���� �������� �� ����� �� �� ����� ���������
        {
            _horisontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _direction = transform.TransformDirection(_horisontal, 0, _vertical).normalized; //���������� ����������� ��������
            Jump();
        }
        _direction.y -= gravity; //����������
        float speed = Speed(); //�������� ���������

        //���������� ����������� ������
        Vector3 dir = _direction * speed * Time.deltaTime;
        dir.y = _direction.y;
        _controller.Move(dir);
    }

    private void Jump()//����� ��� ������
    {
        if (Input.GetKeyDown(KeyCode.Space)) _direction.y += jumpForce / 10;
    }

    private void GamingGravity()//����� ����������
    {
        gravity = !_controller.isGrounded ? (GravityForce * Time.deltaTime) : 0.1f * Time.deltaTime;
    }

    private float Speed()//���
    { 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Current_Speed = Mathf.Lerp(Current_Speed, runSpeed, smoothSpeed * Time.deltaTime);
        }
        else
        {
            Current_Speed = Mathf.Lerp(Current_Speed, walkSpeed, smoothSpeed * Time.deltaTime);

        }
        return Current_Speed;
    }
}
