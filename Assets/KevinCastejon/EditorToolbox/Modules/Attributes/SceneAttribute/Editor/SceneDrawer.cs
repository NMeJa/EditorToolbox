using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace KevinCastejon.EditorToolbox
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class SceneDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogWarning("TagField attribute must be used with 'string' property type");
                base.OnGUI(position, property, label);
                return;
            }
            List<string> scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes).Select(x => ExtractSceneName(x.path)).ToList();
            if (property.stringValue == "")
            {
                property.stringValue = scenes[0];
            }
            property.stringValue = scenes[EditorGUI.Popup(position, label, scenes.IndexOf(property.stringValue), scenes.Select(x=>new GUIContent(x)).ToArray())];
        }

        private string ExtractSceneName(string scenePath)
        {
            int indexOfLastSlash = scenePath.LastIndexOf("/") + 1;
            int indexOfExtension = scenePath.LastIndexOf(".unity") - indexOfLastSlash;
            return(scenePath.Substring(indexOfLastSlash, indexOfExtension));
        }
    }
}