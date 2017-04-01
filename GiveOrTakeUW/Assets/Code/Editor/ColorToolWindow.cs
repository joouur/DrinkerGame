using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ColorAsset
{
    public class ColorToolWindow : EditorWindow
    {

        private ColorTool tool;
        [MenuItem("Window/Colors Asset")]
        static void Init()
        {
            var window = (ColorToolWindow)GetWindow(typeof(ColorToolWindow));

            var content = new GUIContent();
            content.text = "Color Tool";
            window.titleContent = content;
        }

        private void OnFocus()
        {
           
        }

        private void OnLostFocus()
        {

        }

        private void OnGUI()
        {
            if(tool != null)
            {
                EditorGUILayout.BeginVertical();
                EditorGUILayout.LabelField("Current Tools");
                EditorGUILayout.LabelField(tool.name);
                //SerializedProperty colorPickerProperty = tool.colorPicker;
                //EditorGUILayout.PropertyField(colorPickerProperty, true);
                EditorGUILayout.EndVertical();
            }
            else
            {
                EditorGUILayout.LabelField("Add the Color tool: ");
            }
            DropAreaGUI();
        }

        private void DropAreaGUI()
        {
            var e = Event.current.type;

            if(e == EventType.DragUpdated)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            }
            else if( e == EventType.DragPerform)
            {
                DragAndDrop.AcceptDrag();
                foreach(Object d in DragAndDrop.objectReferences)
                {
                    if(d is ColorTool)
                    {
                        tool = d as ColorTool;
                    }
                }
            }
        }
    }
}