using UnityEngine;
using GameDrinker;

namespace GameDrinker.Tools
{
    public interface IMode<T>
    {
        uint DrinksToTake { get; set; }
        uint DrinksToGive { get; set; }

        GDModes PreviousMode { get; set; }
        GDModes CurrentMode { get; set; }

        void Init(T Mode);
        void ChangeMode(T Mode);

        void PlayTurns();
        void TimeTurns();
        void TakeDrink(User user);
        void GiveDrink(User user);
        void AlreadyDrank(User user);
    }

    public interface ICard
    {         
    }
    public class GDInterfaces : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}