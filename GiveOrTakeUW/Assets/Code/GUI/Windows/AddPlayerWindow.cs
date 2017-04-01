using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddPlayerWindow : GenericWindow
{
    public Text playerNum;
    public GameObject Content;

    private int pNum;
    private int NumberOfPlayers
    {
        get { return pNum; }
        set
        {
            pNum = value;
            playerNum.text = pNum.ToString();
        }
    }

    public void Start()
    {
        Display(true);
    }

    public void AddPlayer()
    {
        if (pNum >= 12)
        { return; }
        else
        { NumberOfPlayers += 1; }
    }

    public void SubPlayer()
    {
        if (pNum == 0)
        { return; }
        else
        { NumberOfPlayers -= 1; }
    }

    public override void OnNextWindow()
    {
        //Load Scene
        //Pass Amount of Players
        var gp = Resources.Load("UI/User") as GameObject;

        for (int i = 0; i < pNum; i++)
        {
            var go = (GameObject)Instantiate(gp);
            go.transform.SetParent(Content.transform);
        }
        base.OnNextWindow();
    }
}