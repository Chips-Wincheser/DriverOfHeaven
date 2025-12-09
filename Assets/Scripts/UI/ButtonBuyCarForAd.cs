using UnityEngine;
using YG;

public class ButtonBuyCarForAd : ButtonBase
{
    [SerializeField] private SaleCarsSpawner _saleCarsSpawner;
    [SerializeField] private GameLoader _loader;
    [SerializeField] private GameObject _windowBuy;

    protected override void HandleButtonClick()
    {
        YG2.RewardedAdvShow("2", Reward);
    }

    private void Reward()
    {
        if (_windowBuy!=null && _loader!=null && _saleCarsSpawner!=null)
        {
            _windowBuy.gameObject.SetActive(true);
            _loader.Purchase(_loader.Money);
            _saleCarsSpawner.SelectCar.CanAds = false;
            SaveSystem.SaveGame(_loader.Level, _loader.Money, _saleCarsSpawner.IndexCar);
        }

        if(_windowBuy==null)
        {
            SaveSystem.SaveGame(_loader.Level, (_loader.Money+501), _loader.CarId);
            _loader.Purchase(1);
        }

    }
}
