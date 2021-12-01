using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private float _vertical, _horisontal;//вектора перемещени€ 
    private CharacterController _controller; //контроллер

    [SerializeField] private float walkSpeed; //скорость ходьбы персонажа
    [SerializeField] private float runSpeed; //скорость бега персонажа
    [SerializeField] [Range(0, 10)]  private float smoothSpeed; //плавное переключение скорости
    [SerializeField] private float Current_Speed;
    [SerializeField] [Range(0.0f, 2.0f)] public float jumpForce; //сила прыжка персонажа
    [SerializeField] [Range(0.0f, 2.0f)] public float GravityForce;  //гравитаци€
    private Vector3 _direction; //направление перемещени€
    private float gravity;

    void Start()
    {
        _controller = GetComponent<CharacterController>(); //присвоение контроллера
    }

    void Update()
    {
        Movment(); //метод перемещени€ персонажа
        GamingGravity();//гравитаци€
    }

    private void Movment()//ћетод ѕеремещение персонажа
    {
        if (_controller.isGrounded) //если персонаж на земле то им можно управл€ть
        {
            _horisontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _direction = transform.TransformDirection(_horisontal, 0, _vertical).normalized; //вычисление направлени€ движени€
            Jump();
        }
        _direction.y -= gravity; //гравитаци€
        float speed = Speed(); //скорость персонажа

        //¬ычисление перемещени€ игрока
        Vector3 dir = _direction * speed * Time.deltaTime;
        dir.y = _direction.y;
        _controller.Move(dir);
    }

    private void Jump()//ћетод дл€ прыжка
    {
        if (Input.GetKeyDown(KeyCode.Space)) _direction.y += jumpForce / 10;
    }

    private void GamingGravity()//метод гравитации
    {
        gravity = !_controller.isGrounded ? (GravityForce * Time.deltaTime) : 0.1f * Time.deltaTime;
    }

    private float Speed()//Ѕег
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
