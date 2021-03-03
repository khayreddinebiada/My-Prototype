using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace lib
{
    [RequireComponent(typeof(Rigidbody))]
    public class DetectCollider : MonoBehaviour
    {
        public enum DetectType 
        {
            Collision, Trigger
        }

        [SerializeField]
        private DetectType _detectType;
        [SerializeField]
        private string _tag;

        [SerializeField]
        private UnityEvent _onDetect;

        private void OnCollisionEnter(Collision collision)
        {
            if (_detectType == DetectType.Collision)
            {
                if (collision.gameObject.tag == _tag)
                {
                    _onDetect.Invoke();
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (_detectType == DetectType.Trigger)
            {
                if (collider.gameObject.tag == _tag)
                {
                    _onDetect.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }

}