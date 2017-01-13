using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDrinker.Managers;
using GameDrinker.Tools;

namespace GameDrinker.GentleUI
{
    public class SelectorPanel : MonoBehaviour
    {
        public int drinks;
        public Text drinkingText;

        public int Drinks
        {
            set
            {
                drinks = value;
                drinkingText.text = drinks.ToString();
            }
        }

        public List<Button> UserButtons;

        public void AddButtonsToPanel()
        {
            this.gameObject.SetActive(true);
            for (int i = 0; i < GDManager.Instance.users.Count; ++i)
            {
                AddButton(GDManager.Instance.users[i]);
            }
            if (gameObject.activeInHierarchy)
            { this.gameObject.SetActive(false); }
        }
        
        public void AddButton(User u)
        {
            GameObject BaseButton = Resources.Load("UI/BaseButton") as GameObject;
            GameObject b = (GameObject)MonoBehaviour.Instantiate(BaseButton);
            b.name = "BTN_User" + UserButtons.Count;
            b.transform.SetParent(GameObject.Find("UserPanel").transform);
            b.gameObject.SetActive(true);

            b.transform.localScale = new Vector3(1, 1, 1);
            b.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            b.GetComponentInChildren<Text>().text = u.Name;

            UserButtons.Add(b.GetComponent<Button>());
            UserButtons[UserButtons.Count - 1].onClick.AddListener(delegate { GiveTheDrink(u); });
        }

        private void GiveTheDrink(User u)
        {
            u.UpdateDrinksToTake(1);
            drinks--;
            Drinks = drinks;
            RulesManager.Instance.UserLoser.gameObject.SetActive(true);
            RulesManager.Instance.UserLoser.GetComponentInChildren<Text>().text = u.name + "\n DRINKS!";
            RulesManager.Instance.CouritineToRun(GDCanvas.TimedPanelSet(RulesManager.Instance.UserLoser, 2.5f));
            if (drinks == 0)
            {
                this.gameObject.SetActive(false);
            }
        
        }
    }
}