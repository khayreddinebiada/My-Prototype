using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace lib
{
    public class ControllerInputsCanvas : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        [SerializeField]
        private GameManager _gameManager;

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
        public delegate void DragFuns();
        private event DragFuns _onBeginDrag;
        public event DragFuns onBeginDrag
        {
            add
            {
                _onBeginDrag += value;
            }
            remove
            {
                _onBeginDrag -= value;
            }
        }

        private event DragFuns _onEndDrag;
        public event DragFuns onEndDrag
        {
            add
            {
                _onEndDrag += value;
            }
            remove
            {
                _onEndDrag -= value;
            }
        }

        private event DragFuns _onClick;
        public event DragFuns onClick
        {
            add
            {
                _onClick += value;
            }
            remove
            {
                _onClick -= value;
            }
        }
        #endregion

        private void Awake()
        {
            _gameManager.onStart += () => { allowInputs = true; };
            _gameManager.onWin += () => { allowInputs = false; };
            _gameManager.onLose += () => { allowInputs = false; };
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