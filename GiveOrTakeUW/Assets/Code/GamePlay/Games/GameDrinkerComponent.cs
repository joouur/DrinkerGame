using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameDrinkerComponent : IGame
{
    private IGame game;

    public abstract int Round { get; set; }
    public abstract void StartGame();
    public abstract bool EndGame();

    public abstract void Game(List<User> user);

    public abstract void PlayTurns(User user);
}