using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDrinker.GentleUI
{
    public class GameName : MonoBehaviour
    {
        [SerializeField]
        private Text _gameName;
        public string gameName
        {
            set { _gameName.text = value; }
        }

        [SerializeField]
        private Text roundNum;
        public int RoundNumber
        {
            set { roundNum.text = value.ToString(); }
        }

        [SerializeField]
        private Text roundName;
        public string RoundName
        {
            set { roundName.text = value; } 
        }


        public void Awake()
        {
            StartingNew();
        }

        public void StartingNew()
        {
            gameName = RoundName = " ";
            RoundNumber = 0;
        }

        public bool ChangeGame(string name, string Round)
        {
            if(name != null && Round != null)
            {
                gameName = name;
                RoundName = Round;
                return true;
            }

            return false;
        }

        public bool AdvanceRound(int num, string name)
        {
            if(num != 0)
            {
                RoundNumber = num;
                RoundName = name;
                return true;
            }
            return false;
        }
    }
}