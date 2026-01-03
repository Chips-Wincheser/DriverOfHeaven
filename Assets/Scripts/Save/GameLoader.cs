using System;
using UnityEngine;
using YG;

public class GameLoader : MonoBehaviour
{
    private const string DeviceNamePhone = "mobile";

    public int Level {  get; private set; }
    public int Money { get; private set; }
    public int CarId { get; private set; }
    public int PlatformId { get; private set; }
    public int Engine { get; private set; }
    public int Drag { get; private set; }
    public int Wheels { get; private set; }

    public event Action MoneyChenged;

    private void Awake()
    {
        Time.timeScale = 1f;
        LoadGame();
        LoadCarSystem();
        LoadPlatform();
        SaveSystem.SaveGame(Level, Money, CarId);
        LoadGame();
        YG2.SetLeaderboard("TOP", Level);
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("Levle"))
        {
            Level = PlayerPrefs.GetInt("Levle");
            Money = PlayerPrefs.GetInt("Money");
            CarId = PlayerPrefs.GetInt("CarId");
            PlatformId = PlayerPrefs.GetInt("PlatformId");
        }
        else
        {
            SaveSystem.SaveGame();
        }
    }

    private void LoadPlatform()
    {
        if (YG2.envir.deviceType == DeviceNamePhone)
        {
            SaveSystem.SwitchPlatform(1);
        }
        else 
        { 
            SaveSystem.SwitchPlatform(0);
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
        LoadGame();
        Money-=price;
        SaveSystem.SaveGame(Level,Money,CarId);
        MoneyChenged?.Invoke();
    }
}
