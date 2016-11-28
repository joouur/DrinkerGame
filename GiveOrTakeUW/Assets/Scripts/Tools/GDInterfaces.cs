using UnityEngine;
using System.Collections;

namespace GameDrinker.Tools
{
    public interface IMode<T>
    {
        void Init(T Mode);
        void PlayTurns();
        void TimeTurns();
        void Drink();
        void GiveDrink();
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