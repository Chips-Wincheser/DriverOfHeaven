using UnityEngine;

public class LapTracker : MonoBehaviour
{
    [SerializeField] private CarDetector _carDetectorFinish;
    [SerializeField] private CarDetector _carDetectorStart;

    private void OnEnable()
    {
        _carDetectorFinish.PlayerLefted += finishSwitch;
        _carDetectorStart.PlayerLefted += finishSwitch;
    }

    private void OnDisable()
    {
        _carDetectorFinish.PlayerLefted -= finishSwitch;
        _carDetectorStart.PlayerLefted -= finishSwitch;
    }

    private void finishSwitch()
    {
        if(_carDetectorStart.TryGetComponent<BoxCollider>(out BoxCollider boxCollider))
        {
            boxCollider.isTrigger=!boxCollider.isTrigger;
        }
    }
}
