using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDrinker;
using GameDrinker.Tools;

namespace GameDrinker.Managers
{
    public abstract class GDBaseGameManager : MonoBehaviour, IMode<GDEnums.GDModes>
    {
        static private GDBaseGameManager instance;
        static public GDBaseGameManager Instance
        { get { return instance; } }

        #region Data

        /// <summary>
        /// Interface Variables
        /// </summary>
        protected uint ToTake;
        uint IMode<GDEnums.GDModes>.DrinksToTake
        {
            get { return ToTake; }
            set { ToTake = value; }
        }
        protected uint ToGive;
        uint IMode<GDEnums.GDModes>.DrinksToGive
        {
            get { return ToGive; }
            set { ToGive = value; }
        }

        protected GDEnums.GDModes prevMod;
        public GDEnums.GDModes PreviousMode
        {
            get { return prevMod; }
            set { prevMod = value; }
        }
        protected GDEnums.GDModes currMod;
        public GDEnums.GDModes CurrentMode
        {
            get { return currMod; }
            set { currMod = value; }
        }

        public List<User> users = new List<User>();

        #endregion

        #region Class Methods
        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Game Manager is already in play. Deleting old, instantiating new!", gameObject);
                Destroy(GDBaseGameManager.Instance.gameObject);
                instance = null;
            }
            else
            { instance = this; }
        }

        protected virtual void UserInitializer()
        {
            User[] u = FindObjectsOfType(typeof(User)) as User[];
            if(u.Length > Enum.GetNames(typeof(GDEnums.COLORS)).Length)
            {
                throw new Exception("There exist more Users than what is permited within the Game, naming extra users as Numbers");
            }

            for (int i = 0; i < u.Length; ++i)
            {
                GDEnums.COLORS randomColor = (GDEnums.COLORS)Enum.ToObject(typeof(GDEnums.COLORS), i);
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

        #endregion

        #region Interface Methods
        public void Init(GDEnums.GDModes Mode)
        {
            currMod = Mode;

            if (Mode == GDEnums.GDModes.DEFAULT)
            { throw new Exception(gameObject.name + " is trying to Instantiate a GameMode that does not exist!"); }
            else if (Mode == GDEnums.GDModes.FUCK_THE_DEALER)
            {
                EventSystemManager.StartListening("FUCK_THE_DEALER", OnGameStartFD);
                EventSystemManager.TriggerEvent("FUCK_THE_DEALER");
                return;
            }
            else if (Mode == GDEnums.GDModes.GIVE_OR_TAKE)
            {
                EventSystemManager.StartListening("GIVE_OR_TAKE", OnGameStartGOT);
                EventSystemManager.TriggerEvent("GIVE_OR_TAKE");
                return;
            }
            else if (Mode == GDEnums.GDModes.KINGS_CUP)
            {
                EventSystemManager.StartListening("KINGS_CUP", OnGameStartKP);
                EventSystemManager.TriggerEvent("KINGS_CUP");
                return;
            }
            else if (Mode == GDEnums.GDModes.PIRAMID)
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

        void IMode<GDEnums.GDModes>.ChangeMode(GDEnums.GDModes Mode)
        {
            prevMod = currMod;
            if (CurrentMode == GDEnums.GDModes.FUCK_THE_DEALER)
            {
                EventSystemManager.StopListening("FUCK_THE_DEALER", OnGameStartFD);
            }
            else if (CurrentMode == GDEnums.GDModes.GIVE_OR_TAKE)
            {
                EventSystemManager.StopListening("GIVE_OR_TAKE", OnGameStartGOT);
            }
            else if (CurrentMode == GDEnums.GDModes.KINGS_CUP)
            {
                EventSystemManager.StopListening("KINGS_CUP", OnGameStartKP);
            }
            else if (CurrentMode == GDEnums.GDModes.PIRAMID)
            {
                EventSystemManager.StopListening("PIRAMID", OnGameStartP);
            }
            Init(Mode);
        }

        void IMode<GDEnums.GDModes>.PlayTurns()
        {
            throw new NotImplementedException();
        }

        void IMode<GDEnums.GDModes>.TimeTurns()
        {
            throw new NotImplementedException();
        }

        void IMode<GDEnums.GDModes>.TakeDrink(User user)
        {
            for(int i = 0; i < users.Count; i++)
            {
                if(users[i].Name == user.Name)
                {
                    users[i].DrinksToTake++;
                }
            }
        }

        void IMode<GDEnums.GDModes>.GiveDrink(User user)
        {
            throw new NotImplementedException();
        }

        void IMode<GDEnums.GDModes>.AlreadyDrank(User user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}