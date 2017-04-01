using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GDDeck : MonoBehaviour
{

    public List<GDCard> DeckPile = new List<GDCard>();

    public CardPool pool;
    public CardSpawner spawn;

    /// <summary>
    /// Deck Initializer
    /// Sets 13 Card on 4 Suits
    /// </summary>
    public void Init()
    {
        int id = 1;
        pool = GetComponentInChildren<CardPool>();
        spawn = GetComponentInChildren<CardSpawner>();

        Sprite[] sprites = Resources.LoadAll<Sprite>("Textures/card_list");

        foreach (SUITS j in Enum.GetValues(typeof(SUITS)))
        {
            for (int i = 1; i <= 13; ++i)
            {
                GameObject obj = Resources.Load("Cards/" + j.ToString() + i) as GameObject;
                GDCard newCard = new GDCard(i.ToString(), j, i);
                if (obj != null)
                {
                    pool.CardsToPool[id - 1] = obj;
                    newCard.prefab = obj;
                }
                newCard.FrontSprite = sprites[id - 1];
                newCard.ID = id;
                newCard.CardColor = 0;
                DeckPile.Add(newCard);
                id++;
            }
        }
        pool.FillPool();

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
        spawn.CheckSpawn(newCard.Suit.ToString() + newCard.Power.ToString());
        // Return the card to user
        return newCard;
    }


}