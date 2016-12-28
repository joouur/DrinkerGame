using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace GameDrinker
{
    public class EventSystemManager
    {
        private static Dictionary<string, UnityEvent> eventDictionary;

        private static void Init()
        {
            if (eventDictionary == null)
            { eventDictionary = new Dictionary<string, UnityEvent>(); }
        }

        public static void StartListening(string eventName, UnityAction listener)
        {
            Init();
            UnityEvent eventListener = null;
            if (eventDictionary.TryGetValue(eventName, out eventListener))
            { eventListener.AddListener(listener); }
            else
            {
                eventListener = new UnityEvent();
                eventListener.AddListener(listener);
                eventDictionary.Add(eventName, eventListener);
            }
        }

        public static void StopListening(string eventName, UnityAction listener)
        {
            Init();

            UnityEvent eventListener = null;

            if (eventDictionary.TryGetValue(eventName, out eventListener))
            { eventListener.RemoveListener(listener); }
        }

        public static void TriggerEvent(string eventName)
        {
            Init();
            UnityEvent eventToTrigger = null;
            if (eventDictionary.TryGetValue(eventName, out eventToTrigger))
            { eventToTrigger.Invoke(); }
        }
    }
}