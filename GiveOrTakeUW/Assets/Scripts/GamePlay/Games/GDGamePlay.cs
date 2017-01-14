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
            EventSystemManager.StartListening("OnTransition", OnTransitionRounds);

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

        public void OnTransitionRounds()
        {
            GDManager.Instance.Status = Tools.GAMESTATUS.TRANSITIONOFGAME;
            StartCoroutine(Transition());
        }

        private IEnumerator Transition()
        {
            int r = Game.Round;
            Game.Round = 0;
            yield return new WaitForSeconds(3);
            Game.Round = r;
            GDManager.Instance.Status = Tools.GAMESTATUS.INPROGRESS;
        }
        #region Canvas Functions


        #endregion

    }
}