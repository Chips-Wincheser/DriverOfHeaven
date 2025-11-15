using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private float _offsetX=-18f;
    private float _offsetZ=-13f;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;  
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(_player.transform.position.x+_offsetX, _transform.position.y, _player.transform.position.z+_offsetZ);
        transform.position=Vector3.Lerp(transform.position, targetPosition, _speed*Time.deltaTime);
    }
}
