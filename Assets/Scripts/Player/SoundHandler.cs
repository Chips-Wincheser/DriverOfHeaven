using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _source;

    private bool _isPlaying = false;

    private void OnEnable()
    {
        _player.Rided+=SwitchSound;
    }

    private void OnDisable()
    {
        _player.Rided-=SwitchSound;
    }

    private void SwitchSound(float vertical)
    {
        if (vertical == 1)
        {
            if (!_isPlaying)
            {
                _source.Play();
                _isPlaying = true;
            }
        }
        else
        {
            if (_isPlaying)
            {
                _source.Stop();
                _isPlaying = false;
            }
        }
    }
}
