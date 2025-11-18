using SplineMesh;
using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _countCycles;

    private int _currentCycle = 0;
    private float _splineRate = 0f;
    private Transform _transform;

    public Spline Spline;
    public event Action Finished;

    private void Awake()
    {
        _transform=transform;
    }

    private void Update()
    {
        if (_currentCycle >= _countCycles)
            return;

        _splineRate += _speed * Time.deltaTime;

        if (_splineRate >= Spline.nodes.Count - 1)
        {
            _splineRate -= (Spline.nodes.Count - 1);
            _currentCycle++;
        }

        Place();
    }

    private void Place()
    {
        CurveSample sample = Spline.GetSample(_splineRate);

        _transform.localPosition = sample.location;
        _transform.localRotation = sample.Rotation;
    }
}
