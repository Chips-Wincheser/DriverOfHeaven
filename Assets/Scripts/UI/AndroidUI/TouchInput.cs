using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class TouchInput : MonoBehaviour
{
    [SerializeField] private TouchButtonType _buttonType;

    private RectTransform rectTransform;
    private Vector3 initialScale;
    private float scaleDownMultiplier = 0.85f;

    public event Action<TouchButtonType> ButtonReleased;
    public event Action<TouchButtonType> ButtonPressed;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialScale = rectTransform.localScale;
    }

    public void ButtonDown()
    {
        rectTransform.localScale = initialScale * scaleDownMultiplier;
        ButtonPressed?.Invoke(_buttonType);
    }

    public void ButtonUp()
    {
        rectTransform.localScale = initialScale;
        ButtonReleased?.Invoke(_buttonType);
    }
}
