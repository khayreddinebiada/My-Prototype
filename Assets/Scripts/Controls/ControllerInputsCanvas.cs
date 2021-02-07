using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace lib
{
    public class ControllerInputsCanvas : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private bool _isClicked = false;
        public bool isClicked
        {
            get
            {
                if (_isClicked)
                {
                    _isClicked = false;
                    return true;
                }
                else
                    return false;
            }
        }

        private bool _isDraging = false;
        public bool isDraging
        {
            get { return _isDraging; }
        }

        public bool allowInputs = false;

        private Vector2 _deltaDragging;
        public Vector2 deltaDragging
        {
            get { return _deltaDragging; }
        }

        private Vector2 _lastClickPosition;
        public Vector2 lastClickPosition
        {
            get { return _lastClickPosition; }
        }

        #region events
        private UnityEvent _onBeginDrag;
        public UnityEvent onBeginDrag
        {
            get { return _onBeginDrag; }
        }

        private UnityEvent _onEndDrag;
        public UnityEvent onEndDrag
        {
            get { return _onEndDrag; }
        }

        private UnityEvent _onClick;
        public UnityEvent onClick
        {
            get { return _onClick; }
        }
        #endregion

        private GameManager _gameManager;

        private void Awake()
        {
            _onEndDrag = new UnityEvent();
            _onBeginDrag = new UnityEvent();
            _onClick = new UnityEvent();
        }

        private void Start()
        {
            _gameManager = GameManager.instance;

            _gameManager.onStart.AddListener(() => { allowInputs = true; });
            _gameManager.onWin.AddListener(() => { allowInputs = false; });
            _gameManager.onLost.AddListener(() => { allowInputs = false; });
            _gameManager.onGoHome.AddListener(() => { allowInputs = false; });
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!allowInputs || IgnoreDrag())
                return;

            MakeBeginDrag();
            _isDraging = true;
            _deltaDragging = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!allowInputs)
            {
                _deltaDragging = Vector2.zero;
                _isDraging = false;
                return;
            }

            _deltaDragging = eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            MakeEndDrag();
            _isDraging = false;
            _deltaDragging = Vector2.zero;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!allowInputs || IgnoreClick())
                return;

            MakeClick();
            _isClicked = true;
            _lastClickPosition = eventData.position;
        }

        private bool IgnoreClick()
        {
            return false;
        }

        private bool IgnoreDrag()
        {
            return false;
        }

        private void MakeEndDrag()
        {
            _onEndDrag.Invoke();
            _isDraging = true;
        }

        private void MakeBeginDrag()
        {
            _onBeginDrag.Invoke();
            _isDraging = false;
        }

        private void MakeClick()
        {
            _onClick.Invoke();
        }

    }
}