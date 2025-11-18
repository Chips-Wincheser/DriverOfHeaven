using UnityEngine;
using UnityEngine.UI;

public class ViewSpeed : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private CarSpawner _carSpawner;

    private Mover _mover;

    private void OnEnable()
    {
        _carSpawner.CarSpawned+=SetCarSpeed;
    }

    private void OnDisable()
    {
        _carSpawner.CarSpawned-=SetCarSpeed;
    }

    private void Update()
    {
        if (_mover == null)
            return;

        _text.text =_mover.Speed.ToString("F0");
    }

    private void SetCarSpeed(Mover car)
    {
        _mover=car;
    }
}
