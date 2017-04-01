using UnityEngine;
using System;


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
    HEARTS = 4,
    CLUBS = 8
}

[Flags]
public enum SUITSFLAGS
{
    SPADES = 1,
    DIAMONDS = 2,
    HEARTS = 4,
    CLUBS = 8
}

public enum COLORS
{
    RED,
    PINK,
    PURPLE,
    INDIGO,
    BLUE,
    CYAN,
    TEAL,
    GREEN,
    LIME,
    YELLOW,
    AMBER,
    ORANGE,
    BROWN,
    GREY,
    LIGHT_BLUE,
    LIGHT_GREEN,
    DEEP_ORANGE,
    DEEP_PURPLE,
    BLUE_GREY
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