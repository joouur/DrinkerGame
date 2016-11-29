using UnityEngine;
using GameDrinker;

namespace GameDrinker.Tools
{
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

}