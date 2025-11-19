using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class HiderUIAndroid : MonoBehaviour
{
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();

        if (PlayerPrefs.GetInt("SystemMove")==0)
        {
            _canvas.gameObject.SetActive(false);
        }
    }
}
