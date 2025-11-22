using UnityEngine;

public class SkinInfo : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private string _info;
    
    public bool CanAds;

    public string Info => _info;
    public int Price => _price;
}
