using UnityEngine;

namespace KevinCastejon.UnityTools
{
    public class ReadOnlyOnPlayAttribute : PropertyAttribute
    {
        public readonly bool invert;

        /// <summary>
        /// Prevent a property from being edited on the inspector in PlayMode
        /// </summary>
        /// <param name="invert">If set to true, it will invert the behaviour and make a property editable only in PlayMode</param>
        public ReadOnlyOnPlayAttribute(bool invert = false)
        {
            this.invert = invert;
        }
    }
}