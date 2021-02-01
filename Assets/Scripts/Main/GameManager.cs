using UnityEngine;
using UnityEngine.Events;

namespace main.management
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager instance
        {
            get { return _instance; }
        }

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onStart;
        public UnityEvent onStart
        {
            get { return _onStart; }
        }

        [SerializeField]
        private UnityEvent _onWin;
        public UnityEvent onWin
        {
            get { return _onWin; }
        }

        [SerializeField]
        private UnityEvent _onLost;
        public UnityEvent onLost
        {
            get { return _onLost; }
        }

        private bool _isStarted = false;
        public bool isStarted
        {
            get { return _isStarted; }
        }

        private bool _isWin = false;
        public bool isWin
        {
            get { return _isWin; }
        }

        private bool _isLost = false;
        public bool isLost
        {
            get { return _isLost; }
        }

        // Start is called before the first frame update
        private void Awake()
        {
            _instance = this;
        }

        public void MakeStart()
        {
            _isStarted = true;
            _onStart.Invoke();
        }

        public void MakeWin()
        {
            if (_isWin || _isLost)
                return;

            _isWin = true;
            _onWin.Invoke();
        }

        public void MakeLost()
        {
            if (_isWin || _isLost)
                return;

            _isLost = true;
            _onLost.Invoke();
        }

        public bool IsGameFinished()
        {
            return !(_isWin && _isLost);
        }
    }
}
