using UnityEngine;

namespace app
{
    public class EventsManager : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        private void Awake()
        {
            //if (InitAppsManager.agent == null)
            //    return;

            _gameManager.onStart += OnStart;
            _gameManager.onLose += OnLose;
            _gameManager.onWin += OnWin;
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

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_gameManager == null)
                _gameManager = FindObjectOfType<GameManager>();
        }
#endif
    }
}