using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

namespace main.management
{
    public class MainCanvasManager : MonoBehaviour
    {
        private static MainCanvasManager _instance;
        public static MainCanvasManager instance
        {
            get { return _instance; }
        }

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onWin;
        [SerializeField]
        private UnityEvent _onLost;

        [SerializeField]
        private GameObject _giftPanel;


        [SerializeField]
        private Text _textLevel;

        // Start is called before the first frame update
        private void Awake()
        {
            _instance = this;
        }

        // Start is called before the first frame update
        private void Start()
        {
            GameManager.instance.onWin.AddListener(() => StartCoroutine(WaitAndActiveCallWin()));
            GameManager.instance.onLost.AddListener(() => OnLost());

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
        public void OnClickMenu()
        {
            ControllerInputs3D.instance.allowInputs = false;
        }

        private void OnWin()
        {
            _onWin.Invoke();

            if (GlobalData.indexCurrentLevel == 4 || GlobalData.indexCurrentLevel == 2)
            {
                _giftPanel.SetActive(true);
            }
            else
            {
                _giftPanel.SetActive(false);
            }
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

    }
}
