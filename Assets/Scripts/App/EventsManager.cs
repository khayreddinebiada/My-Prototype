using UnityEngine;

namespace app
{
    public class EventsManager : MonoBehaviour
    {

        private void OnEnable()
        {
            //if (InitAppsManager.agent == null)
            //    return;

            GameManager gameManager = GameManager.instance;

            gameManager.onStart.AddListener(() => OnStart());
            gameManager.onLost.AddListener(() => OnLose());
            gameManager.onWin.AddListener(() => OnWin());
        }

        private void OnStart()
        {
            Debug.Log("OnStart event");
            //InitAppsManager.agent.OnSendEvent(InitAppsManager.EventType.Start, false);
        }

        private void OnLose()
        {
            Debug.Log("OnLose event");
            //InitAppsManager.agent.OnSendEvent(InitAppsManager.EventType.Lose, ScoreManager.moneyCollected.ToString(), true);
        }

        private void OnWin()
        {
            Debug.Log("OnWin event");
            //InitAppsManager.agent.OnSendEvent(InitAppsManager.EventType.Win, ScoreManager.moneyCollected.ToString(), Random.Range(0, 4) == 0);
        }
    }
}