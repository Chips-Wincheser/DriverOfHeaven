using TMPro;
using UnityEngine;

public class SaleCarsSpawner : MonoBehaviour
{
    [SerializeField] private SkinInfo[] _cars;
    [SerializeField] private Transform _spawnCarPoint;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private TMP_Text _price;

    private int _indexCar=0;
    private SkinInfo _showCar;

    private void OnEnable()
    {
        SpawnCar();
    }

    private void OnDisable()
    {
        Destroy(_showCar.gameObject);
    }

    public void SwitchCar(int SwitchCount)
    {
        if ((_indexCar+SwitchCount)<_cars.Length && (_indexCar+SwitchCount)>=0)
        {
            _indexCar+=SwitchCount;
            ShowCar();
            
        }
    }

    private void ShowCar()
    {
        Destroy(_showCar.gameObject);
        SpawnCar();    
    }

    private void SpawnCar()
    {
        _showCar = Instantiate(_cars[_indexCar], _spawnCarPoint.position, Quaternion.Euler(0, -130f, 0));
        _infoText.text= _cars[_indexCar].Info.ToString();
        _price.text = _cars[_indexCar].Price.ToString();
    }
}
