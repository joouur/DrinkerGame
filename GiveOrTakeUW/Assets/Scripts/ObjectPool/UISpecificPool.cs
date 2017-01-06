using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDrinker.Tools.ObjectPooler
{
    [RequireComponent(typeof(User))]
    public class UISpecificPool : ObjectPool
    {
        public GameObject BlankCard;
        public int CardsPoolSize = 1;
        public bool CanExpandCards = true;
        protected GameObject ContentCards;

        protected List<GameObject> CardsPooled = new List<GameObject>();

        protected User user;

        protected override void Start()
        {
            base.Start();
            FillObjectPool();
        }
        protected override void FillObjectPool()
        {
            user = GetComponent<User>();
            BlankCard = Resources.Load("UI/CardUI") as GameObject;

            ContentCards = user.ContentCards;
            CardsPooled = new List<GameObject>();

            for (int i = 0; i < CardsPoolSize; i++)
            { AddCardToPool(); }
        }

        protected virtual GameObject AddCardToPool()
        {
            if (BlankCard == null)
            {
                Debug.LogWarning("NO " + BlankCard.name + " within the Component, no pool will be created!");
                return null;
            }
            GameObject newObj = (GameObject)Instantiate(BlankCard);
            newObj.gameObject.SetActive(false);
            //newObj.transform.parent = ContentCards.transform;
            newObj.transform.SetParent(ContentCards.transform);
            newObj.name = BlankCard.name + " - " + CardsPooled.Count;
            CardsPooled.Add(newObj);
            return newObj;
        }

        public override GameObject GetPooledGameObj()
        {
            // Look for inactives and return them
            for (int i = 0; i < CardsPooled.Count; i++)
            {
                if (!CardsPooled[i].gameObject.activeInHierarchy)
                { return CardsPooled[i]; }
            }
            // If there was no expand return null if there is add one more
            if (CanExpandCards)
            { return AddCardToPool(); }

            return null;
        }
    }
}