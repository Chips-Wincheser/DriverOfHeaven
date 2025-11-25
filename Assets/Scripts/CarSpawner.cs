using SplineMesh;
using System;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Mover[] _carsPlayer;
    [SerializeField] private GameLoader _gameLoader;
    [SerializeField] private Spline _splineEnemy;
    [SerializeField] private EnemyMover[] _carsEnemy;

    private Mover _car;

    public event Action<Mover> CarSpawned;
    public event Action<Transform, Transform> OnTwoPlayersSpawned;

    private void Start()
    {
        
        if (CarSelectionData.Instance.CarPlayer1==-1 && CarSelectionData.Instance.CarPlayer2==-1)
        {
            _car = Instantiate(_carsPlayer[_gameLoader.CarId],transform.position,Quaternion.identity);
            EnemyMover carEnemy = Instantiate(_carsEnemy[_gameLoader.Level], _splineEnemy.transform.position, Quaternion.identity);
            carEnemy.Spline = _splineEnemy;
            carEnemy.transform.SetParent(_splineEnemy.transform);

            CarSpawned?.Invoke(_car);
        }
        else
        {
            int id1 = CarSelectionData.Instance.CarPlayer1;
            int id2 = CarSelectionData.Instance.CarPlayer2;
            Vector3 spawnOffset = new Vector3(3f, 0f, 0f);

            Mover p1 = Instantiate(_carsPlayer[id1], transform.position, Quaternion.identity);
            
            Mover p2 = Instantiate(_carsPlayer[id2], transform.position+spawnOffset, Quaternion.identity);
            p2.transform.SetParent(_splineEnemy.transform);
            
            if (p2.TryGetComponent<PlayerInput>(out PlayerInput playerInput))
            {
                playerInput.IsMultiplayerCar=true;
            }

            OnTwoPlayersSpawned?.Invoke(p1.transform, p2.transform);
        }

    }
}
