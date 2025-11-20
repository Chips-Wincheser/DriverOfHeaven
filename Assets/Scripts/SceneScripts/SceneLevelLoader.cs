using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevelLoader : MonoBehaviour
{
    [SerializeField] private GameLoader _gameLoader;
    [SerializeField] private int _indexLevl;
    
    private int _countlevelToNextLocation=4;

    public void LoaderScene()
    {
        if (_gameLoader.Level<_countlevelToNextLocation)
        {
            int totalScenes = SceneManager.sceneCountInBuildSettings;

            if (_indexLevl < totalScenes)
            {
                SceneManager.LoadScene(_indexLevl);
            }
        }
        else
        {
            _indexLevl++;
            _countlevelToNextLocation+=4;
        }
    }

    public void LoaderMainMenu()
    {
        Debug.Log("SSS");
        int nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
