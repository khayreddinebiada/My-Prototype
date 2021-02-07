using UnityEngine;
using UnityEngine.Events;

namespace control
{
    public class ControllerInputs3D : MonoBehaviour
    {
        private Vector3 _mouseFocusPosition;
        public Vector3 mouseFocusPosition
        {
            get { return _mouseFocusPosition; }
        }

        [HideInInspector]
        public bool allowInputs { set; get; }

        private bool _isDraging = false;
        public bool isDraging
        {
            get { return _isDraging; }
        }

        private UnityEvent _onTake;
        public UnityEvent onTake
        {
            get { return _onTake; }
        }

        private UnityEvent _onLeave;
        public UnityEvent onLeave
        {
            get { return _onLeave; }
        }

        private UnityEvent _onCollect;
        public UnityEvent onCollect
        {
            get { return _onCollect; }
        }

        private GameManager _gameManager;

        private void Awake()
        {
            _onTake = new UnityEvent();
            _onLeave = new UnityEvent();
            _onCollect = new UnityEvent();
        }

        private void Start()
        {
            _gameManager = GameManager.instance;

            _gameManager.onStart.AddListener(() => { allowInputs = true; });
            _gameManager.onWin.AddListener(() => { allowInputs = false; });
            _gameManager.onLost.AddListener(() => { allowInputs = false; });
            _gameManager.onGoHome.AddListener(() => { allowInputs = false; });
        }

        
        // Update is called once per frame
        private void Update()
        {
            if (allowInputs == false)
                return;

            if (Input.GetMouseButton(0))
            {
                OnTouchScreen();
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnTouchDown();
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnTouchScreenUp();
            }
        }

        #region TOUCHS
        private void OnTouchScreen()
        {
        }

        private void OnTouchScreenUp()
        {
        }

        private void OnTouchDown()
        {
        }
        #endregion

        private Collider OnRaycastHit(LayerMask layerMask)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider != null)
                {
                    return hit.collider;
                }
            }

            return null;
        }

        private void MakeTake()
        {
            _onTake.Invoke();
            _isDraging = true;
        }

        private void MakeLeave()
        {
            _onLeave.Invoke();
            _isDraging = false;
        }

        private void MakeCollect()
        {
            _onCollect.Invoke();
            _isDraging = false;
        }
    }
}