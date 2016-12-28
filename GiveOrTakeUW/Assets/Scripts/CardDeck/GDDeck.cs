using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GameDrinker.Tools;
using GameDrinker.Tools.ObjectPooler;

namespace GameDrinker.Decks 
{
    public class GDDeck : MonoBehaviour
    {

        public List<GDCard> DeckPile = new List<GDCard>();

        public CardPool pool;
        /// <summary>
        /// Deck Initializer
        /// Sets 13 Card on 4 Suits
        /// </summary>
        public void Init()
        {
            int id = 1;
            pool = GetComponentInChildren<CardPool>();

            foreach (SUITS j in Enum.GetValues(typeof(SUITS)))
            {
                for (int i = 1; i <= 13; ++i)
                {
                    GameObject obj = Resources.Load("Cards/" + j.ToString() + i) as GameObject;
                    GDCard newCard = new GDCard(i.ToString(), j, i);
                    if (obj != null)
                    {
                        pool.CardsToPool[(i * j.GetHashCode()) - 1] = obj;
                        newCard.prefab = obj;
                    }
                    newCard.ID = id;
                    newCard.CardColor = 0;
                    DeckPile.Add(newCard);
                    id++;
                }
            }

        }

        public void ResetDeck()
        {
            DeckPile = null;

            Init();
        }

        /// <summary>
        /// Return a new Card for user to use
        /// </summary>
        /// <param name="it">iteration for StackOverflow prevention</param>
        /// <returns></returns>
        public GDCard getNewCard(int it)
        {
            // Prevent Stack Overflow through Iteration
            it--;
            if (it < 0)
            {
                Debug.Log("No New Cards Available"); 
                return null;
            }

            // Get Random Num for a new Card
            int num = GDMath.RandomCard();
            
            // Check if no in use
            if (DeckPile[num].IsOnUse)
            { return getNewCard(it); }

            // Set Card to Use
            DeckPile[num].IsOnUse = true;
            GDCard newCard = DeckPile[num];
            Debug.Log("New Card " + num);

            // Return the card to user
            return newCard; 
        }


    }
}