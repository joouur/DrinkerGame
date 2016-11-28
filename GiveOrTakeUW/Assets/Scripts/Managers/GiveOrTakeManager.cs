using UnityEngine;
using System.Collections;
using GameDrinker;
using GameDrinker.Decks;
using GameDrinker.Tools;

namespace GameDrinker.Managers
{
    /// <summary>
    /// Give Or Take Game Manager.
    /// </summary>
    [RequireComponent(typeof(GDDeck))]
    public class GiveOrTakeManager : GDBaseModManager, IMode<GDModes>
    {

        public IMode<GDModes> Mode;

        protected virtual void Start()
        {
            UserInitializer();
            Mode = GetComponent<GiveOrTakeManager>();
            Mode.Init(GDModes.GIVE_OR_TAKE);
            //EventSystemManager.TriggerEvent("GIVE_OR_TAKE");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Mode.ChangeMode(GDModes.FUCK_THE_DEALER);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Mode.DrinksToGive = 2;
                Mode.TakeDrink(users[1]);
                Debug.Log(Mode.CurrentMode.ToString() + " " + Mode.DrinksToGive + " ");
            }
            
        }

    }
}