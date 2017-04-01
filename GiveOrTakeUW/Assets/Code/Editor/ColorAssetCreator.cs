using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ColorAsset
{
    public static class ColorAssetCreator
    {
        [MenuItem("Assets/Create/ColorPickerTool")]
        public static void CreateAsset()
        {
            ColorTool Asset = ScriptableObject.CreateInstance<ColorTool>();

            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            }
            else if(Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(ColorTool).ToString() + ".asset");

            AssetDatabase.CreateAsset(Asset, assetPathAndName);

            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = Asset;
        }
    }
}