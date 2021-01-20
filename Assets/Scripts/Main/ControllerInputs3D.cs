using UnityEngine;
using main.management;

namespace main
{
    public class ControllerInputs3D : MonoBehaviour
    {
        private static ControllerInputs3D _instance;
        public static ControllerInputs3D instance
        {
            get { return _instance; }
        }

        private Vector3 _mouseFocusPosition;
        public Vector3 mouseFocusPosition
        {
            get { return _mouseFocusPosition; }
        }

        [HideInInspector]
        public bool allowInputs { set; get; }

        // Start is called before the first frame update
        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            GameManager.instance.onStart.AddListener(() => { allowInputs = true; });
            GameManager.instance.onWin.AddListener(() => { allowInputs = false; });
            GameManager.instance.onLost.AddListener(() => { allowInputs = false; });
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
    }
}