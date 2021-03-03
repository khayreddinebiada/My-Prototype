using System;
using UnityEngine;
using UnityEngine.Events;

namespace control
{
    public class ControllerInputs3D : MonoBehaviour
    {
        [HideInInspector]
        public bool allowInputs { set; get; }

        private bool _isDraging = false;
        public bool isDraging
        {
            get { return _isDraging; }
        }

        public delegate void Action();

        private event Action _onTake;
        public event Action onTake
        {
            add
            {
                _onTake += value;
            }
            remove
            {
                _onTake -= value;
            }
        }

        private event Action _onLeave;
        public event Action onLeave
        {
            add
            {
                _onTake += value;
            }
            remove
            {
                _onTake -= value;
            }
        }

        private event Action _onCollect;
        public event Action onCollect
        {
            add
            {
                _onTake += value;
            }
            remove
            {
                _onTake -= value;
            }
        }


        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager.onStart += () => { allowInputs = true; };
            _gameManager.onWin += () => { allowInputs = false; };
            _gameManager.onLose += () => { allowInputs = false; };
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

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_gameManager == null)
                _gameManager = FindObjectOfType<GameManager>();
        }
#endif
    }
}