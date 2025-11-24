using System.Collections;
using TMPro;
using UnityEngine;

public class RaceFlowController : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private WaitForSecondsRealtime _WaitForSeconds;
    private int _delay=1;

    private void Awake()
    {
        _WaitForSeconds= new WaitForSecondsRealtime(_delay);
    }

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        GameStoper.StopTime();

        for (int i = 0; i < 3; i++)
        {
            _text.text =(i+1).ToString();
            yield return _WaitForSeconds;
        }
        
        Time.timeScale = 1f;
        _text.gameObject.SetActive(false);
    }
}
