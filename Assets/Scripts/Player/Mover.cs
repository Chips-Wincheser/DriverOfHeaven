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

    [Range(10f, 300f)]
    [SerializeField] private float _maxSpeedKmh = 50f;

    private float _speedConversionFactor = 3.6f;
    private float _currentBrake;

    private Rigidbody _rigidbody;

    private Single _acceleration;
    private Single _streering;

    public float Speed { get; private set; }
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
        Speed = GetSpeed();

        foreach (var wheel in _rearWheels)
        {
            if (Speed < _maxSpeedKmh || _acceleration < 0f)
            {
                wheel.motorTorque = _acceleration * _torque;
            }
            else
            {
                wheel.motorTorque = 0f;
            }
        }

        WheelCollider[] array = _frontWheels;

        for (int i = 0; i < array.Length; i++)
        {
            array[i].steerAngle = _streering * _maxAngle;
        }

        ApplyToWheels(_rearWheels);
        ApplyToWheels(_frontWheels);

        WheelUpdated?.Invoke(_frontWheels);
    }

    private float GetSpeed()
    {
        return Mathf.Round(_rigidbody.velocity.magnitude * _speedConversionFactor * 10f) / 10f;
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
}
