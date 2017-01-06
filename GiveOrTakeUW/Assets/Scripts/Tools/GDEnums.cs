using UnityEngine;
using System.Collections;

namespace GameDrinker.Tools
{
    /// <summary>
    /// Public Enums For Game
    /// </summary>
    public enum USERSTATUS
    {
        DEFAULT,
        SOBER,
        DRINKING,
        TIPSY,
        DRUNK,
        KO
    }

    public enum GAMESTATUS
    {
        BEFOREGAMESTART,
        INPROGRESS,
        PAUSED,
        GAMEOVER, 
        TRANSITIONOFGAME
    }

    public enum SUITS
    {
        SPADES = 1,
        DIAMONDS = 2,
        HEARTS = 3,
        CLUBS = 4
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
        BLACK,
        CYAN
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