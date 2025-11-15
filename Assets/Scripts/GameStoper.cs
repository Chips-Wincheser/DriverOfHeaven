using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStoper : MonoBehaviour
{
    public static void StopTime()
    {
        Time.timeScale=0;
    }

    public static void Respown()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale=1;
    }
}
