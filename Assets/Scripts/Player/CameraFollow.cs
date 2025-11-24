using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	[SerializeField]private CarSpawner _carSpawner;
	[Range(1, 10)]
	[SerializeField] private float _followSpeed = 2;
	[Range(1, 10)]
	[SerializeField] private float lookSpeed = 5;
    [SerializeField] private float playersCenterDivider = 2f;

    private Transform _player1;
    private Transform _player2;

    private Vector3 _initialOffset;

    private void OnEnable()
    {
        _carSpawner.CarSpawned += SetOnePlayer;
        _carSpawner.OnTwoPlayersSpawned += SetTwoPlayers;
    }

    private void OnDisable()
    {
        _carSpawner.CarSpawned -= SetOnePlayer;
        _carSpawner.OnTwoPlayersSpawned -= SetTwoPlayers;
    }

    private void SetOnePlayer(Mover player)
    {
        _player1 = player.transform;
        _player2 = null;

        _initialOffset = transform.position - player.transform.position;
    }

    private void SetTwoPlayers(Transform player1, Transform player2)
    {
        _player1 = player1;
        _player2 = player2;

        Vector3 center = (_player1.position + _player2.position) /playersCenterDivider;
        _initialOffset = transform.position - center;
    }

    private void FixedUpdate()
    {
        if (_player1 == null)
            return;

        Vector3 target;

        if (_player2 == null)
            target = _player1.position;
        else
            target = (_player1.position + _player2.position) / playersCenterDivider;

        Vector3 desiredPos = target + _initialOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, _followSpeed * Time.deltaTime);

        Vector3 direction = target - transform.position;
        Quaternion look = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, lookSpeed * Time.deltaTime);
    }
}
