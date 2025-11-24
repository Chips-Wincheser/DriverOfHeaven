using UnityEngine;

public class CarSelectionData : MonoBehaviour
{
    public static CarSelectionData Instance;

    public int CarPlayer1 = -1;
    public int CarPlayer2 = -1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
