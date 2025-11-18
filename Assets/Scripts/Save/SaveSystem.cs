using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(int level, int money, int carID,int systemMove)
    {
        PlayerPrefs.SetInt("Levle",level);
        PlayerPrefs.SetInt("Money",money);
        PlayerPrefs.SetInt("CarId",carID);
        
        //0-PC     1-Phone
        PlayerPrefs.SetInt("SystemMove",systemMove);
    }

    public static void SaveGame()
    {
        PlayerPrefs.SetInt("Levle", 1);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("CarId", 0);
        PlayerPrefs.SetInt("SystemMove",0);
    }
}
