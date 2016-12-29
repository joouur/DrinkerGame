using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameDrinker.Managers;

namespace GameDrinker.Gameplay
{
    public class GDGamePlay : MonoBehaviour
    {

        GameDrinkerDecorator Game; // = new GDGiveORTake();
        
        protected virtual void Awake()
        {
            Game = new GDGiveORTake();
            Game.StartGame();
        }

        #region Canvas Functions
        /*
        public void Choices(bool choice, int index)
        {
           
            Game.BlackOrRed(choice, GDManager.Instance.users[index]);
        }

        public void Choice(GameObject o)
        {

        }
        public void ChoiceBlackOrRed(string s)
        {
            bool ch = Convert.ToBoolean((int)Char.GetNumericValue(s[0]));
            int k = (int)Char.GetNumericValue(s[1]);
            Game.BlackOrRed(ch, GDManager.Instance.users[k]); 
        }
        */
        #endregion

    }
}