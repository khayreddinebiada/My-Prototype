﻿using UnityEngine;
using UnityEngine.Events;

namespace lib
{
    public class ExecuteEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _event;

        public void OnExecutingEvent()
        {
            _event.Invoke();
        }
    }
}