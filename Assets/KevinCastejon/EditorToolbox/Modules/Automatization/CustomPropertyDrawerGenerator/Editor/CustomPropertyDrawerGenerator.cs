using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;


namespace KevinCastejon.EditorToolbox
{
    public class CustomPropertyDrawerGenerator : Editor
    {
        [MenuItem("Assets/EditorTools/Generate Custom Property Drawer", true)]
        private static bool GenerateCustomDrawerValidation()
        {
            string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID());
            Type selectedType = AssetDatabase.GetMainAssetTypeAtPath(selectedPath);
            bool isScriptAsset = selectedType == typeof(MonoScript);
            return isScriptAsset;
        }

        [MenuItem("Assets/EditorTools/Generate Custom Property Drawer")]
        private static void GenerateCustomDrawer()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            path = path.Substring(6);
            path = path.Substring(0, path.LastIndexOf("/"));
            MonoScript script = (MonoScript)Selection.activeObject;
            Type scriptClass = script.GetClass();
            if (script.GetClass().IsSubclassOf(typeof(ScriptableObject)) || script.GetClass().IsSubclassOf(typeof(MonoBehaviour)))
            {
                Debug.LogError("CustomPropertyDrawerGenerator only works with plain C# class");
                return;
            }
            FieldInfo[] pis = scriptClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            List<string> propsNames = new List<string>();
            for (int i = 0; i < pis.Length; i++)
            {
                propsNames.Add(pis[i].Name);
            }
            if (!Directory.Exists(Application.dataPath + path + "/Editor"))
            {
                AssetDatabase.CreateFolder("Assets" + path, "Editor");
            }
            string copyPath = Application.dataPath + path + "/Editor/" + scriptClass.Name + "Editor.cs";
            if (!File.Exists(copyPath))
            {
                using (StreamWriter outfile =
                    new StreamWriter(copyPath))
                {
                    outfile.WriteLine($"using System.Collections;");
                    outfile.WriteLine($"using System.Collections.Generic;");
                    outfile.WriteLine($"using UnityEngine;");
                    outfile.WriteLine($"using UnityEditor;");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"[CustomPropertyDrawer(typeof({scriptClass.Name}))]");
                    outfile.WriteLine($"public class {scriptClass.Name}Drawer : PropertyDrawer");
                    outfile.WriteLine($"{{");
                    outfile.WriteLine($"    private float _fieldsCount = {propsNames.Count + 1}f;");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)");
                    outfile.WriteLine($"    {{");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"        return base.GetPropertyHeight(property, label) * _fieldsCount;");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    }}");
                    outfile.WriteLine($"    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)");
                    outfile.WriteLine($"    {{");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"        Rect rect = new Rect(position);");
                    outfile.WriteLine($"        rect.height /= _fieldsCount;");
                    foreach (string propName in propsNames)
                    {
                        outfile.WriteLine($"        SerializedProperty {propName} = property.FindPropertyRelative(\"{propName}\");");
                    }
                    outfile.WriteLine($"        EditorGUI.LabelField(rect, label);");
                    outfile.WriteLine($"        rect.y += rect.height;");
                    outfile.WriteLine($"        EditorGUI.indentLevel++;");
                    foreach (string propName in propsNames)
                    {
                        outfile.WriteLine($"        EditorGUI.PropertyField(rect, {propName});");
                        outfile.WriteLine($"        rect.y += rect.height;");
                    }
                    outfile.WriteLine($"        EditorGUI.indentLevel--;");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    }}");
                    outfile.WriteLine($"}}");
                }
                AssetDatabase.Refresh();
                Debug.Log("CustomDrawer file created at " + copyPath);
            }
            else
            {
                Debug.LogError("The file " + copyPath + " already exists!");
            }
        }
    }
}