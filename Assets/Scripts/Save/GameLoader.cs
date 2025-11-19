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
        SaveSystem.SaveGame(Level, Money, 0, SystemMove);
        PlayerPrefs.SetInt("Levle", 1);
        Debug.Log(PlayerPrefs.GetInt("Levle"));
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("Levle"))
        {
            Level = PlayerPrefs.GetInt("Levle");
            Money = PlayerPrefs.GetInt("Money");
            CarId = PlayerPrefs.GetInt("CarId");
            SystemMove = PlayerPrefs.GetInt("SystemMove");
        }
        else
        {
            SaveSystem.SaveGame();
        }
    }
}
