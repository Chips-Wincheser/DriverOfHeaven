using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ButtonChangeLanguage : ButtonBase
{
    [SerializeField] private string _language;

    protected override void HandleButtonClick()
    {
        YG2.SwitchLanguage(_language);
    }
}
