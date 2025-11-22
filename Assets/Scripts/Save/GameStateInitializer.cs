using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInitializer : MonoBehaviour
{
    [SerializeField] private GameLoader _gameLoader;

    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private TMP_Text _textLevle;

    [SerializeField] private Image[] _images;

    private void OnEnable()
    {
        _gameLoader.MoneyChenged+=ChangeMoneyCount;
    }

    private void OnDisable()
    {
        _gameLoader.MoneyChenged-=ChangeMoneyCount;
    }

    private void Start()
    {
        _textMoney.text = _gameLoader.Money.ToString();
        _textLevle.text = _gameLoader.Level.ToString();
        ColorUtility.TryParseHtmlString("#E5B90E", out Color baseColor);

        foreach (var img in _images)
            img.color = baseColor;

        int index = _gameLoader.Level % _images.Length;

        for (int i = 0; i < index; i++)
        {
            if (ColorUtility.TryParseHtmlString("#49E50E", out Color newColor))
            {
                _images[i].color = newColor;
            }
        }
    }

    private void ChangeMoneyCount()
    {
        _textMoney.text=_gameLoader.Money.ToString();
    }

}
