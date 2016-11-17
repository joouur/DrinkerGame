using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Deck : MonoBehaviour {

    [SerializeField]
    public List<Card> Cards = new List<Card>();

    static public Deck Instance { get { return _instance; } }
    static protected Deck _instance;
    public void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Deck is already in play. Deleting old, instantiating new!", gameObject);
            Destroy(Deck.Instance.gameObject);
            _instance = null;
        }
        else
        { _instance = this; }

        foreach (Card a in Cards)
        {
            if(!a.prefab)
            {
                throw new System.Exception("No Prefab found!");
            }
        }
    }

}
