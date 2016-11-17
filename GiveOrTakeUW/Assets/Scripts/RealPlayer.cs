using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RealPlayer : Player 
{

    static public RealPlayer Instance { get { return _instance; } }
    static protected RealPlayer _instance;

    [Space(10)]
    [Header("Canvas")]
    public Canvas BlackOrRead;
    public Canvas HighOrLow;
    public Canvas PickASuit;

    public bool bor = false;
    public bool hol = false;
    public bool pas = false;

    public void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Real Player is already in play. Deleting old, instantiating new!", gameObject);
            Destroy(RealPlayer.Instance.gameObject);
            _instance = null;
        }
        else
        { _instance = this; }

    }

    protected virtual void Start () 
    {
        Name = "Default";
        iD = 0;

        BlackOrRead.enabled = false;
        HighOrLow.enabled = false;
        PickASuit.enabled = false;
	}
	
	// Update is called once per frame
	protected virtual void Update () 
    {
        if (!Turn)
        { return; }

        if(!bor)
        {
            BlackOrRead.enabled = true;
            Turn = false;
            return;
        }

        else if(!hol)
        {
            HighOrLow.enabled = true;
            Turn = false;
            return;
        }

        else if (!pas)
        {

            PickASuit.enabled = true;
            Turn = false; 
            return;
        }
    }

    #region CanvasHelper
    public void BlackPick()
    {
        Debug.Log("Player Pick Black");

        BR = false;
        BlackOrRead.enabled = false;
        bor = true;
        ++GameMaster.Instance.NextCount;
        BLACKORRED();
    }

    public void RedPick()
    {
        Debug.Log("Player Pick Red");

        BR = true;
        BlackOrRead.enabled = false;
        bor = true;
        ++GameMaster.Instance.NextCount;
        BLACKORRED();

    }

    public void HighPick()
    {
        Debug.Log("Player Pick High");

        HL = true;
        HighOrLow.enabled = false;
        hol = true;
        ++GameMaster.Instance.NextCount;
        HIGHERORLOWER();
    }
    public void Lowick()
    {
        Debug.Log("Player Pick Low");

        HL = false;
        HighOrLow.enabled = false;
        hol = true;
        ++GameMaster.Instance.NextCount;
        HIGHERORLOWER();
    }
    public void SpadePick()
    {
        Debug.Log("Player Pick Spade");

        pickASuit = Suits.SPADES;
        PickASuit.enabled = false;
        pas = true;
        ++GameMaster.Instance.NextCount;
        PICKASUIT();
    }
    public void ClubPick()
    {
        Debug.Log("Player Pick Club");

        pickASuit = Suits.CLUBS;
        PickASuit.enabled = false;
        pas = true;
        ++GameMaster.Instance.NextCount;
        PICKASUIT();
    }
    public void DiamondPick()
    {
        Debug.Log("Player Pick Diamond");

        pickASuit = Suits.DIAMONDS;
        PickASuit.enabled = false;
        pas = true;
        ++GameMaster.Instance.NextCount;
        PICKASUIT();
    }
    public void HeartPick()
    {
        Debug.Log("Player Pick Heart");

        pickASuit = Suits.HEARTS;
        PickASuit.enabled = false;
        pas = true;
        ++GameMaster.Instance.NextCount;
        PICKASUIT();
    }
    #endregion
}
