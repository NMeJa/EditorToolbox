using UnityEngine;

namespace KevinCastejon.UnityTools
{
    public class ReadOnlyOnPrefabAttribute : PropertyAttribute
    {
        public readonly bool invert;

        /// Prevent a property from being edited on the inspector in PrefabMode
        /// </summary>
        /// <param name="invert">If set to true, it will invert the behaviour and make a property editable only in PrefabMode</param>
        public ReadOnlyOnPrefabAttribute(bool invert = false)
        {
            this.invert = invert;
        }
    }
}