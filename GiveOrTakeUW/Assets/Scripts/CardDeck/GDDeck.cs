﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GameDrinker.Tools;

namespace GameDrinker.Decks 
{
    public abstract class GDDeck<T> : MonoBehaviour where T : Component
    {

        public List<GDCard> DeckPile = new List<GDCard>();
        public List<GDCard> DiscardPile = new List<GDCard>();

        /// <summary>
        /// Deck Initializer
        /// Sets 13 Card on 4 Suits
        /// </summary>
        protected virtual void Init()
        {
            foreach (GDEnums.SUITS j in Enum.GetValues(typeof(GDEnums.SUITS)))
            {
                for (int i = 1; i <= 13; ++i)
                {
                    GameObject obj = Resources.Load("Cards/" + j.ToString() + i) as GameObject;
                    GDCard newCard = new GDCard(i.ToString(), j);
                    newCard.prefab = obj;
                    DeckPile.Add(newCard);
                }
            }
        }

        protected virtual void Awake()
        {
            Init();
        }
    }


}