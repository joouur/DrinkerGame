using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;

using UnityEngine;

[RequireComponent(typeof(GDDeck))]
public class GDManager : MonoBehaviour
{

    static private GDManager instance;
    static public GDManager Instance
    { get { return instance; } }

    #region Data

    public GAMESTATUS Status;

    public List<User> users = new List<User>();
    public ColorAsset.ColorTool ColorPicks;
    [SerializeField]
    private User currentUser;
    public User CurrentUser
    {
        get { return currentUser; }
    }

    public GDDeck CurrentDeck;
    #region UnityAction Events
    public delegate void OnGDStart();
    public static event OnGDStart OnGameDrinkerStart;
    #endregion

    #endregion

    #region Class Methods
    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Game Manager is already in play. Deleting old, instantiating new!", this.gameObject);
            Destroy(GDManager.Instance.gameObject);
            instance = null;
        }
        else
        { instance = this; }
        CurrentDeck = GetComponent<GDDeck>();
        CurrentDeck.Init();
        UserInitializer();
        currentUser = null;
        EventSystemManager.StartListening("OnGameStart", OnGameStart);
        //EventSystemManager.TriggerEvent("OnGameStart");

    }



    protected virtual void UserInitializer()
    {

        User[] u = FindObjectsOfType(typeof(User)) as User[];
        if (u.Length > Enum.GetNames(typeof(COLORS)).Length)
        {
            Debug.LogWarning("There exist more Users than what is permited within the Game, naming extra users as Numbers");
        }
        for (int i = 0; i < u.Length; ++i)
        {
            COLORS randomColor = (COLORS)Enum.ToObject(typeof(COLORS), i);
            u[i].name = u[i].Name = randomColor.ToString();
            u[i].ID = i;
            ChangeTheirColor(u[i]);
            u[i].Init();
            users.Add(u[i]);
        }
    }

    protected virtual void UserReset()
    {
        users = null;
    }

    protected virtual void UserDelete(User u)
    {
        users.Remove(u);
    }

    public void SetCurrentUser(User u)
    {
        if (u.Turn)
        {
            currentUser = u;
            ChangeTheirColor();
            return;
        }

        for (int i = 0; i < users.Count; ++i)
        {
            if (users[i].Turn)
            {
                currentUser = users[i];
                ChangeTheirColor();
                return;
            }
        }
    }

    private void ChangeTheirColor()
    {
        //Color c = GetColor("RED");
        string currName = currentUser.name.Replace(" ", "_");
        var col = ColorPicks.colorPicker.Where(c => c.Name == currName);
        var colo = col.Aggregate((i1, i2) => i1.ID > i2.ID ? i1 : i2);
        currentUser.T_Name.color = colo.TheColor;
    }
    private void ChangeTheirColor(User u)
    {
        string currName = u.name.Replace(" ", "_");
        var col = ColorPicks.colorPicker.Where(c => c.Name == currName);
        var colo = col.Aggregate((i1, i2) => i1.ID > i2.ID ? i1 : i2);
        u.T_Icon.color = colo.TheColor;
    }
    #endregion

    #region Events
    private void OnGameStart()
    {
        OnGameDrinkerStart();
        Status = GAMESTATUS.INPROGRESS;
    }
    #endregion
}