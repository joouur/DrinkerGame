using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.Tools;

namespace GameDrinker.Gameplay
{
    public abstract class GameDrinkerComponent : IGame
    {
        private IGame game;

        public abstract void StartGame();
        public abstract bool EndGame();

        public abstract void Game(List<User> user);

        public abstract void PlayTurns(User user);
    }
}