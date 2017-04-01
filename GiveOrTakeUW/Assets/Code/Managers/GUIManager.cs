using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    static private GUIManager instance;
    static public GUIManager Instance
    { get { return instance; } }

    public GenericWindow[] windows;
    public int currentWindowID;
    public int defaultWindowID;

    public GDModes ModeToPlay;

    public Image Fader;
    public GenericWindow GetWindow(int value)
    {
        return windows[value];
    }

    private void ToggleVisability(int value)
    {
        var total = windows.Length;
        for (int i = 0; i < total; i++)
        {
            var window = windows[i];
            if (i == value)
            { window.Open(); }
            else if (window.gameObject.activeSelf)
            { window.Close(); }
        }
    }
    public GenericWindow Open(int value)
    {
        if (value < 0 || value >= windows.Length)
            return null;
        currentWindowID = value;

        ToggleVisability(currentWindowID);
        return GetWindow(currentWindowID);
    }

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("GUI Manager is already in play. Deleting old, instantiating new!", this.gameObject);
            Destroy(GUIManager.Instance.gameObject);
            instance = null;
        }
        else
        { instance = this; }
        foreach(GenericWindow w in windows)
        { w.Open(); w.Close(); }
        windows[0].Open();
    }

    #region FaderStuff
    public virtual void FaderOn(bool state, float duration)
    {
        if (Fader == null)
        {
            return;
        }
        Fader.gameObject.SetActive(true);
        if (state)
            StartCoroutine(GDFade.FadeImage(Fader, duration, new Color(0, 0, 0, 1f)));
        else
            StartCoroutine(GDFade.FadeImage(Fader, duration, new Color(0, 0, 0, 0f)));
    }

    public virtual void FaderTo(Color newColor, float duration)
    {
        if (Fader == null)
        {
            return;
        }
        Fader.gameObject.SetActive(true);
        StartCoroutine(GDFade.FadeImage(Fader, duration, newColor));
    }

    #endregion
}