using SplineMesh;
using System;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Mover[] _carsPlayer;
    [SerializeField] private GameLoader _gameLoader;
    [SerializeField] private Spline _splineEnemy;
    [SerializeField] private EnemyMover[] _carsEnemy;

    public event Action<Mover> CarSpawned;

    private void Awake()
    {
        Mover car = Instantiate(_carsPlayer[_gameLoader.CarId],transform.position,Quaternion.identity);

        EnemyMover carEnemy = Instantiate(_carsEnemy[_gameLoader.Level-1], _splineEnemy.transform.position, Quaternion.identity);
        carEnemy.Spline = _splineEnemy;
        carEnemy.transform.SetParent(_splineEnemy.transform);
        CarSpawned.Invoke(car);
    }
}
