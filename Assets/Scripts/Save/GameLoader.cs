using System;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public int Level {  get; private set; }
    public int Money { get; private set; }
    public int CarId { get; private set; }
    public int SystemMove { get; private set; }
    public int Engine { get; private set; }
    public int Drag { get; private set; }
    public int Wheels { get; private set; }

    public event Action MoneyChenged;

    private void Awake()
    {
        Time.timeScale = 1f;
        LoadGame();
        LoadCarSystem();
        SaveSystem.SaveGame(10, 50000, 6, SystemMove);
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

    public void LoadCarSystem()
    {
        if (PlayerPrefs.HasKey("Engine"))
        {
            Engine= PlayerPrefs.GetInt("Engine");
            Drag= PlayerPrefs.GetInt("Drag");
            Wheels= PlayerPrefs.GetInt("Wheels");
        }
        else
        {
            SaveSystem.SaveCarCharacteristics(0,0,0);
        }
    }

    public void Purchase(int price)
    {
        Money-=price;
        SaveSystem.SaveGame(Level,Money,CarId, SystemMove);
        MoneyChenged?.Invoke();
    }
}
