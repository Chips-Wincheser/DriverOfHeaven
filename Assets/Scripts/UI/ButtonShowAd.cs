using YG;

public class ButtonShowAd : ButtonBase
{
    protected override void HandleButtonClick()
    {
        YG2.InterstitialAdvShow();
    }
}
