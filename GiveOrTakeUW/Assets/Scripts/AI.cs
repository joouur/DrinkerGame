using UnityEngine;
using System.Collections;

public class AI : Player {

    private bool bor = false;
    private bool hol = false;
    private bool pas = false;

    protected virtual void Start()
    {
        Name = name;
        AI = true;
        iD = name[2];
    }
	
	protected virtual void Update () 
    {
        if (Turn)
        {
            if (!bor)
            {
                StartCoroutine(BOR());
                Turn = false;
                ++GameMaster.Instance.NextCount;

                return;

            }
            else if (!hol)
            {
                StartCoroutine(HOL());
                Turn = false;
                ++GameMaster.Instance.NextCount;

                return;

            }
            else if (!pas)
            {
                StartCoroutine(PAS());
                Turn = false;
                ++GameMaster.Instance.NextCount;

                return;

            }
        }
    }

    protected virtual IEnumerator BOR()
    {
        int i = UnityEngine.Random.Range(0, 2);
        if (i == 1)
            BlackPick();
        else
            RedPick();
        yield return new WaitForSeconds(3.0f);
    }

    protected virtual IEnumerator HOL()
    {
        int i = UnityEngine.Random.Range(0, 2);
        if (i == 1)
            HighPick();
        else
            Lowick();
        yield return new WaitForSeconds(3.0f);
    }

    protected virtual IEnumerator PAS()
    {
        int i = UnityEngine.Random.Range(1, 5);
        switch(i)
        {
            case 1:
                SpadePick();
                break;
            case 2:
                ClubPick();
                break;
            case 3:
                DiamondPick();
                break;
            case 4:
                HeartPick();
                break;
            default:
                PAS();
                break;
        }
        yield return new WaitForSeconds(3.0f);
    }

    #region PickHelper
    public void BlackPick()
    {
        Debug.Log(name + " has Pick Black");

        BR = false;
        bor = true;
        BLACKORRED();

    }

    public void RedPick()
    {
        Debug.Log(name + " has Pick Red");

        BR = true;
        bor = true;
        BLACKORRED();

    }

    public void HighPick()
    {
        Debug.Log(name + " has Pick High");

        HL = true;
        hol = true;
        HIGHERORLOWER();

    }
    public void Lowick()
    {
        Debug.Log(name + " has Pick Low");

        HL = false;
        hol = true;
        HIGHERORLOWER();

    }
    public void SpadePick()
    {
        Debug.Log(name + " has Pick Spade");

        pickASuit = Suits.SPADES;
        pas = true;
        PICKASUIT();

    }
    public void ClubPick()
    {
        Debug.Log(name + " has Pick Club");

        pickASuit = Suits.CLUBS;
        pas = true;
        PICKASUIT();

    }
    public void DiamondPick()
    {
        Debug.Log(name + " has Pick Diamond");

        pickASuit = Suits.DIAMONDS;
        pas = true;
        PICKASUIT();

    }
    public void HeartPick()
    {
        Debug.Log(name + " has Pick Heart");

        pickASuit = Suits.HEARTS;
        pas = true;
        PICKASUIT();

    }
    #endregion
}
