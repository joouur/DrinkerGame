using UnityEngine;
using System;
using System.Collections;
using GameDrinker;
using GameDrinker.Tools;

namespace GameDrinker.Managers
{
    public class GDBaseGameManager : MonoBehaviour
    {
        static private GDBaseGameManager instance;
        static public GDBaseGameManager Instance
        { get { return instance; } }

        public User[] users;

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

            }
            users = u;
        }

        protected virtual void UserReset()
        {
            users = null;
        }
    }
}