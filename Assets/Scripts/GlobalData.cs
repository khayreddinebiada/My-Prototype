using UnityEngine;

public class GlobalData : MonoBehaviour
{
    #region instance
    private static GlobalData _instance;
    public static GlobalData instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Levels
    public static void SetRandomChoiceLevels()
    {
        PlayerPrefs.SetInt("Random Levels", 1);
    }

    public static bool IsRandomChoiceLevels()
    {
        return PlayerPrefs.HasKey("Random Levels");
    }

    public static int indexCurrentLevel
    {
        get { return PlayerPrefs.GetInt("Index Current Level"); }
        set { PlayerPrefs.SetInt("Index Current Level", value); }
    }

    public static int playerCurrentLevel
    {
        get { return PlayerPrefs.GetInt("Player Current Level"); }
        set { PlayerPrefs.SetInt("Player Current Level", value); }
    }
    #endregion

    #region Others
    public static bool ShowToturials()
    {
        if (!PlayerPrefs.HasKey("Show Toturials"))
        {
            PlayerPrefs.SetInt("Show Toturials", 1);
            return true;
        }
        return false;
    }
    #endregion
}
