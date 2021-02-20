using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;
using data;

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
        private void Start()
        {
            _gameManager.onWin.AddListener(() => StartCoroutine(WaitAndActiveCallWin()));
            _gameManager.onLost.AddListener(() => OnLost());

            InitializedTextLevel();
        }

        private void InitializedTextLevel()
        {
            int clevel = GlobalData.playerCurrentLevel + 1;
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

        private IEnumerator WaitAndActiveCallWin()
        {
            yield return new WaitForSeconds(1);
            OnWin();
        }

        private void OnLost()
        {
            _onLost.Invoke();
        }

        public void Play()
        {
            _gameManager.MakeStart();
        }
    }
}
