using System;
using UnityEngine;
using YG;

public class RaceStarted : MonoBehaviour
{
    [SerializeField] private CarDetector _carDetected;
    [SerializeField] private int _countCircle;

    private int _circleEnemy;
    private int _circlePlayer;

    public event Action<bool> LevleEnded;
    public event Action<int> CircleComplited;

    private void OnEnable()
    {
        _circlePlayer = 0;
        _circleEnemy = 0;
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
            CircleComplited?.Invoke(_circlePlayer);
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
