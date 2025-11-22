using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevelLoader : MonoBehaviour
{
    [SerializeField] private GameLoader _gameLoader;
    [SerializeField] private int _indexLevl;

    [SerializeField] private int firstSceneIndex = 1;
    [SerializeField] private int scenesCount = 4;

    public void LoaderScene()
    {
        int level = _gameLoader.Level;

        int locationIndex = (level - 1) / 4;

        int sceneToLoad = firstSceneIndex + (locationIndex % scenesCount);

        SceneManager.LoadScene(sceneToLoad);
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

    public void LoadSpecificScene()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (_indexLevl < totalScenes)
        {
            SceneManager.LoadScene(_indexLevl);
        }
    }
}
