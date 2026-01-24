using TMPro;
using UnityEngine;
using YG;

public class FinishDubleMoneyButton : ButtonBase
{
    [SerializeField] private GameLoader _gameLoader;
    [SerializeField] private TMP_Text _text;

    private int _rewardMoney = 4000;

    protected override void HandleButtonClick()
    {
        YG2.RewardedAdvShow("3", Reward);
    }

    private void Reward()
    {
        YG2.PauseGame(true);
        SaveSystem.SaveGame(_gameLoader.Level, (_gameLoader.Money+_rewardMoney), _gameLoader.CarId);
        _text.text= (_gameLoader.Money+_rewardMoney).ToString()+"$";
        _button.gameObject.SetActive(false);
        YG2.PauseGame(false);
    }
}
