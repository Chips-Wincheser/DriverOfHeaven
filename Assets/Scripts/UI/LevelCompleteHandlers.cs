using TMPro;
using UnityEngine;
using YG;

public class LevelCompleteHandlers : MonoBehaviour
{
    [SerializeField] private RaceStarted _raceStarted;
    [SerializeField] private GameObject _WinMenu;
    [SerializeField] private GameObject _LoseMenu;
    [SerializeField] private GameLoader _gameLoader;

    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private TMP_Text _textLevle;

    private int _moneyFinish=2000;
    private bool _isHandled = false;

    private void OnEnable()
    {
        _raceStarted.LevleEnded+=ShowFinishMenu;
    }

    private void OnDisable()
    {
        _raceStarted.LevleEnded-=ShowFinishMenu;
    }

    private void ShowFinishMenu(bool PlayerIsWin)
    {
        if (_isHandled==false)
        {
            if (PlayerIsWin)
            {
                _WinMenu.gameObject.SetActive(true);
                EditVariables();
                GameStoper.StopTime();
                _isHandled=true;
            }
            else
            {
                _LoseMenu.gameObject.SetActive(true);
                GameStoper.StopTime();
                _isHandled=true;
            }
        }
    }

    private void EditVariables()
    {
        SaveSystem.SaveGame(_gameLoader.Level+1,_gameLoader.Money+_moneyFinish, _gameLoader.CarId);
        _textMoney.text=(_gameLoader.Money+_moneyFinish).ToString()+"$";
        _textLevle.text=(_gameLoader.Level+1).ToString();
    }
}
