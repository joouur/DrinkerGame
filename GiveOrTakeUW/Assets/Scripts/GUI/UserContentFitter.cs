using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using GameDrinker.Managers;

namespace GameDrinker.GentleUI
{
    public class UserContentFitter : MonoBehaviour
    {
        static private UserContentFitter instance;
        static public UserContentFitter Instance
        { get { return instance; } }

        public RectTransform Content;

        public List<RectTransform> Users = new List<RectTransform>();

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("User Content Fitter is already in play. Deleting old, instantiating new!", this.gameObject);
                Destroy(UserContentFitter.Instance.gameObject);
                instance = null;
            }
            if (!Content)
            {
                Debug.LogWarning("No Content Specified, will try to get content.");
                Content = GetComponent<RectTransform>();
            }

            GDManager.OnGameDrinkerStart += Init;
        }

        public void Init()
        {
            var childs = GetComponentsInChildren<User>();
            Users = null;
            Users = new List<RectTransform>();
            foreach (User c in childs)
            {
                Users.Add(c.gameObject.GetComponent<RectTransform>());
            }

            if (Users.Count > 0)
            {
                Users.Sort(delegate (RectTransform a, RectTransform b)
                {
                    return (a.GetComponent<User>().ID).CompareTo(b.GetComponent<User>().ID);
                });
            }

            for (int i = Users.Count; i > 0; i--)
            {
                Users[i - 1].SetSiblingIndex(i - 1);
            }
            float Height = 350 * Users.Count;
            Vector2 newSize = new Vector2(850, Height);
            gameObject.GetComponent<RectTransform>().sizeDelta = newSize;
        }

        
    }
}