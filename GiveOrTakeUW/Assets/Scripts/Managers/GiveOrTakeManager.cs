using UnityEngine;
using System.Collections;
using GameDrinker;
using GameDrinker.Decks;
using GameDrinker.Tools;
using System;

namespace GameDrinker.Managers
{
    /// <summary>
    /// Give Or Take Game Manager.
    /// </summary>
    [RequireComponent(typeof(GDDeck))]
    public class GiveOrTakeManager : GDBaseModManager, IMode<GDModes>, IGame<GDGIVEORTAKE>
    {

        public IMode<GDModes> Mode;
        public IGame<GDGIVEORTAKE> Rounds;

        private int round = 0;
        int IGame<GDGIVEORTAKE>.Round
        {
            get { return round; }
            set { round = value; }
        }

        public override int Round
        {
            get { return round; }
            set { round = value; }
        }

        protected virtual void Start()
        {
            UserInitializer();
            Mode = GetComponent<GiveOrTakeManager>();
            Mode.Init(GDModes.GIVE_OR_TAKE);
            //EventSystemManager.TriggerEvent("GIVE_OR_TAKE");
        }

        void IGame<GDGIVEORTAKE>.Game(int round)
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Mode.ChangeMode(GDModes.FUCK_THE_DEALER);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Mode.DrinksToGive = 2;
                Mode.TakeDrink(users[1]);
                Debug.Log(Mode.CurrentMode.ToString() + " " + Mode.DrinksToGive + " ");
            }
            
        }
        
        /// <summary>
        /// 
        ///    GOTManager:
        /// Void TurnSelector()-
        /// Void TurnPasser()+
        /// Bool BlackOrRed(bool)+
        /// Bool HighOrLow(bool)+
        /// Bool BetweenOrOutside(string, string)+
        /// Bool PickASuitr(enum)+
        /// </summary>
        /// <param name="round"></param>
        public override void Game(int round)
        {
            throw new NotImplementedException();
        }

        void IGame<GDGIVEORTAKE>.StartGame(GAMESTATUS status)
        {
        }

        internal override void StartGame(GAMESTATUS status)
        {
            throw new NotImplementedException();
        }

        protected virtual bool BlackOrRed(bool choice)
        {
            return false;
        }
        protected virtual bool HighOrLow(bool choice)
        { return false; }
        protected virtual bool BetweenOrOutside(string first, string second, bool choice)
        { return false; }
        protected virtual bool PickASuit(SUITS choice)
        { return false; }

    }
}