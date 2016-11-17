using UnityEngine;
using System.Collections;

public enum Suits
{
    CLUBS,
    DIAMONDS,
    HEARTS,
    SPADES
}

[System.Serializable]
public class Card
{


    [SerializeField]
    private int number;
    public int Number
    {
        get { return number; }
        set { number = value; }
    }

    [SerializeField]
    private Suits suit;
    public Suits Suit
    {
        get { return suit; }
        set { suit = value; }
    }

    [SerializeField]
    private bool isOnUse;
    public bool IsOnUse
    {
        get { return isOnUse; }
        set { isOnUse = value; }
    }
    public GameObject prefab;
    Card()
    {
        number = 0;
        suit = Suits.SPADES;
    }

    Card(int n, Suits s)
    {
        number = n;
        suit = s;
    }
}
