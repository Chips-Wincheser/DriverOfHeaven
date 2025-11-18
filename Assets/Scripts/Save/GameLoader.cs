using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public int Level {  get; private set; }
    public int Money { get; private set; }
    public int CarId { get; private set; }
    public int SystemMove { get; private set; }

    private void Awake()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("Levle"))
        {
            Level = PlayerPrefs.GetInt("Levle");
            Money = PlayerPrefs.GetInt("Money");
            CarId = PlayerPrefs.GetInt("CarId");
            CarId = PlayerPrefs.GetInt("SystemMove");
        }
        else
        {
            SaveSystem.SaveGame();
        }
    }
}
