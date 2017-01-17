using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.GentleUI;

namespace GameDrinker.Managers
{
    public class GUIManager : MonoBehaviour
    {
        static private GUIManager instance;
        static public GUIManager Instance
        { get { return instance; } }

        public GenericWindow[] windows;
        public int currentWindowID;
        public int defaultWindowID;

        public GenericWindow GetWindow(int value)
        {
            return windows[value];
        }

        private void ToggleVisability(int value)
        {
            var total = windows.Length;
            for(int i = 0; i < total; i++)
            {
                var window = windows[i];
                if (i == value)
                { window.Open(); }
                else if(window.gameObject.activeSelf)
                { window.Close(); }
            }
        }
        public GenericWindow Open(int value)
        {
            if (value < 0 || value >= windows.Length)
                return null;
            currentWindowID = value;

            ToggleVisability(currentWindowID);
            return GetWindow(currentWindowID);
        }
        
        public void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("GUI Manager is already in play. Deleting old, instantiating new!", this.gameObject);
                Destroy(GUIManager.Instance.gameObject);
                instance = null;
            }
            else
            { instance = this; }
        }
    }
}