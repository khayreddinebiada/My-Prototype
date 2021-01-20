using UnityEngine;
using UnityEngine.Events;

namespace lib
{
    public class MoveToInit : MonoBehaviour
    {
        private enum MovingType
        {
            ByTransform, ByPosition
        }

        [SerializeField]
        private bool _allowMove = true;
        [SerializeField]
        private MovingType _movingType = MovingType.ByPosition;
        [SerializeField]
        private float movingSpeed;

        [SerializeField]
        private Vector3 _fromPosition;
        [SerializeField]
        private Transform _fromTransform;

        [SerializeField]
        private UnityEvent _onCame;

        private Vector3 _initPosition;

        // Start is called before the first frame update
        private void Start()
        {
            _initPosition = transform.position;

            if (_movingType == MovingType.ByTransform)
            {
                transform.position = _fromTransform.position;
            }
            else
            {
                transform.position = transform.position + _fromPosition;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_allowMove)
                return;

            transform.position = Vector3.MoveTowards(transform.position, _initPosition, movingSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _initPosition) == 0)
            {
                _allowMove = false;
                _onCame.Invoke();
            }
        }
    }
}