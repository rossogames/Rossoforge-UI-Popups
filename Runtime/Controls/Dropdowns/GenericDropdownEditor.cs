#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Rossoforge.UI.Controls.Dropdowns
{
    [CustomEditor(typeof(GenericDropdown))]
    [CanEditMultipleObjects]
    public class GenericDropdownEditor : DropdownEditor
    {
        SerializedProperty textMemberProp;

        protected override void OnEnable()
        {
            base.OnEnable();
            textMemberProp = serializedObject.FindProperty("_textMember"); 
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(textMemberProp, new GUIContent("Text Member"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif