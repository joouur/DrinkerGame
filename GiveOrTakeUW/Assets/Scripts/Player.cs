using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    [Space(10)]
    [Header("Data Information")]
    public string Name;
    public bool AI;
    [SerializeField]
    protected int iD;
    public bool Turn = false;

    [Space(10)]
    [Header("Game Information")]
    [SerializeField]
    private int take;
    public int Take
    { get { return take; } set { take = value; } }

    [SerializeField]
    private int give;
    public int Give
    { get { return give; } set { give = value; } }

    public List<Card> cards = new List<Card>();

    [HideInInspector]
    public bool BR;
    [HideInInspector]
    public bool HL;
    [HideInInspector]
    public Suits pickASuit;

    private GameObject[] prefabToSpawn;
    public int spawnNum = 0;
    protected Vector3 nextSpawnPos;


    protected virtual void BLACKORRED()
    {
        if ((cards[0].Suit == Suits.SPADES || cards[0].Suit == Suits.CLUBS)
            && BR == false)
        {
            give++;
        }
        else if ((cards[0].Suit == Suits.SPADES || cards[0].Suit == Suits.CLUBS)
            && BR == true)
        {
            take++;
        }
        else if ((cards[0].Suit == Suits.DIAMONDS || cards[0].Suit == Suits.HEARTS)
            && BR == true)
        {
            give++;
        }
        else
        {
            take++;
        }
        nextSpawnPos = transform.position;
        SpawnTheCard();
    }

    protected virtual void HIGHERORLOWER()
    {
        if (cards[0].Number > cards[1].Number && !HL)
        {
            give += 2;
        }
        else if (cards[0].Number > cards[1].Number && HL)
        {
            take += 2;
        }
        else if (cards[0].Number < cards[1].Number && HL)
        {
            give += 2;
        }
        else if (cards[0].Number < cards[1].Number && !HL)
        {
            take += 2;
        }
        else
        {
            take += 4;
        }
        nextSpawnPos.x += .2f;
        SpawnTheCard();
    }

    protected virtual void PICKASUIT()
    {
        if (cards[0].Suit != pickASuit)
            take += 4;
        else if (cards[0].Suit == pickASuit)
            give += 4;
        nextSpawnPos.x += .2f;
        SpawnTheCard();
    }

    public virtual void SpawnTheCard()
    {
        GameObject SpawnCard = (GameObject)Instantiate(cards[spawnNum].prefab);
        spawnNum++;
        SpawnCard.transform.parent = transform;
        SpawnCard.transform.position = nextSpawnPos;
        SpawnCard.transform.localEulerAngles = Vector3.right * 180;
        SpawnCard.transform.localScale *= 2.5f;

    }
}
