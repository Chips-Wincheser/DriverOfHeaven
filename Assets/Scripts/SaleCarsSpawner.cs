using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaleCarsSpawner : MonoBehaviour
{
    [SerializeField] private SkinInfo[] _cars;
    [SerializeField] private Transform _spawnCarPoint;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private GameLoader _loader;

    public int IndexCar { get; private set; }
    public SkinInfo SelectCar { get; private set; }

    public event Action<bool> AdShowed;

    private void OnEnable()
    {
        SpawnCar();
    }

    private void OnDisable()
    {
        Destroy(SelectCar.gameObject);
    }

    private void Awake()
    {
        IndexCar=0;
    }

    private void ShowCar()
    {
        Destroy(SelectCar.gameObject);
        SpawnCar();    
    }

    private void SpawnCar()
    {
        SelectCar = Instantiate(_cars[IndexCar], _spawnCarPoint.position, Quaternion.Euler(0, -130f, 0));
        _infoText.text= _cars[IndexCar].Info.ToString();
        _price.text = _cars[IndexCar].Price.ToString();

        if (_cars[IndexCar].CanAds)
        {
            _buttonBuy.gameObject.SetActive(true);
        }
        else
        {
            _buttonBuy.gameObject.SetActive(false);
        }

        int price = SelectCar.Price;
        int money = _loader.Money;

        int missing = price - money;
        int threshold = (int)(price * 0.25f);

        if (missing <= threshold)
        {
            AdShowed?.Invoke(true);
        }
        else
        {
            AdShowed?.Invoke(false);
        }
    }

    public void SwitchCar(int SwitchCount)
    {
        if ((IndexCar+SwitchCount)<_cars.Length && (IndexCar+SwitchCount)>=0)
        {
            IndexCar+=SwitchCount;
            ShowCar();
        }
    }
}
