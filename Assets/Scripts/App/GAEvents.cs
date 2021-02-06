using UnityEngine;
//using GameAnalyticsSDK;
namespace app
{
    public class GAEvents : MonoBehaviour
    {
        /*
        private void Awake()
        {
            GameAnalytics.Initialize();
        }

        private void Start()
        {
            if (GameManager.instance == null)
                return;

            GameManager.instance.onStart.AddListener(() => StartLevel());
            GameManager.instance.onLost.AddListener(() => FailLevel());
            GameManager.instance.onWin.AddListener(() => EndLevel());
        }

        public static void StartLevel()
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Level_" + GlobalData.playerCurrentLevel);
        }

        public static void EndLevel()
        {
           GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level_" + GlobalData.playerCurrentLevel);
        }

        public static void FailLevel()
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Level_" + GlobalData.playerCurrentLevel);
        }
        */
    }
}