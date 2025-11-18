using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode CodeKeySpace = KeyCode.Space;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public event Action Brakeing;
    public event Action UnBrakeing;
    public event Action<float,float> Ridesing;

    private void Update()
    {
        HandleBreak();
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertical = Input.GetAxisRaw(Vertical);
        Ridesing?.Invoke(vertical, horizontal);
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
