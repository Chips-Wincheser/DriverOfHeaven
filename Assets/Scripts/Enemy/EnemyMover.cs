using SplineMesh;
using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Spline _spline;
    [SerializeField] private float _speed;
    [SerializeField] private int _countCycles;

    private int _currentCycle = 0;
    private float _splineRate = 0f;
    private Transform _transform;

    public event Action Finished;

    private void Awake()
    {
        _transform=transform;
    }

    private void Update()
    {
        if (_currentCycle >= _countCycles)
            Finished.Invoke();

        _splineRate += _speed * Time.deltaTime;

        if (_splineRate >= _spline.nodes.Count - 1)
        {
            _splineRate -= (_spline.nodes.Count - 1);
            _currentCycle++;
        }

        Place();
    }

    private void Place()
    {
        CurveSample sample = _spline.GetSample(_splineRate);

        _transform.localPosition = sample.location;
        _transform.localRotation = sample.Rotation;
    }
}
