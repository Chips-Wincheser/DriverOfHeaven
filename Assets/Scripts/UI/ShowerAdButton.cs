using UnityEngine;
using UnityEngine.UI;

public class ShowerAdButton : MonoBehaviour
{
    [SerializeField] private Button _adButton;
    [SerializeField] private SaleCarsSpawner _saleCarsSpawner;

    private void OnEnable()
    {
        _saleCarsSpawner.AdShowed+=ShowButton;
    }
    
    private void OnDisable()
    {
        _saleCarsSpawner.AdShowed-=ShowButton;
    }

    private void ShowButton(bool isShowed)
    {
        _adButton.gameObject.SetActive(isShowed);
    }
}
