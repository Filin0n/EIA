using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed; 
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] public float GravityForce;

    private CharacterController _characterController;
    private Vector3 _direction;
    private float _gravity;
    private float _vertical, _horisontal;
    private float _currentSpeed;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movment(); 
        GamingGravity();
    }

    private void Movment()
    {
        if (_characterController.isGrounded)
        {
            _horisontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _direction = transform.TransformDirection(_horisontal, 0, _vertical).normalized;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _direction.y += jumpForce / 10;
            }
        }

        _direction.y -= _gravity;

        Vector3 direction = _direction * Speed() * Time.deltaTime;
        _characterController.Move(direction);
    }

    private void GamingGravity()
    {
        _gravity = !_characterController.isGrounded ? (GravityForce * Time.deltaTime) : 0.1f * Time.deltaTime;
    }

    private float Speed()
    { 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, _runSpeed, _smoothSpeed * Time.deltaTime);
        }
        else
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, _walkSpeed, _smoothSpeed * Time.deltaTime);
        }
        return _currentSpeed;
    }
}
