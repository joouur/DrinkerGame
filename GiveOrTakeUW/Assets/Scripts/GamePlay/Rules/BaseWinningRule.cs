using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDrinker.Managers;
using GameDrinker.GentleUI;

namespace GameDrinker.Gameplay
{
    public class BaseWinningRule : GDRulesDecorator
    {
        protected RectTransform Panel;
        private List<Button> WinButtons = new List<Button>();

        #region Decorator Specific
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

        public BaseWinningRule(GameObject i)
        {
            drink = 1;

            if(i == null)
            { throw new System.Exception("No Rules Panel Assigned!"); }

            GameObject p = (GameObject)MonoBehaviour.Instantiate(i.gameObject);

            p.GetComponent<RectTransform>().SetParent(GameObject.FindGameObjectWithTag("GameUI").GetComponent<RectTransform>().transform);

            p.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, 0);
            p.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);

            p.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            p.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

            p.transform.localScale = new Vector3(1, 1, 1);

            Panel = p.GetComponent<RectTransform>();
            Panel.gameObject.SetActive(false);

            AddButton();
            WinButtons[0].GetComponentInChildren<Text>().text = "Give to User?";
            WinButtons[0].onClick.AddListener(delegate { Give(); });
            AddButton();
            WinButtons[1].GetComponentInChildren<Text>().text = "Give to Random User?";
            WinButtons[1].onClick.AddListener(delegate { RandomUser(GDManager.Instance.users); });
        }

        public override bool Rule()
        {
            if (DrinkingType())
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
            Panel.gameObject.SetActive(!Panel.gameObject.activeInHierarchy);
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
        {
            Display();
            return true;
        }

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
            user.UpdateDrinksToTake(1);
            return;
        }

        /// <summary>
        /// Designate a drink to a random user within the game.
        /// </summary>
        /// <param name="users"></param>
        public override void RandomUser(List<User> users)
        {
            users[UnityEngine.Random.Range(0, users.Count + 1)].UpdateDrinksToTake(1);
            return;
        }

        /// <summary>
        /// Get a drink to the corresponding user
        /// </summary>
        public override void TakeTheDrink(User user)
        {
            return;
        }
        #endregion
        public void Give()
        {
            Panel.gameObject.SetActive(false);
            RulesManager.Instance.UserSelector.gameObject.SetActive(true);
            RulesManager.Instance.UserSelector.GetComponent<SelectorPanel>().Drinks = 1;
        }

        private void AddButton()
        {
            GameObject BaseButton = Resources.Load("UI/BaseButton") as GameObject;
            GameObject b = (GameObject)MonoBehaviour.Instantiate(BaseButton);
            b.name = "BTN_WinningRules" + WinButtons.Count;
            b.transform.SetParent(Panel.transform);
            b.gameObject.SetActive(true);

            b.transform.localScale = new Vector3(1, 1, 1);
            b.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

            WinButtons.Add(b.GetComponent<Button>());
        }
    }
}