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
        //[Range(0, 4)]
        private int Round;
        private int userNum;
        private Canvas GDGUI;

        private RectTransform GTPanelContainer;

        private List<Button> GTButtons;

        #endregion

        
        #region Gameplay Functions
        /* Functions for Give Or Take GamePlay, BoR, HoL, IoO, PaS */

        /// <summary>
        /// Activate BlackOrRed Buttons
        /// </summary>
        /// <param name="act"></param>
        public void BlackOrRedActivate(bool act)
        {
            GTButtons[0].gameObject.SetActive(act);
            GTButtons[1].gameObject.SetActive(act);
        }

        /// <summary>
        /// Choose for black or red
        /// </summary>
        /// <param name="choice">choice == Black, !choice == Red</param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected virtual bool BlackOrRed(bool choice, User user)
        {
            Debug.Log("PING" + user.name);

            user.AddCard();
            userNum++;

            user.NextUser(GDManager.Instance.users[userNum]);

            Debug.Log(userNum);
            if ((choice && (user.Cards[0].CardColor == GDCARDCOLOR.BLACK))
                || (!choice && (user.Cards[0].CardColor == GDCARDCOLOR.RED)))
            {
                AddUserToButton(GDManager.Instance.users[userNum]);

                // Win
                WinLost(true);
                return true;
            }
            AddUserToButton(GDManager.Instance.users[userNum]);

            // Lose
            WinLost();
            return false;
        }

        /// <summary>
        /// Activate HigherOrLower Buttons
        /// </summary>
        /// <param name="act"></param>
        public void HigherOrLowerActivate(bool act)
        {
            GTButtons[2].gameObject.SetActive(act);
            GTButtons[3].gameObject.SetActive(act);
        }

        /// <summary>
        /// Choose higher or lowr
        /// </summary>
        /// <param name="choice">choice == Higher, !choice == Lower</param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected virtual bool HigherOrLower(bool choice, User user)
        {
            user.AddCard();

            int pOne = user.Cards[0].Power;
            int pTwo = user.Cards[1].Power;

            user.NextUser(GDManager.Instance.users[userNum + 1]);
            AddUserToButton(GDManager.Instance.users[userNum + 1]);

            userNum++;

            Debug.Log(userNum);

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
        /// Activate BetweenOrOutside Buttons
        /// </summary>
        /// <param name="act"></param>
        public void BetweenOrOutsideActivate(bool act)
        {
            GTButtons[4].gameObject.SetActive(act);
            GTButtons[5].gameObject.SetActive(act);
        }

        /// <summary>
        /// Choose for Between or Outside
        /// </summary>
        /// <param name="choice">choice == Between, !choice == Outside</param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected virtual bool BetweenOrOutside(bool choice, User user)
        {
            user.AddCard();

            int pOne = user.Cards[0].Power;
            int pTwo = user.Cards[1].Power;
            int pThree = user.Cards[2].Power;

            user.NextUser(GDManager.Instance.users[userNum + 1]);
            AddUserToButton(GDManager.Instance.users[userNum + 1]);

            userNum++;

            Debug.Log(userNum);
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
        /// Activate PickASuit Buttons
        /// </summary>
        /// <param name="act"></param>
        public void PickASuitActivate(bool act)
        {
            GTButtons[6].gameObject.SetActive(act);
            GTButtons[7].gameObject.SetActive(act); 
            GTButtons[8].gameObject.SetActive(act);
            GTButtons[9].gameObject.SetActive(act);
        }

        /// <summary>
        /// Choose for Picking a Suit
        /// </summary>
        /// <param name="choice">choice == Cardsuit for win</param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected virtual bool PickASuit(SUITS choice, User user)
        {
            user.AddCard();
            user.NextUser(GDManager.Instance.users[userNum + 1]);
            AddUserToButton(GDManager.Instance.users[userNum + 1]);

            userNum++;

            Debug.Log(userNum);
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

        public GDGiveORTake(RectTransform GiveOrTakePanel)
        {
            userNum = 0;
            Round = 1;
            GameObject Panel = (GameObject)MonoBehaviour.Instantiate(GiveOrTakePanel.gameObject);
            Panel.GetComponent<RectTransform>().SetParent(GameObject.FindGameObjectWithTag("InGameUIContainer").GetComponent<RectTransform>().transform);

            Panel.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, 0);
            Panel.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);

            Panel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            Panel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

            Panel.transform.localScale = new Vector3(1, 1, 1);

            GTPanelContainer = GameObject.Find("GoT_Grid").GetComponent<RectTransform>();
        }

        public override void StartGame()
        {
            base.StartGame();
            if (GTPanelContainer == null)
            { throw new Exception("Failed to Load GiveOrTake UI, Please find the new Path or Object's Name"); }
            else
            {
                GTButtons = new List<Button>();
                for (int i = 0; i < 10; ++i)
                {
                    AddButton();
                }
                // TODO: Think method to extract the Methods of gameplay for delegating the User who is playing to the buttons
                AddUserToButton(GDManager.Instance.users[0]);
                GDManager.Instance.users[0].Turn = true;

                EventSystemManager.TriggerEvent("OnGiveOrTake");
            }

        }

        public override bool EndGame()
        {
            throw new NotImplementedException();
        }

        public override void Game(List<User> users)
        {
            if (GDManager.Instance.users.Count <= userNum)
            {
                Round++;
                userNum = 0;
                Debug.Log("PING" + GDManager.Instance.users[userNum].name);
                PlayTurns(GDManager.Instance.users[0]);

            }
            else
            {
                
                    PlayTurns(GDManager.Instance.users[userNum]);
            }
        }

        public override void PlayTurns(User user)
        {
            switch (Round)
            {
                case 1:
                    BlackOrRedActivate(true);
                    break;
                case 2:
                    BlackOrRedActivate(false);
                    HigherOrLowerActivate(true);
                    break;
                case 3:
                    HigherOrLowerActivate(false);
                    BetweenOrOutsideActivate(true);
                    break;
                case 4:
                    BetweenOrOutsideActivate(false);
                    PickASuitActivate(true);
                    break;
                default:
                    BlackOrRedActivate(false);
                    HigherOrLowerActivate(false);
                    BetweenOrOutsideActivate(false);
                    PickASuitActivate(false);
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

        private void AddButton()
        {
            GameObject b = (GameObject)MonoBehaviour.Instantiate(BaseButton);
            b.name = "BTN_GiveOrTake" + GTButtons.Count;
            b.transform.SetParent(GTPanelContainer.transform);
            b.gameObject.SetActive(false);

            b.transform.localScale = new Vector3(1, 1, 1);
            b.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

            GTButtons.Add(b.GetComponent<Button>());
        }

        private void AddUserToButton(User user)
        {

            GTButtons[0].onClick.RemoveAllListeners();
            GTButtons[1].onClick.RemoveAllListeners();
            GTButtons[2].onClick.RemoveAllListeners();
            GTButtons[3].onClick.RemoveAllListeners();
            GTButtons[4].onClick.RemoveAllListeners();
            GTButtons[5].onClick.RemoveAllListeners();
            GTButtons[6].onClick.RemoveAllListeners();
            GTButtons[7].onClick.RemoveAllListeners();
            GTButtons[8].onClick.RemoveAllListeners();
            GTButtons[9].onClick.RemoveAllListeners();

            // Black Or Red
            GTButtons[0].gameObject.GetComponentInChildren<Text>().text = "Black";
            GTButtons[0].onClick.AddListener(delegate { BlackOrRed(true, user); });

            GTButtons[1].gameObject.GetComponentInChildren<Text>().text = "Red";
            GTButtons[1].onClick.AddListener(delegate { BlackOrRed(false, user); });
            // Black Or Red

            // Higher Or Lower
            GTButtons[2].gameObject.GetComponentInChildren<Text>().text = "Higher";
            GTButtons[2].onClick.AddListener(delegate { HigherOrLower(true, user); });

            GTButtons[3].gameObject.GetComponentInChildren<Text>().text = "Lower";
            GTButtons[3].onClick.AddListener(delegate { HigherOrLower(false, user); });
            //Higher Or Lower

            //Between Or Outside
            GTButtons[4].gameObject.GetComponentInChildren<Text>().text = "Between";
            GTButtons[4].onClick.AddListener(delegate { BetweenOrOutside(true, user); });

            GTButtons[5].gameObject.GetComponentInChildren<Text>().text = "Outside";
            GTButtons[5].onClick.AddListener(delegate { BetweenOrOutside(false, user); });
            // Between Or Outside

            // Pick A Suit
            GTButtons[6].gameObject.GetComponentInChildren<Text>().text = "Spade";
            GTButtons[6].onClick.AddListener(delegate { PickASuit(SUITS.SPADES, user); });

            GTButtons[7].gameObject.GetComponentInChildren<Text>().text = "Diamonds";
            GTButtons[7].onClick.AddListener(delegate { PickASuit(SUITS.DIAMONDS, user); });

            GTButtons[8].gameObject.GetComponentInChildren<Text>().text = "Hearts";
            GTButtons[8].onClick.AddListener(delegate { PickASuit(SUITS.HEARTS, user); });

            GTButtons[9].gameObject.GetComponentInChildren<Text>().text = "Clubs";
            GTButtons[9].onClick.AddListener(delegate { PickASuit(SUITS.CLUBS, user); });
            //Pick A Suit
        }
        #endregion

    }
}