using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDrinker.Tools;

namespace GameDrinker.Gameplay
{
    public abstract class GameDrinkerDecorator : GameDrinkerComponent
    {
        private IGame game;
        protected GameObject BaseButton = Resources.Load("UI/BaseButton") as GameObject;

        public GameDrinkerDecorator()
        { return; }

        public override void StartGame()
        {
            if(BaseButton == null)
                    BaseButton = Resources.Load("UI/BaseButton") as GameObject;
            return;
        }

        public override bool EndGame()
        { return false; }

        public override void Game(List<User> user)
        { return; }

        public override void PlayTurns(User user)
        { return; }
    }
}