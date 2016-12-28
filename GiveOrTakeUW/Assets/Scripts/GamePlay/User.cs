using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameDrinker.Tools;
using GameDrinker.Decks;

namespace GameDrinker
{
    /// <summary>
    /// User base Class
    /// Stores information needed in all Games
    /// </summary>
    [System.Serializable]
    public class User : MonoBehaviour
    {
        [Space(10)]
        [Header("User Information")]

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
        private uint drinksToTake;
        /// <summary>
        /// Accessor for User Amount of drinks to Take
        /// </summary>
        public uint DrinksToTake
        {
            get { return drinksToTake; }
            set { drinksToTake = value; }
        }

        [SerializeField]
        private uint drinksToGive;
        /// <summary>
        /// Accessor for User Amount of drinks to Give
        /// </summary>
        public uint DrinksToGive
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

        protected virtual void Start()
        {
            
        }
    }
}