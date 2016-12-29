using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDrinker.Tools;
using GameDrinker.Managers;

namespace GameDrinker.Gameplay
{
    public class GDGiveORTake : GameDrinkerDecorator
    {
        #region Data
        private int Round;
        private Canvas GDGUI;

        private GameObject GOTCanvas;

        private List<Button> GTButtons;

        #endregion

        
        #region Gameplay Functions
        /* Functions for Give Or Take GamePlay, BoR, HoL, IoO, PaS */

        /// <summary>
        /// Choose for black or red
        /// </summary>
        /// <param name="choice">choice == Black, !choice == Red</param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected virtual bool BlackOrRed(bool choice, User user)
        {
            user.Cards.Add(GDManager.Instance.CurrentDeck.getNewCard(52));
            if ((choice && (user.Cards[0].CardColor == GDCARDCOLOR.BLACK))
                || (!choice && (user.Cards[0].CardColor == GDCARDCOLOR.RED)))
            {
                // Win
                WinLost(true);
                return true;
            }
            // Lose
            WinLost();
            return false;
        }

        /// <summary>
        /// Choose higher or lowr
        /// </summary>
        /// <param name="choice">choice == Higher, !choice == Lower</param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected virtual bool HiherOrLower(bool choice, User user)
        {
            user.Cards.Add(GDManager.Instance.CurrentDeck.getNewCard(52));

            int pOne = user.Cards[0].Power;
            int pTwo = user.Cards[1].Power;

            if ((choice && (pOne < pTwo)) || (!choice && (pOne > pTwo)))
            {
                // Win
                WinLost(true, 2);
                return true;
            }
            else if (pOne == pTwo)
            {
                // 2x Lose
                WinLost(false, 4);
                return false;
            }
            // Lose
            WinLost(false, 2);
            return false;
        }

        /// <summary>
        /// Choose for Between or Outside
        /// </summary>
        /// <param name="choice">choice == Between, !choice == Outside</param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected virtual bool BetweenOrOutside(bool choice, User user)
        {
            user.Cards.Add(GDManager.Instance.CurrentDeck.getNewCard(52));

            int pOne = user.Cards[0].Power;
            int pTwo = user.Cards[1].Power;
            int pThree = user.Cards[2].Power;

            if (pOne < pTwo)
            {
                if ((choice && InBetween(pOne, pTwo, pThree)) || (!choice && !InBetween(pOne, pTwo, pThree)))
                {
                    // Win
                    WinLost(true, 3);
                    return true;
                }
                else
                {
                    // Lose
                    WinLost(false, 3);
                    return false;
                }
            }
            else if (pOne > pTwo)
            {
                if ((choice && InBetween(pTwo, pOne, pThree)) || (!choice && !InBetween(pTwo, pOne, pThree)))
                {
                    // Win
                    WinLost(true, 3);
                    return true;
                }
                else
                {
                    // Lose
                    WinLost(false, 3);
                    return false;
                }
            }
            else if (pOne == pThree || pTwo == pThree)
            {
                // Lose 2X
                WinLost(false, 3);
                return false;
            }

            // Lose
            WinLost(false, 3);
            return false;
        }

        /// <summary>
        /// Choose for Picking a Suit
        /// </summary>
        /// <param name="choice">choice == Cardsuit for win</param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected virtual bool PickASuit(SUITS choice, User user)
        {
            user.Cards.Add(GDManager.Instance.CurrentDeck.getNewCard(52));

            SUITS s = user.Cards[3].Suit;
            if (choice == s)
            {
                // Win
                WinLost(true, 4);
                return true;    
            }

            // Lose
            WinLost(false, 4);
            return false;
        }
        #endregion

        #region Decorator Override Functions
        public override void StartGame()
        {
            base.StartGame();
            var Obj = Resources.Load("UI/GiveOrTakeUI") as GameObject;

            if(Obj == null)
            { throw new Exception("Failed to Load GiveOrTake UI, Please find the new Path or Object's Name"); }
            else
            {
                GOTCanvas = GameObject.Instantiate(Obj);
                GDGUI = GOTCanvas.GetComponent<Canvas>();
                var buttons = GOTCanvas.GetComponentsInChildren(typeof(Button));

                GTButtons = new List<Button>();
                foreach (Button b in buttons)
                {
                    Debug.Log("Added button " + b.name);
                    GTButtons.Add(b);
                }
                // TODO: Think method to extract the Methods of gameplay for delegating the User who is playing to the buttons
                GTButtons[0].onClick.AddListener(delegate { TheD(); });

                EventSystemManager.TriggerEvent("OnGiveOrTake");
            }

        }

        public void TheD() { Debug.Log("Randondom"); }


        public override bool EndGame()
        {
            throw new NotImplementedException();
        }

        public override void Game(List<User> users)
        {
            
        }

        public override void PlayTurns(User user)
        {
            switch(Round)
            {
                case 1:
                    break;
            }
        }
        #endregion

        #region Helper Functions
        private void WinLost(bool win = false, int drinks = 1)
        {
            RulesManager.Instance.ApplyBaseRules(win);
        }

        /// <summary>
        /// Helper Function for in between numbers
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        private bool InBetween(int min, int max, int check)
        {
            return (check >= min && check <= max);
        }

        public void ChangeUser(User user)
        {
            GTButtons[0].onClick.RemoveAllListeners();
            GTButtons[0].onClick.AddListener(delegate { BlackOrRed(false, user); });

        }
        #endregion

    }
}