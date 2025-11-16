using UnityEngine;
using UnityEngine.UI;

public class MenuButton : ButtonBase
{
    [SerializeField] private GameObject[] _offWindows;
    [SerializeField] private GameObject[] _onWindows;

    protected override void HandleButtonClick()
    {
        if(_offWindows.Length >= 0)
        {
            for (int i = 0; i < _offWindows.Length; i++)
            {
                _offWindows[i].SetActive(false);
            }
        }

        if( _onWindows.Length >= 0)
        {
            for (int i = 0; i < _onWindows.Length; i++)
            {
                _onWindows[i].SetActive(true);
            }
        }
    }
}
