using System.Collections.Generic;

using UnityEngine;

public interface IGame
{
    int Round { get; set; }
    void Game(List<User> users);
    void StartGame();
    bool EndGame();

    void PlayTurns(User user);
}

public interface IRules
{

    int Drinks { get; set; }

    bool Rule();

    bool GameType();
    bool DrinkingType();

    void Display();

    void GiveTheDrink(User user);
    void TakeTheDrink(User user);
    void RandomUser(List<User> users);
}