using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDrinker.GentleUI
{
    public class StartWindow : GenericWindow
    {
        public Button continueButton;

        protected override void Awake()
        {
        }

        public void Start()
        {
            Open();
        }

        public override void Open()
        {
            bool triggerContinue = false;
            continueButton.gameObject.SetActive(triggerContinue);
            if (continueButton.gameObject.activeSelf)
            {
                firstSelect = continueButton.gameObject;
            }
            base.Open();
        }

        public void SelectGame()
        {}

        public void Continue()
        {}

        public void Options()
        { }
    }
}