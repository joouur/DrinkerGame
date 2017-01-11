using System.Collections.Generic;

using UnityEngine;
using GameDrinker;

namespace GameDrinker.Tools
{
    public interface IGame
    {         
        void Game(List<User> users);
        void StartGame();
        bool EndGame();

        void PlayTurns(User user);
    }

    public interface IRules
    {

        int Drinks { get; }

        bool Rule();

        bool GameType();
        bool DrinkingType();
        
        void Display();
        
        void GiveTheDrink(User user);
        void TakeTheDrink(User user);
        void RandomUser(List<User> users);
    }
}