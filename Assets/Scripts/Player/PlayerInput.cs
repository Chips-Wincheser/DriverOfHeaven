using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode CodeKeyRightAlt = KeyCode.RightAlt;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private bool _isMultiplayerCar=false;
    
    private KeyCode CodeKeySpace = KeyCode.Space;

    public event Action Brakeing;
    public event Action UnBrakeing;
    public event Action<float,float> Ridesing;

    private void Start()
    {
        if (_isMultiplayerCar)
        {
            CodeKeySpace=CodeKeyRightAlt;
        }
    }

    private void Update()
    {
        HandleBreak();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (_isMultiplayerCar)
        {
            float horizontal = 0;
            float vertical = 0;

            if (Input.GetKey(KeyCode.J)) horizontal = -1;
            if (Input.GetKey(KeyCode.L)) horizontal = 1;
            if (Input.GetKey(KeyCode.I)) vertical = 1;
            if (Input.GetKey(KeyCode.K)) vertical = -1;

            Ridesing?.Invoke(vertical, horizontal);
        }
        else
        {
            float horizontal = Input.GetAxisRaw(Horizontal);
            float vertical = Input.GetAxisRaw(Vertical);
            Ridesing?.Invoke(vertical, horizontal);
        }
    }

    private void HandleBreak()
    {
        if (Input.GetKey(CodeKeySpace))
        {
            Brakeing?.Invoke();
        }

        if (Input.GetKeyUp(CodeKeySpace))
        {
            UnBrakeing?.Invoke();
        }
    }
}
