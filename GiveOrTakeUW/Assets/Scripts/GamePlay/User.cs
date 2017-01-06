using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameDrinker.Tools;
using GameDrinker.Decks;
using GameDrinker.GentleUI;

namespace GameDrinker
{
    /// <summary>
    /// User base Class
    /// Stores information needed in all Games
    /// </summary>
    [RequireComponent(typeof(Rect))]
    [System.Serializable]
    public class User : MonoBehaviour
    {
        #region Data

        #region User Main Data
        [Space(10)]
        [Header("User Information")]
        [SerializeField]
        private int iD;
        /// <summary>
        /// Accessor for User Name
        /// </summary>
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        [SerializeField]
        private string _name = "Default";
        /// <summary>
        /// Accessor for User Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [SerializeField]
        private USERSTATUS _status;
        /// <summary>
        /// Accessor for User Status
        /// </summary>
        public USERSTATUS Status
        {
            get { return _status; }
            set { _status = value; } 
        }

        [Space(10)]
        [Header("Game Information")]
        [SerializeField]
        private int drinksToTake = 0;
        /// <summary>
        /// Accessor for User Amount of drinks to Take
        /// </summary>
        public int DrinksToTake
        {
            get { return drinksToTake; }
            set { drinksToTake = value; }
        }

        [SerializeField]
        private int drinksToGive = 0;
        /// <summary>
        /// Accessor for User Amount of drinks to Give
        /// </summary>
        public int DrinksToGive
        {
            get { return drinksToGive; }
            set { drinksToGive = value; }
        }

        [SerializeField]
        private bool turn;
        /// <summary>
        /// User Turn
        /// </summary>
        public bool Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        /// <summary>
        /// List of Cards that the user has.
        /// Delete and Reinstantiate List after every game.
        /// </summary>
        public List<GDCard> Cards = new List<GDCard>();

        protected bool AI;
        #endregion

        #region Canvas Data
        [Space(10)]
        [Header("Canvas Data")]
        public Text T_Name;
        public Text T_DrinksToGive;
        public Text T_DrinksToTake;

        public GameObject CardsPanel;
        public Tools.ObjectPooler.SinglePooling CardPrefab;
        #endregion
        #endregion

        public void Init()
        {
            T_Name.text = Name;
            T_DrinksToGive.text = DrinksToGive.ToString();
            T_DrinksToTake.text = DrinksToTake.ToString();
        }

        public void UpdateDrinksToGive(int drinks)
        {
            DrinksToGive = drinks;
            T_DrinksToGive.text = DrinksToGive.ToString();
        }

        public void UpdateDrinksToTake(int drinks)
        {
            DrinksToTake = drinks;
            T_DrinksToTake.text = DrinksToTake.ToString();
        }

        public void AddCards(GDCard card)
        {
            
            CardPrefab.GetComponent<CardUIBehaviour>().ChangeSprite(card.FrontSprite);
        }

        public void Awake()
        {
        }

        protected virtual void OnAddPlayer()
        {
            
        }
    }
}