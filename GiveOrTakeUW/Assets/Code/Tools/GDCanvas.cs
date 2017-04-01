using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GDCanvas
{
    public static IEnumerator TimedPanelSet(RectTransform Panel, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Panel.gameObject.SetActive(false);
    }

}