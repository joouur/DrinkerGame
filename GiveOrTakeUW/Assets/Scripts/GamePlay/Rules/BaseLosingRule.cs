using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.Managers;

namespace GameDrinker.Gameplay
{
    public class BaseLosingRule : GDRulesDecorator
    {
        protected int drink;

        public override int Drinks
        {
            get
            {
                if (drink == 0)
                    return 1;
                return drink;
            }
            set
            { drink = value; }
        }

        public BaseLosingRule()
        { drink = 1; }

        public BaseLosingRule(int d)
        {
            drink = d;
        }

        public override bool Rule()
        {
            if (DrinkingType())
            {
                TakeTheDrink(GDManager.Instance.CurrentUser);
                return true;
            }
            else if (GameType())
            {
                //Implementation
                return true;
            }

            return false;
        }

        /// <summary>
        /// Function for showing display.
        /// </summary>
        public override void Display()
        {
            return;
        }

        public int DisplayPrompt()
        {
            return 0;
        }
        /// <summary>
        /// Activate when the rule is drinking related
        /// </summary>
        /// <returns></returns>
        public override bool DrinkingType()
        { return true; }

        /// <summary>
        /// Activate when the rule is Gametypes related
        /// </summary>
        /// <returns></returns>
        public override bool GameType()
        { return false; }

        /// <summary>
        /// Gives a drink to a designated user
        /// </summary>
        /// <param name="user"></param>
        public override void GiveTheDrink(User user)
        {
            return;
        }

        /// <summary>
        /// Designate a drink to a random user within the game.
        /// </summary>
        /// <param name="users"></param>
        public override void RandomUser(List<User> users)
        {
            return;
        }

        /// <summary>
        /// Get a drink to the corresponding user
        /// </summary>
        public override void TakeTheDrink(User user)
        {
            user.UpdateDrinksToTake(1);
        }
    }
}