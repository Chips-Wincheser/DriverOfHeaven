using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(int level, int money, int carID)
    {
        PlayerPrefs.SetInt("Levle",level);
        PlayerPrefs.SetInt("Money",money);
        PlayerPrefs.SetInt("CarId",carID);
    }

    public static void SaveGame()
    {
        PlayerPrefs.SetInt("Levle", 1);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("CarId", 0);
        PlayerPrefs.SetInt("PlatformId", 0);
    }

    public static void SaveCarCharacteristics(int engien,int drag,int wheels)
    {
        PlayerPrefs.SetInt("Engine", engien);
        PlayerPrefs.SetInt("Drag", drag);
        PlayerPrefs.SetInt("Wheels", wheels);
    }

    public static void SwitchPlatform(int platform)
    {
        //0-PC 1-Phone
        PlayerPrefs.SetInt("PlatformId", platform);
    } 
}
