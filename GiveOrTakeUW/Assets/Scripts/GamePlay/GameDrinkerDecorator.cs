using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.Tools;

namespace GameDrinker.Gameplay
{
    public abstract class GameDrinkerDecorator : GameDrinkerComponent
    {
        private IGame game;

        public override void StartGame()
        { return; }
        public override bool EndGame()
        { return false; }

        public override void Game(List<User> user)
        { return; }

        public override void PlayTurns(User user)
        { return; }
    }
}