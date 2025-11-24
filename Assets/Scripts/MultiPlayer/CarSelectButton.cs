using UnityEngine;

public class CarSelectButton : ButtonBase
{
    [SerializeField] private int _carIndex;
    [SerializeField] private bool _isPlayer1;

    protected override void HandleButtonClick()
    {
        if (_isPlayer1)
            CarSelectionData.Instance.CarPlayer1 = _carIndex;
        else
            CarSelectionData.Instance.CarPlayer2 = _carIndex;
    }
}
