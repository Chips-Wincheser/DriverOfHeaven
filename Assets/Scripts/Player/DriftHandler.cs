using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DriftHandler : MonoBehaviour
{
    [SerializeField] private float handbrakeDriftMultiplier = 10f;
    [SerializeField] private WheelCollider[] _rearWheels;

    private WheelFrictionCurve[] _originalRearFriction;
    private float _driftingAxis = 0f;
    private bool _handbrakePressedThisFrame = false;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (_rearWheels != null && _rearWheels.Length > 0)
        {
            _originalRearFriction = new WheelFrictionCurve[_rearWheels.Length];
            for (int i = 0; i < _rearWheels.Length; i++)
            {
                _originalRearFriction[i] = _rearWheels[i].sidewaysFriction;
            }
        }
        else
        {
            _originalRearFriction = new WheelFrictionCurve[0];
        }
    }

    private void FixedUpdate()
    {
        if (!_handbrakePressedThisFrame)
        {
            RecoverTraction();
        }

        _handbrakePressedThisFrame = false;
    }

    private void RecoverTraction()
    {
        if (_driftingAxis <= 0f)
        {
            return;
        }

        _driftingAxis -= Time.fixedDeltaTime / 1.5f;
        if (_driftingAxis < 0f) _driftingAxis = 0f;

        if (_driftingAxis > 0f && _rearWheels != null && _rearWheels.Length == _originalRearFriction.Length)
        {
            for (int i = 0; i < _rearWheels.Length; i++)
            {
                WheelFrictionCurve curve = _originalRearFriction[i];
                curve.extremumSlip = _originalRearFriction[i].extremumSlip * handbrakeDriftMultiplier * _driftingAxis;
                _rearWheels[i].sidewaysFriction = curve;
            }
        }
        else
        {
            if (_rearWheels != null && _rearWheels.Length == _originalRearFriction.Length)
            {
                for (int i = 0; i < _rearWheels.Length; i++)
                {
                    _rearWheels[i].sidewaysFriction = _originalRearFriction[i];
                }
            }
        }
    }

    public void ProcessBreak()
    {
        _handbrakePressedThisFrame = true;

        _driftingAxis += Time.deltaTime;
        _driftingAxis = Mathf.Clamp01(_driftingAxis);

        float localVelocityX = transform.InverseTransformDirection(_rigidbody.velocity).x;

        if (_rearWheels != null && _rearWheels.Length == _originalRearFriction.Length)
        {
            for (int i = 0; i < _rearWheels.Length; i++)
            {
                WheelFrictionCurve curve = _originalRearFriction[i];
                curve.extremumSlip = _originalRearFriction[i].extremumSlip * handbrakeDriftMultiplier * _driftingAxis;
                _rearWheels[i].sidewaysFriction = curve;
            }
        }
    }
}
