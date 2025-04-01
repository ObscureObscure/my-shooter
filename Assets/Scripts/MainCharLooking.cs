using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCharLooking : MonoBehaviour
{
    public enum RotationAxes
    {
        XY,
        X,
        Y
    }

    public RotationAxes _axes = RotationAxes.XY;
    public float _rotationSpeed = 5.0f;
    public float maxVertAngle = 45.0f;
    public float minVertAngle = -45.0f;
    private float _rotationX = 0;
    Transform cubeTransform;
    void Awake()
    {
        cubeTransform = GetComponentInParent<Transform>();
    }
    void Update()
    {

        if (_axes == RotationAxes.XY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeed;
            _rotationX = Mathf.Clamp(_rotationX, minVertAngle, maxVertAngle);

            float delta = Input.GetAxis("Mouse X") * _rotationSpeed;
            float _rotationY = transform.localEulerAngles.y + delta;

            cubeTransform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);

            //Debug.Log(_rotationX);
        }
        else if (_axes == RotationAxes.X)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationSpeed, 0);
            //Debug.Log(Input.GetAxis("Mouse X"));
        }
        else if (_axes == RotationAxes.Y)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeed;
            _rotationX = Mathf.Clamp(_rotationX, minVertAngle, maxVertAngle);

            float _rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }

    }
}
