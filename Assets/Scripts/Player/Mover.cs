using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private WheelCollider[] _frontWheels;
    [SerializeField] private WheelCollider[] _rearWheels;

    [SerializeField] private Transform _centerOfMass;

    [SerializeField] private float _torque;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _maxBrake = 3000f;
    [SerializeField] private float _brakeSpeed = 10000f;
    [SerializeField] private float _naturalDrag = 0.5f;

    private float _currentBrake;

    private Rigidbody _rigidbody;

    private Single _acceleration;
    private Single _streering;

    public event Action<WheelCollider[]> WheelUpdated;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.centerOfMass=_centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        foreach (var wheel in _rearWheels)
        {
            wheel.motorTorque =_acceleration * _torque;
        }
        foreach (var wheel in _frontWheels)
        {
            wheel.steerAngle = _streering * _maxAngle;
        }

        ApplyToWheels(_rearWheels);
        ApplyToWheels(_frontWheels);

        WheelUpdated?.Invoke(_frontWheels);
    }

    private void ApplyToWheels(WheelCollider[] wheels)
    {
        foreach (var wheel in wheels)
        {
            if (_acceleration == 0 && _currentBrake == 0)
            {
                wheel.brakeTorque = _torque * _naturalDrag;
            }
            else
            {
                wheel.brakeTorque = _currentBrake;
            }
        }
    }

    public void ProcessMovement(float vertical , float horizontal)
    {
        _acceleration=vertical;
        _streering =horizontal;
        
        if (vertical != 0f)
        {
            _currentBrake = 0f;
        }
    }

    public void ProcessBreak()
    {
        _currentBrake += _brakeSpeed * Time.fixedDeltaTime;

        if (_currentBrake > _maxBrake)
            _currentBrake = _maxBrake;
    }
}
