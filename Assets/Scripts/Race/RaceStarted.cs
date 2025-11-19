using System;
using UnityEngine;

public class RaceStarted : MonoBehaviour
{
    [SerializeField] private CarDetector _carDetected;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private int _countCircle;

    private int _circlePlayer;
    private int _circleEnemy;

    public event Action<bool> LevleEnded;

    private void OnEnable()
    {
        _circlePlayer = -1;
        _circleEnemy = -1;
        _carDetected.PlayerCircleCompleted += ChangeCountCircle;
    }

    private void OnDisable()
    {
        _carDetected.PlayerCircleCompleted -= ChangeCountCircle;
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

    private void Update()
    {
        if(_circlePlayer ==_countCircle)
        {
            LevleEnded.Invoke(true);
        }
        else if (_circleEnemy==_countCircle)
        {
            LevleEnded.Invoke(false);
        }
    }
}
