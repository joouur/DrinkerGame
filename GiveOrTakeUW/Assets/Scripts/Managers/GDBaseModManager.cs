using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDrinker;
using GameDrinker.Decks;
using GameDrinker.Tools;

namespace GameDrinker.Managers
{
    [RequireComponent(typeof(GDDeck))]
    public abstract class GDBaseModManager : MonoBehaviour, IMode<GDModes>, IGame<Enum>
    {
        static private GDBaseModManager instance;
        static public GDBaseModManager Instance
        { get { return instance; } }

        #region Data

        /// <summary>
        /// Interface Variables
        /// </summary>
        protected uint ToTake;
        uint IMode<GDModes>.DrinksToTake
        {
            get { return ToTake; }
            set { ToTake = value; }
        }
        protected uint ToGive;
        uint IMode<GDModes>.DrinksToGive
        {
            get { return ToGive; }
            set { ToGive = value; }
        }

        protected GDModes prevMod;
        public GDModes PreviousMode
        {
            get { return prevMod; }
            set { prevMod = value; }
        }
        protected GDModes currMod;
        public GDModes CurrentMode
        {
            get { return currMod; }
            set { currMod = value; }
        }

        public abstract int Round { get; set; }

        public List<User> users = new List<User>();
        public GDDeck CurrentDeck;
        #endregion

        #region Class Methods
        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Game Manager is already in play. Deleting old, instantiating new!", this.gameObject);
                Destroy(GDBaseModManager.Instance.gameObject);
                instance = null;
            }
            else
            { instance = this; }
            CurrentDeck = GetComponent<GDDeck>();
            CurrentDeck.Init();
        }

        protected virtual void UserInitializer()
        {
            User[] u = FindObjectsOfType(typeof(User)) as User[];
            if(u.Length > Enum.GetNames(typeof(COLORS)).Length)
            {
                throw new Exception("There exist more Users than what is permited within the Game, naming extra users as Numbers");
            }

            for (int i = 0; i < u.Length; ++i)
            {
                COLORS randomColor = (COLORS)Enum.ToObject(typeof(COLORS), i);
                u[i].name = u[i].Name = randomColor.ToString();
                users.Add(u[i]);
            }            
        }

        protected virtual void UserReset()
        {
            users = null;
        }

        protected virtual void UserDelete(User u)
        {
            users.Remove(u);
        }
        #endregion

        #region EventListenerMethods
        private void OnGameStartFD()
        {
            Debug.Log("FD");
            throw new NotImplementedException();
        }
        private void OnGameStartGOT()
        {
            Debug.Log("GOT");
            throw new NotImplementedException();
        }
        private void OnGameStartKP()
        {
            Debug.Log("KP");
            throw new NotImplementedException();
        }
        private void OnGameStartP()
        {
            Debug.Log("P");
            throw new NotImplementedException();
        }

        //public virtual void StartGame();
        #endregion

        #region Interface Methods
        // IMode Interface to be determine within base Class

        public void Init(GDModes Mode)
        {
            currMod = Mode;

            if (Mode == GDModes.DEFAULT)
            { throw new Exception(gameObject.name + " is trying to Instantiate a GameMode that does not exist!"); }
            else if (Mode == GDModes.FUCK_THE_DEALER)
            {
                EventSystemManager.StartListening("FUCK_THE_DEALER", OnGameStartFD);
                EventSystemManager.TriggerEvent("FUCK_THE_DEALER");
                return;
            }
            else if (Mode == GDModes.GIVE_OR_TAKE)
            {
                EventSystemManager.StartListening("GIVE_OR_TAKE", OnGameStartGOT);
                EventSystemManager.TriggerEvent("GIVE_OR_TAKE");
                return;
            }
            else if (Mode == GDModes.KINGS_CUP)
            {
                EventSystemManager.StartListening("KINGS_CUP", OnGameStartKP);
                EventSystemManager.TriggerEvent("KINGS_CUP");
                return;
            }
            else if (Mode == GDModes.PIRAMID)
            {
                EventSystemManager.StartListening("PIRAMID", OnGameStartP);
                EventSystemManager.TriggerEvent("PIRAMID");
                return;
            }
            else
            {
                Debug.LogWarning("No Mode is Selected!"); 
                return;
            }
        }

        void IMode<GDModes>.ChangeMode(GDModes Mode)
        {
            prevMod = currMod;
            if (CurrentMode == GDModes.FUCK_THE_DEALER)
            {
                EventSystemManager.StopListening("FUCK_THE_DEALER", OnGameStartFD);
            }
            else if (CurrentMode == GDModes.GIVE_OR_TAKE)
            {
                EventSystemManager.StopListening("GIVE_OR_TAKE", OnGameStartGOT);
            }
            else if (CurrentMode == GDModes.KINGS_CUP)
            {
                EventSystemManager.StopListening("KINGS_CUP", OnGameStartKP);
            }
            else if (CurrentMode == GDModes.PIRAMID)
            {
                EventSystemManager.StopListening("PIRAMID", OnGameStartP);
            }
            Init(Mode);
        }

        void IMode<GDModes>.PlayTurns()
        {
            throw new NotImplementedException();
        }

        void IMode<GDModes>.TimeTurns()
        {
            throw new NotImplementedException();
        }

        void IMode<GDModes>.TakeDrink(User user)
        {
            for(int i = 0; i < users.Count; i++)
            {
                if(users[i].Name == user.Name)
                {
                    users[i].DrinksToTake++;
                }
            }
        }

        void IMode<GDModes>.GiveDrink(User user)
        {
            throw new NotImplementedException();
        }

        void IMode<GDModes>.AlreadyDrank(User user)
        {
            throw new NotImplementedException();
        }

        void IMode<GDModes>.NextUser()
        {
            throw new NotImplementedException();
        }
        // IGame Interface To be Overrided within the Inherited Class


        public abstract void Game(int round);

        internal abstract void StartGame(GAMESTATUS status);

        void IGame<Enum>.StartGame(GAMESTATUS status)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}