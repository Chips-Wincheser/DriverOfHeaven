using TMPro;
using UnityEngine;

public class GameStateInitializer : MonoBehaviour
{
    [SerializeField] private GameLoader _gameLoader;

    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private TMP_Text _textLevle;

    private void Start()
    {
        _textMoney.text=_gameLoader.Money.ToString();
        _textLevle.text=_gameLoader.Level.ToString();
    }
}
