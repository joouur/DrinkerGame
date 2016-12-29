using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.Tools;

namespace GameDrinker.Gameplay
{
    public abstract class GDRulesComponent : IRules
    {
        private IRules Rules;

        public abstract int Drinks { get; }

        public abstract bool Rule();

        public abstract bool DrinkingType();
        public abstract bool GameType();

        public abstract void Display();

        public abstract void GiveTheDrink(User user);
        public abstract void TakeTheDrink();
        public abstract void RandomUser(List<User> users);
    }
}