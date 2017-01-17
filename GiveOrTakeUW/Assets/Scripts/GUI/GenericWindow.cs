using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameDrinker.Tools;
using GameDrinker.Managers;

namespace GameDrinker.GentleUI
{
    public class GenericWindow : MonoBehaviour
    {
        public GameObject firstSelect;

        public GDWindows nextWindow;
        public GDWindows previousWindow;

        protected EventSystem eventSystem
        { get { return GameObject.Find("EventSystem").GetComponent<EventSystem>(); } }

        public virtual void OnFocus()
        { eventSystem.SetSelectedGameObject(firstSelect); }

        protected virtual void Display(bool value)
        { gameObject.SetActive(value); }

        public virtual void Open()
        {
            Display(true);
            OnFocus();
        }

        public virtual void Close()
        { Display(false); }

        protected virtual void Awake()
        { Close(); }

        public void OnNextWindow()
        {
            GUIManager.Instance.Open((int)nextWindow - 1);
        }
        public void OnPreviousWindow()
        {
            GUIManager.Instance.Open((int)previousWindow - 1);
        }
    }
}