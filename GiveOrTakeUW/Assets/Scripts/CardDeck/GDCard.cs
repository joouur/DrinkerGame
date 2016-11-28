using UnityEngine;
using System.Collections;
using GameDrinker.Tools;

namespace GameDrinker.Decks
{

    /// <summary>
    /// Card Class
    /// </summary>
    [System.Serializable]
    public class GDCard
    {
        [SerializeField]
        private string rank;
        public string Rank
        {
            get { return rank; }
            set
            {
                if (value == "11")
                { rank = "Jack"; }
                else if(value == "12")
                { rank = "Queen"; }
                else if(value == "13")
                { rank = "King"; }
                else
                { rank = value; }
            }
        }

        [SerializeField]
        private GDEnums.SUITS suit;
        public GDEnums.SUITS Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        private bool isOnUse;
        public bool IsOnUse
        {
            get { return isOnUse; }
            set { isOnUse = value; }
        }
        [SerializeField]
        private GDEnums.GDCARDCOLOR cardColor;
        public GDEnums.GDCARDCOLOR CardColor
        {
            get { return cardColor; }
            set
            {
                if (suit == GDEnums.SUITS.CLUBS || suit == GDEnums.SUITS.SPADES)
                { cardColor = GDEnums.GDCARDCOLOR.BLACK; }
                else if (suit == GDEnums.SUITS.HEARTS || suit == GDEnums.SUITS.DIAMONDS)
                { cardColor = GDEnums.GDCARDCOLOR.RED; }
            }
        }

        public GameObject prefab;

        GDCard()
        {
            Rank = "0";
            Suit = GDEnums.SUITS.SPADES;
        }

        public GDCard(string n, GDEnums.SUITS s)
        {
            Rank = n;
            Suit = s;
        }

    }
}