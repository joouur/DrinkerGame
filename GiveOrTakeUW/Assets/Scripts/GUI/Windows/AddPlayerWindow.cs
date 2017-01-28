using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace GameDrinker.GentleUI
{
    public class AddPlayerWindow : GenericWindow
    {
        public Text playerNum;

        private int pNum;
        private int NumberOfPlayers
        {
            get { return pNum; }
            set
            {
                pNum = value;
                playerNum.text = pNum.ToString();
            }
        }
    
        public void Start()
        {
            Display(true);   
        }

        public void AddPlayer()
        {
            if (pNum >= 12)
            { return; }
            else
            { NumberOfPlayers += 1; }
        }

        public void SubPlayer()
        {
            if (pNum == 0)
            { return; }
            else
            { NumberOfPlayers -= 1; }
        }
    }
}