using UnityEngine;

public class CameraFollow : MonoBehaviour 
{

	[SerializeField]private CarSpawner _carSpawner;
	[Range(1, 10)]
	[SerializeField] private float _followSpeed = 2;
	[Range(1, 10)]
	[SerializeField] private float lookSpeed = 5;

	private Vector3 _initialCameraPosition;
    private Vector3 _initialCarPosition;
    private Vector3 _absoluteInitCameraPosition;
	private Transform _carTransform;

    private void OnEnable()
    {
        _carSpawner.CarSpawned+=SetTrackingPoint;
    }

    private void OnDisable()
    {
        _carSpawner.CarSpawned-=SetTrackingPoint;
    }

	void FixedUpdate()
	{
        if (_carTransform == null)
            return;

        Vector3 _lookDirection = (new Vector3(_carTransform.position.x, _carTransform.position.y, _carTransform.position.z)) - transform.position;
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

		Vector3 _targetPos = _absoluteInitCameraPosition + _carTransform.transform.position;
		transform.position = Vector3.Lerp(transform.position, _targetPos, _followSpeed * Time.deltaTime);
	}

	private void SetTrackingPoint(Mover car)
	{
        _carTransform =car.transform;
        _initialCameraPosition = gameObject.transform.position;
        _initialCarPosition = _carTransform.position;
        _absoluteInitCameraPosition = _initialCameraPosition - _initialCarPosition;
    }
}
