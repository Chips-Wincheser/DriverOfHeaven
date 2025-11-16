using System.Collections;
using UnityEngine;

public class RaceFlowController : MonoBehaviour
{
    private WaitForSecondsRealtime _WaitForSeconds;
    private int _delay=2;

    private void Awake()
    {
        _WaitForSeconds= new WaitForSecondsRealtime(_delay);
    }

    private void Start()
    {
        //StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        GameStoper.StopTime();

        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i);
            yield return _WaitForSeconds;
        }
        
        Debug.Log("Done even with timeScale = 0");
        Time.timeScale = 1f;
    }
}
