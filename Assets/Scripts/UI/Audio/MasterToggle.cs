using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterToggle : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private Button _button;

    private bool _isMuted = false;
    private float _volumeOn = 0f;
    private float _volumeOff = -80f;

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
        _isMuted = !_isMuted;

        if (_isMuted)
        {
            _masterMixer.SetFloat("Master", _volumeOff);
        }
        else
        {
            _masterMixer.SetFloat("Master", _volumeOn);
        }
    }
}
