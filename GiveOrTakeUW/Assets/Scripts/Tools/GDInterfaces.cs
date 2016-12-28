using System.Collections.Generic;

using UnityEngine;
using GameDrinker;

namespace GameDrinker.Tools
{
<<<<<<< HEAD
    public interface IMode<T>
    {
        uint DrinksToTake { get; set; }
        uint DrinksToGive { get; set; }

        GDModes PreviousMode { get; set; }
        GDModes CurrentMode { get; set; }

        void Init(T Mode);
        void ChangeMode(T Mode);

        void PlayTurns();
        void TimeTurns();
        void NextUser();
        void TakeDrink(User user);
        void GiveDrink(User user);
        void AlreadyDrank(User user);
    }

    public interface IGame<T>
    {         
        int Round { get; set; }
        void Game(int round);
        void StartGame(GAMESTATUS status);
    }

=======
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
        void TakeTheDrink();
        void RandomUser(List<User> users);
    }
>>>>>>> feature/Changes
}