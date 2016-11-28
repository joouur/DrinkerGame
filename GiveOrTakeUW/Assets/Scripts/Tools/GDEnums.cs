using UnityEngine;
using System.Collections;

namespace GameDrinker.Tools
{
    /// <summary>
    /// Public Enums For Game
    /// </summary>
    public enum STATUS
    {
        DEFAULT,
        SOBER,
        DRINKING,
        TIPSY,
        DRUNK,
        KO
    }

    public enum SUITS
    {
        CLUBS = 1,
        DIAMONDS = 2,
        HEARTS = 3,
        SPADES = 4
    }

    public enum COLORS
    {
        RED,
        BLUE,
        GREEN,
        YELLOW,
        ORANGE,
        PURPLE,
        PINK,
        BROWN,
        GRAY,
        WHITE,
        BLACK
    }

    public enum GDCARDCOLOR
    { BLACK, RED }

    public enum GDModes
    {
        DEFAULT,
        GIVE_OR_TAKE,
        KINGS_CUP,
        PIRAMID,
        FUCK_THE_DEALER,
    }

    public enum GDGIVEORTAKE
    {
        BLACK_RED,
        HIGHER_LOWER,
        BETWEEN_OUTSIDE,
        PICK_SUIT,
        GIVE,
        TAKE
    }

    
}