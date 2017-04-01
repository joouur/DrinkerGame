using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GDGamePlay))]
public class GameplayEditor : Editor 
{

    public override void OnInspectorGUI()
    {
        var script = target as GDGamePlay;

        EditorGUILayout.LabelField(script.GameMode.ToString(), script.Game.CurrentRound.ToString());
        
        DrawDefaultInspector();
    }
}
