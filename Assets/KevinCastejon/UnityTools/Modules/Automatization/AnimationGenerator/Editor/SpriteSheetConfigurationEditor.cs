using UnityEditor;

namespace KevinCastejon.UnityTools
{
    [CustomEditor(typeof(SpriteSheetConfiguration))]
    public class SpriteSheetConfigurationEditor : Editor
    {
        private SpriteSheetConfiguration _config;

        private void OnEnable()
        {
            _config = target as SpriteSheetConfiguration;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _config.EnsureNotEmpty();
            _config.EnsureUniqueNames();
        }
    }
}