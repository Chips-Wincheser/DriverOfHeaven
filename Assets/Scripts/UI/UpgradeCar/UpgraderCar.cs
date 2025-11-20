using TMPro;
using UnityEngine;

public class UpgraderCar : MonoBehaviour
{
    [SerializeField] private ImprovementType _improvementType;
    [SerializeField] private GameLoader _gameLoader;
    [SerializeField] private TMP_Text _textPrice;

    private int _maximumNumberImprovements = 3;
    private int _price=1000;
    private int _typeImprovement;

    private void OnEnable()
    {
        UpdatePrice();
    }

    public void Improvements()
    {
        _typeImprovement = GetImprovementValue();

        if (_maximumNumberImprovements>_typeImprovement && _gameLoader.Money>=_price)
        {
            SaveImprovedStat();
            SaveSystem.SaveGame(_gameLoader.Level,_gameLoader.Money-_price,_gameLoader.CarId,_gameLoader.SystemMove);
            _gameLoader.Purchase(_price);
            _gameLoader.LoadCarSystem();
            UpdatePrice();
        }
        else if (_gameLoader.Money<_price)
        {
            _textPrice.text="No money";
        }
        else if (_maximumNumberImprovements==_typeImprovement)
        {
            _textPrice.text="Sold out";
        }
    }

    private int GetImprovementValue()
    {
        switch (_improvementType)
        {
            case ImprovementType.Engine:
                return _gameLoader.Engine;

            case ImprovementType.Drag:
                return _gameLoader.Drag;

            case ImprovementType.Wheels:
                return _gameLoader.Wheels;

            default:
                return 0;
        }
    }

    private void SaveImprovedStat()
    {
        switch (_improvementType)
        {
            case ImprovementType.Engine:
                SaveSystem.SaveCarCharacteristics(
                    _gameLoader.Engine + 1,
                    _gameLoader.Drag,
                    _gameLoader.Wheels);
                break;

            case ImprovementType.Drag:
                SaveSystem.SaveCarCharacteristics(
                    _gameLoader.Engine,
                    _gameLoader.Drag + 1,
                    _gameLoader.Wheels);
                break;

            case ImprovementType.Wheels:
                SaveSystem.SaveCarCharacteristics(
                    _gameLoader.Engine,
                    _gameLoader.Drag,
                    _gameLoader.Wheels + 1);
                break;
        }
    }

    private void UpdatePrice()
    {
        for (int i = 0; i < _typeImprovement; i++)
        {
            _price+=2000;
        }

        _textPrice.text=_price.ToString()+"$";
    }
}
