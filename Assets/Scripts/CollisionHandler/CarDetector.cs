using System;
using UnityEngine;

public class CarDetector : MonoBehaviour
{
    public event Action<int> PlayerCircleCompleted;
    public event Action PlayerLefted;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            PlayerCircleCompleted?.Invoke(1);
        }

        if(collision.gameObject.TryGetComponent<EnemyMover>(out EnemyMover enemy))
        {
            PlayerCircleCompleted?.Invoke(0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            PlayerLefted?.Invoke();
        }
    }
}
