using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;

namespace KevinCastejon.UnityTools
{
    [CustomPropertyDrawer(typeof(LabelPlusAttribute))]
    public class LabelPlusDrawer : PropertyDrawer
    {
        // On affiche la propriété uniquement si l'on est pas en 'mode Prefab' (PrefabStageUtility.GetCurrentPrefabStage())
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LabelPlusAttribute labelPlus = attribute as LabelPlusAttribute;
            float originalWidth = position.width;
            position.width = position.height;
            GUI.DrawTexture(position, EditorGUIUtility.Load(labelPlus.iconPath) as Texture2D);
            position.width = originalWidth - position.height - 5;
            position.x += position.height + 5;

            Color previousColor = Color.white;
            if (!labelPlus.colorIsNull)
            {
                // On garde en memoire la couleur initiale du label
                previousColor = EditorStyles.label.normal.textColor;
                // On la passe en rouge
                EditorStyles.label.normal.textColor = labelPlus.color;
            }
            // On dessine la propriété
            EditorGUI.PropertyField(position, property, labelPlus.textIsNull ? label : new GUIContent(labelPlus.text));
            if (!labelPlus.colorIsNull)
            {
                // On rétablit la couleur de label originale
                EditorStyles.label.normal.textColor = previousColor;
            }
        }
    }
}