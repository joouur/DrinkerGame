using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.Gameplay;
using GameDrinker.GentleUI;

namespace GameDrinker.Managers
{
    public class RulesManager : MonoBehaviour
    {
        static private RulesManager instance;
        static public RulesManager Instance
        { get { return instance; } }

        private GDRulesDecorator WinRule;
        private GDRulesDecorator LoseRule;

        public List<GDRulesDecorator> ActiveRules;

        public List<GDRulesDecorator> TotalRules;

        public GameObject RulesPanel;

        public RectTransform UserSelector;
        public RectTransform UserLoser;

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Rules Manager is already in play. Deleting old, instantiating new!", this.gameObject);
                Destroy(RulesManager.Instance.gameObject);
                instance = null;
            }
            else
            {
                instance = this;
            }

            WinRule = new BaseWinningRule(RulesPanel);
            LoseRule = new BaseLosingRule();

            if (UserSelector)
            { UserSelector.GetComponent<SelectorPanel>().AddButtonsToPanel(); }


        }

        protected virtual void Start()
        {
            if (!UserSelector)
            {
                UserSelector = GameObject.FindGameObjectWithTag("Selector").GetComponent<RectTransform>(); 
            }
            UserSelector.gameObject.SetActive(false);

        }

        #region Base Rules Functions
        public void ApplyBaseRules(bool condition)
        {
            if (condition)
            {
                WinRule.Rule();
            }
            else
            {
                LoseRule.Rule();
            }
        }

        public void ApplyBaseRules(bool condition, int drinks)
        {
            if (condition)
            {
                WinRule.Drinks = drinks;
                WinRule.Rule();
            }
            else
            {
                LoseRule.Drinks = drinks;
                LoseRule.Rule();
            }
        }
        #endregion


        #region Active Rules Functions
        /// <summary>
        /// Add a rule to the List
        /// </summary>
        /// <param name="rule"></param>
        public void AddRule(GDRulesDecorator rule)
        {
            ActiveRules.Add(rule);
        }

        /// <summary>
        /// Return Rule according to index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public GDRulesDecorator ReturnRule(int i)
        {
            return ActiveRules[i];
        }

        /// <summary>
        /// Apply All Rules 
        /// </summary>
        public void ApplyRules()
        {
            foreach(GDRulesDecorator rule in ActiveRules)
            {
                rule.Rule();
            }
        }

        /// <summary>
        /// Apply a single rule
        /// </summary>
        /// <param name="i"></param>
        public void ApplySpecificRule(int i)
        {

            GDRulesDecorator ruleToApply = ReturnRule(i);
            if(ruleToApply == null)
            {
                throw new System.Exception("No rull exist in context");
            }
            ruleToApply.Rule();
        }

        public void CouritineToRun(IEnumerator cor)
        {
            StartCoroutine(cor);
        }

        public void DisableLoserPanel()
        {
            UserLoser.gameObject.SetActive(false);
        }
        #endregion


    }
}