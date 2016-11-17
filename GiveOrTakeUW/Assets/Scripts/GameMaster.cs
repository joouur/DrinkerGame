using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameMaster : MonoBehaviour {

    static public GameMaster Instance { get { return _instance; } }
    static protected GameMaster _instance;

    public Player[] Players;

    public void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("GameMaster is already in play. Deleting old, instantiating new!", gameObject);
            Destroy(GameMaster.Instance.gameObject);
            _instance = null;
        }
        else
        { _instance = this; }

    }

    // Use this for initialization
    protected virtual void Start () 
    {
        for(int i = 0; i < Players.Length; ++i)
        {
            Players[i] = Players[i].gameObject.GetComponent<Player>();
        }

        //RealPlayer.Instance.Turn = true;
        Debug.Log(Players.Length);

        Debug.Log(Players[0].name);
        Debug.Log(Players[1].name);
        Debug.Log(Players[2].name);
        Debug.Log(Players[3].name);
        Debug.Log(Players[4].name);

        foreach(Player a in Players)
        {
            for (int i = 0; i < 4; ++i)
                a.cards.Add(getRandomCard());
        }
    }

    [Range(0,4)]
    public int NextCount = 0;
    
	protected virtual void Update () 
    {
        //NextPlayer(NextCount);
        if (NextCount == Players.Length)
        {
            NextCount = 0;
            return;
        }
        Players[NextCount].Turn = true;
        
	}

    protected virtual void NextPlayer(int next)
    {
        if (next >= Players.Length)
            next = 0;
        Players[next].Turn = true;
        Debug.Log(Players[next].name);
    }

    private bool WaitForTurnToEnd(int p)
    {
        Debug.Log(p);
        return Players[p].Turn;
    }

    public Card getRandomCard()
    {
        int i = UnityEngine.Random.Range(0, 52);
        if(Deck.Instance.Cards[i].IsOnUse)
        {
            return getRandomCard();
        }
        else
        {
            Deck.Instance.Cards[i].IsOnUse = true;
            return Deck.Instance.Cards[i];
        }
    }
}
