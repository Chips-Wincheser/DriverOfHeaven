using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMeshUpdater : MonoBehaviour
{
    [SerializeField] private Transform[] _frontWheelsModels;
    [SerializeField] private Transform[] _rearWheelsModels;
    [SerializeField] private Mover _mover;

    private void OnEnable()
    {
        _mover.WheelUpdated += UpdateVisual;
    }

    private void OnDisable()
    {
        _mover.WheelUpdated -= UpdateVisual;
    }

    private void UpdateVisual(WheelCollider[] wheelColliders)
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].GetWorldPose(out Vector3 pos, out Quaternion quat);
            _frontWheelsModels[i].position = pos;
            _frontWheelsModels[i].rotation = quat;
        }
    }
}
