using TMPro;
using UnityEngine;

public class LevelCompleteHandlers : MonoBehaviour
{
    [SerializeField] private RaceStarted _raceStarted;
    [SerializeField] private GameObject _WinMenu;
    [SerializeField] private GameObject _LoseMenu;
    [SerializeField] private GameLoader _gameLoader;

    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private TMP_Text _textLevle;

    private int _moneyFinish=2000;

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
        if(PlayerIsWin)
        {
            _WinMenu.gameObject.SetActive(true);
            EditVariables();
            GameStoper.StopTime();
        }
        else
        {
            _LoseMenu.gameObject.SetActive(true);
            GameStoper.StopTime();
        }
    }

    private void EditVariables()
    {
        SaveSystem.SaveGame(_gameLoader.Level+1,_gameLoader.Money+_moneyFinish, _gameLoader.CarId,_gameLoader.SystemMove);
        _textMoney.text=(_gameLoader.Money+_moneyFinish).ToString()+"$";
        _textLevle.text=(_gameLoader.Level+1).ToString();
    }
}
