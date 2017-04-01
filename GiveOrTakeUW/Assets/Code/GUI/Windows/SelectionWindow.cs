using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionWindow : GenericWindow
{

    public void SelectGiveOrTake()
    {
        OnNextWindow();
        GUIManager.Instance.ModeToPlay = GDModes.GIVE_OR_TAKE;
    }

    public void SelectKingsCup()
    {
        OnNextWindow();
        GUIManager.Instance.ModeToPlay = GDModes.KINGS_CUP;
    }

    public void SelectFTheDealer()
    {
        OnNextWindow();
        GUIManager.Instance.ModeToPlay = GDModes.FUCK_THE_DEALER;
    }

    public void SelectPiramid()
    {
        OnNextWindow();
        GUIManager.Instance.ModeToPlay = GDModes.PIRAMID;
    }
}