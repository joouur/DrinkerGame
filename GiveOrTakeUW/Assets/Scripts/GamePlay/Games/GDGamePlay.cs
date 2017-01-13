using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameDrinker.Managers;

namespace GameDrinker.Gameplay
{
    public class GDGamePlay : MonoBehaviour
    {

        public GDGiveORTake Game; // = new GDGiveORTake();
        public RectTransform PanelContainer;

        protected virtual void Awake()
        {
            Game = new GDGiveORTake(PanelContainer);
        }

        public void Start()
        {

            EventSystemManager.TriggerEvent("OnGameStart");
            Game.StartGame();

        }

        protected virtual void Update()
        {
            Game.Game(GDManager.Instance.users);
        }
        #region Canvas Functions


        #endregion

    }
}