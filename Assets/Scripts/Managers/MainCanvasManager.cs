using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace management
{
    public class MainCanvasManager : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onWin;
        [SerializeField]
        private UnityEvent _onLost;

        [SerializeField]
        private Text _textLevel;

        // Start is called before the first frame update
        private void Awake()
        {
            _gameManager.onWin += OnWin;
            _gameManager.onLose += OnLose;
        }

        private void Start()
        {
            InitializedTextLevel();
        }

        private void InitializedTextLevel()
        {
            int clevel = _gameManager.gameData.data.playerCurrentLevel + 1;
            if (clevel < 10)
            {
                _textLevel.text = "LEVEL 0" + clevel;
            }
            else
            {
                _textLevel.text = "LEVEL " + clevel;
            }
        }

        private void OnWin()
        {
            _onWin.Invoke();
        }

        private void OnLose()
        {
            _onLost.Invoke();
        }

        public void Play()
        {
            _gameManager.MakeStart();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_gameManager == null)
                _gameManager = GetComponent<GameManager>();
        }
#endif
    }
}
