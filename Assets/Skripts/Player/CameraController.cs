using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera; 
    [SerializeField] private GameObject _player;
    [SerializeField] private float _mouseSensetive;
    [SerializeField] private float _smoothDampTime;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;

    private float _xRotationVelocity, yRotationVelocity;
    private float _xRotation, _yRotation;
    private float _xCurrentRotation, _yCurrentRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        _xRotation += Input.GetAxis("Mouse Y") * _mouseSensetive;
        _yRotation += Input.GetAxis("Mouse X") * _mouseSensetive;
        _xRotation = Mathf.Clamp(_xRotation, _minAngle, _maxAngle);

        _xCurrentRotation = Mathf.SmoothDamp(_xCurrentRotation, _xRotation, ref _xRotationVelocity, _smoothDampTime);
        _yCurrentRotation = Mathf.SmoothDamp(_yCurrentRotation, _yRotation, ref yRotationVelocity, _smoothDampTime);

        _camera.transform.rotation = Quaternion.Euler(-_xCurrentRotation, _yCurrentRotation, 0f);
        _player.transform.rotation = Quaternion.Euler(0f, _yCurrentRotation, 0f);
    }
}
