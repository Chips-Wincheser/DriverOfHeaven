using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Mover _mover;

    private void OnEnable()
    {
        _input.Brakeing += OnBreak;
        _input.Ridesing += OnRides;
    }

    private void OnDisable()
    {
        _input.Brakeing -=OnBreak;
        _input.Ridesing -=OnRides;
    }

    private void OnBreak()
    {
        _mover.ProcessBreak();
    }

    private void OnRides(float vertical, float horizontal)
    {
        _mover.ProcessMovement(vertical,horizontal);
    }
}
