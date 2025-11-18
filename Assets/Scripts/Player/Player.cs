using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TouchInput[] _touchInputs;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Mover _mover;
    [SerializeField] private DriftHandler _driftHandler;

    private float _vertical;
    private float _horizontal;
    private bool _isDrifting=false;

    public event Action Drifted;
    public event Action UnDrifted;

    private void OnEnable()
    {
        PlayerPrefs.SetInt("SystemMove", 0);
        if (PlayerPrefs.GetInt("SystemMove") == 1)
        {
            foreach (var item in _touchInputs)
            {
                item.ButtonPressed += OnButtonPressed;
                item.ButtonReleased += OnButtonReleased;
            }
        }
        else
        {
            _input.Brakeing += OnDrift;
            _input.Ridesing += OnRides;
        }
    }

    private void OnDisable()
    {
        if (PlayerPrefs.GetInt("SystemMove") == 1)
        {
            foreach (var item in _touchInputs)
            {
                item.ButtonPressed -= OnButtonPressed;
                item.ButtonReleased -= OnButtonReleased;
            }
        }
        else
        {
            _input.Brakeing -= OnDrift;
            _input.Ridesing -= OnRides;
        }
    }

    private void Update()
    {
        if (_isDrifting)
        {
            OnDrift();
        }
        else
        {
            UnDrifted?.Invoke();
        }
    }

    private void OnDrift()
    {
        Drifted?.Invoke();
        _driftHandler.ProcessBreak();
    }

    private void OnRides(float vertical, float horizontal)
    {
        _mover.ProcessMovement(vertical, horizontal);
    }

    private void OnButtonPressed(TouchButtonType buttonType)
    {
        switch (buttonType)
        {
            case TouchButtonType.Left:
                _horizontal = -1;
                break;
            case TouchButtonType.Right:
                _horizontal = 1;
                break;
            case TouchButtonType.Forward:
                _vertical = 1;
                break;
            case TouchButtonType.Back:
                _vertical = -1;
                break;
            case TouchButtonType.Drift:
                _isDrifting= true;
                break;
        }

        OnRides(_vertical, _horizontal);
    }

    private void OnButtonReleased(TouchButtonType buttonType)
    {
        switch (buttonType)
        {
            case TouchButtonType.Left:
                if (_horizontal == -1) _horizontal = 0;
                break;

            case TouchButtonType.Right:
                if (_horizontal == 1) _horizontal = 0;
                break;

            case TouchButtonType.Forward:
                if (_vertical == 1) _vertical = 0;
                break;

            case TouchButtonType.Back:
                if (_vertical == -1) _vertical = 0;
                break;

            case TouchButtonType.Drift:
                _isDrifting= false;
                break;
        }

        OnRides(_vertical, _horizontal);
    }
}
