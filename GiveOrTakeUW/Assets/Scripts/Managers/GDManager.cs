using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

using GameDrinker;
using GameDrinker.Decks;
using GameDrinker.Tools;
using GameDrinker.GentleUI;

namespace GameDrinker.Managers
{
    [RequireComponent(typeof(GDDeck))]
    public class GDManager : MonoBehaviour
    {

        static private GDManager instance;
        static public GDManager Instance
        { get { return instance; } }

        #region Data


        public List<User> users = new List<User>();
        public GDDeck CurrentDeck;

        public GAMESTATUS Status;
        #region UnityAction Events
        public delegate void OnGDStart();
        public static event OnGDStart OnGameDrinkerStart;
        #endregion
        #endregion

        #region Class Methods
        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Game Manager is already in play. Deleting old, instantiating new!", this.gameObject);
                Destroy(GDManager.Instance.gameObject);
                instance = null;
            }
            else
            { instance = this; }
            CurrentDeck = GetComponent<GDDeck>();
            CurrentDeck.Init();
            UserInitializer();

            EventSystemManager.StartListening("OnGameStart", OnGameStart);
        }

        private void OnGameStart()
        {
            OnGameDrinkerStart();
        }

        protected virtual void UserInitializer()
        {
            User[] u = FindObjectsOfType(typeof(User)) as User[];
            if (u.Length > Enum.GetNames(typeof(COLORS)).Length)
            {
                Debug.LogWarning("There exist more Users than what is permited within the Game, naming extra users as Numbers");
            }

            for (int i = 0; i < u.Length; ++i)
            {
                COLORS randomColor = (COLORS)Enum.ToObject(typeof(COLORS), i);
                u[i].name = u[i].Name = randomColor.ToString();
                u[i].ID = i;
                u[i].Init();
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

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                EventSystemManager.TriggerEvent("OnGameStart");
            }
        }
    }
}