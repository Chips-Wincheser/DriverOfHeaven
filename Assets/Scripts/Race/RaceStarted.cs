using System;
using UnityEngine;

public class RaceStarted : MonoBehaviour
{
    [SerializeField] private CarDetector _carDetected;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private int _countCircle;

    private bool _enemyIsFinished;
    private int _circlePlayer;
    private int _circleEnemy;

    public event Action LevleEnded;

    private void OnEnable()
    {
        _circlePlayer = -1;
        _circleEnemy = -1;
        _carDetected.PlayerCircleCompleted += ChangeCountCircle;
        _enemyMover.Finished+=EnemyFinish;
    }

    private void OnDisable()
    {
        _carDetected.PlayerCircleCompleted -= ChangeCountCircle;
        _enemyMover.Finished-=EnemyFinish;
    }

    private void ChangeCountCircle(int id)
    {
        if (id==1)
        {
            _circlePlayer++;
        }

        if (id == 0)
        {
            _circleEnemy++;
        }
    }

    private void EnemyFinish()
    {
        _enemyIsFinished=true;
    }

    private void Update()
    {
        if(_circleEnemy==_countCircle || _circlePlayer ==_countCircle)
        {
            LevleEnded.Invoke();
            GameStoper.StopTime();
        }
    }
}
