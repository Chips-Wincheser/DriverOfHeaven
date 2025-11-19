using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Dropdown))]
public class ChangerPlatform : MonoBehaviour
{
    [SerializeField] private GameLoader _gameLoader;

    private TMP_Dropdown _dropdown;

    private void OnEnable()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
        _dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    private void OnDisable()
    {
        _dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
    }

    private void Start()
    {
        //_dropdown.options[index].text=_dropdown.options[_gameLoader.SystemMove];
        _dropdown.value =_gameLoader.SystemMove;
        _dropdown.RefreshShownValue();
    }

    private void OnDropdownChanged(int index)
    {

        SaveSystem.SaveGame(_gameLoader.Level, _gameLoader.Money, _gameLoader.CarId, index);
    }
}
