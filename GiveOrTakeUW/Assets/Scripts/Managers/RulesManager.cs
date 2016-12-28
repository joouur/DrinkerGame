using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.Gameplay;

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
        }

        #region Base Rules Functions
        public void ApplyBaseRules(bool condition)
        {
            if(condition)
            {
                WinRule.Rule();
            }
            else
            {
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

        #endregion


    }
}