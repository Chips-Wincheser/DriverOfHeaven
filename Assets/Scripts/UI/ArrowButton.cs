using UnityEngine;

public class ArrowButton : ButtonBase
{
    [SerializeField] private SaleCarsSpawner _spawner;
    [SerializeField] private bool SwitchFowarded;

    protected override void HandleButtonClick()
    {
        if (SwitchFowarded)
        {
            _spawner.SwitchCar(1);
        }
        else if(SwitchFowarded==false)
        {
            _spawner.SwitchCar(-1);
        }
    }
}
