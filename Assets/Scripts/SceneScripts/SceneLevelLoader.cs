using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevelLoader : MonoBehaviour
{
    [SerializeField] private GameLoader _gameLoader;

    private int _indexLevl;

    private void Start()
    {
        _indexLevl=_gameLoader.Level;
    }

    public void LoaderScene()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (_indexLevl < totalScenes)
        {
            SceneManager.LoadScene(_indexLevl);
        }
    }

    public void LoaderMainMenu()
    {
        int nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
