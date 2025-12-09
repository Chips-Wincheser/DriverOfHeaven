using TMPro;
using UnityEngine;

public class ButtonBuyCar : ButtonBase
{
    [SerializeField] private GameLoader _loader;
    [SerializeField] private SaleCarsSpawner _saleCarsSpawner;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private GameObject _windowBuy;
    protected override void HandleButtonClick()
    {

        if (_loader.Money<_saleCarsSpawner.SelectCar.Price)
        {
            _textPrice.text="No money".ToString();
        }
        else
        {
            _windowBuy.gameObject.SetActive(true);
            _loader.Purchase(_saleCarsSpawner.SelectCar.Price);
            SaveSystem.SaveGame(_loader.Level,_loader.Money,_saleCarsSpawner.IndexCar);
            _saleCarsSpawner.SelectCar.CanAds = false;
        }
    }
}
