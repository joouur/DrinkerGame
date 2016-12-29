using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDrinker.Gameplay
{
    public class GDRulesDecorator : GDRulesComponent
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
        }

        public override bool Rule()
        {
            if(DrinkingType())
            {
                //Implementation
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

        /// <summary>
        /// Activate when the rule is drinking related
        /// </summary>
        /// <returns></returns>
        public override bool DrinkingType()
        {
            return false;
        }

        /// <summary>
        /// Activate when the rule is Gametypes related
        /// </summary>
        /// <returns></returns>
        public override bool GameType()
        {
            return false;
        }

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
        public override void TakeTheDrink()
        {
            return;
        }
    }
}