using UnityEngine;

[CreateAssetMenu(fileName = "AdsSettings", menuName = "Data/AdsSettings", order = 1)]
public class AdsSettings : ScriptableObject
{
    [SerializeField]
    private string _androidKey;
    public string androidKey
    {
        get { return _androidKey; }
    }

    [SerializeField]
    private string _iosKey;
    public string iosKey
    {
        get { return _iosKey; }
    }
/*
    [SerializeField]
    private IronSourceBannerPosition _ironSourceBannerPosition;
    public IronSourceBannerPosition ironSourceBannerPosition
    {
        get { return _ironSourceBannerPosition; }
    }*/
}
