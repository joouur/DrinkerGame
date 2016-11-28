using UnityEngine;
using System.Collections;
using GameDrinker.Managers;
using GameDrinker.Tools;
using GameDrinker;

public class GiveOrTakeManager : GDBaseGameManager, IMode<GDEnums.GDModes> 
{

    public IMode<GDEnums.GDModes> Mode;

    // Use this for initialization
    void Start () {
        UserInitializer();
            Mode = GetComponent<GiveOrTakeManager>();
        Mode.Init(GDEnums.GDModes.GIVE_OR_TAKE);
        //EventSystemManager.TriggerEvent("GIVE_OR_TAKE");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            Mode.ChangeMode(GDEnums.GDModes.FUCK_THE_DEALER);
        if (Input.GetKeyDown(KeyCode.E))
       { 
            Mode.DrinksToGive = 2;
            Mode.TakeDrink(users[1]);
            Debug.Log(Mode.CurrentMode.ToString() + " " + Mode.DrinksToGive + " ");
        }
    }

}
