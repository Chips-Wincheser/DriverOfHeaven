using UnityEngine;
using UnityEngine.UI;

public class MasterToggle : MonoBehaviour
{
    [SerializeField] private AudioListener _listener;
    [SerializeField] private Button _button;

    private bool _isEnable=false;

    protected void OnEnable()
    {
        Time.timeScale =0f;
        _button.onClick.AddListener(HandleButtonClick);
    }

    protected void OnDisable()
    {
        Time.timeScale =1f;
        _button.onClick.RemoveListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        _isEnable=!_isEnable;
        _listener.enabled = !_isEnable;
    }
}
