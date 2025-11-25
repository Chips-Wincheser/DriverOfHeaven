using TMPro;
using UnityEngine;
using YG;

public class FinishDubleMoneyButton : ButtonBase
{
    [SerializeField] private GameLoader _gameLoader;
    [SerializeField] private TMP_Text _text;

    private int _rewardMoney = 2000;

    protected override void HandleButtonClick()
    {
        YG2.RewardedAdvShow("3", Reward);
    }

    private void Reward()
    {
        SaveSystem.SaveGame(_gameLoader.Level, (_gameLoader.Money+_rewardMoney), _gameLoader.CarId, _gameLoader.SystemMove);
        _text.text= (_gameLoader.Money+_rewardMoney).ToString();
    }
}
