using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(GUIManager))]
public class GUIManagerEditor : Editor
{
    private ReorderableList list;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        list.DoLayoutList();

        serializedObject.ApplyModifiedProperties();

        if(GUILayout.Button("Generate Window Enums"))
        {
            var windows = ((GUIManager)target).windows;
            var total = windows.Length;

            var sb = new StringBuilder();

            sb.Append("public enum GDWindows{");
            sb.Append("None,");
            for(int i = 0; i < total; i++)
            {
                sb.Append(windows[i].name.Replace(" ", ""));
                if (i < total - 1)
                    sb.Append(",");
            }
            sb.Append("}");
            var path = EditorUtility.SaveFilePanel("Save the Window Enums", "", "WindowEnums.cs", "cs");
            using (FileStream fs = new FileStream(path, FileMode.Create)) 
            {
                using (StreamWriter writer = new StreamWriter(fs)){
                    writer.Write(sb.ToString());
                }
            }
        }
        AssetDatabase.Refresh();
    }

    private void OnEnable()
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("windows"), true, true, true, true);

        list.drawHeaderCallback = (Rect rect) => { EditorGUI.LabelField(rect, "Windows"); };

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, Screen.width - 75, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
        };


    }
}