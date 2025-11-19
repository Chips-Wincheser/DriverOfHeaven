using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInitializer : MonoBehaviour
{
    [SerializeField] private GameLoader _gameLoader;

    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private TMP_Text _textLevle;

    [SerializeField] private Image[] _images;

    private void Start()
    {
        _textMoney.text=_gameLoader.Money.ToString();
        _textLevle.text=_gameLoader.Level.ToString();

        for (int i = 0; i < _gameLoader.Level; i++)
        {
            if (ColorUtility.TryParseHtmlString("#49E50E", out Color newColor))
            {
                _images[i].color = newColor;
            }
        }
    }

}
