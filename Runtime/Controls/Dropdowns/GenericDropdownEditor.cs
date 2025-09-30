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
        SerializedProperty onItemSelectedProp;

        protected override void OnEnable()
        {
            base.OnEnable();
            textMemberProp = serializedObject.FindProperty("_textMember");
            onItemSelectedProp = serializedObject.FindProperty("_onItemSelected");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(textMemberProp, new GUIContent("Text Member"));
            EditorGUILayout.PropertyField(onItemSelectedProp, new GUIContent("On Item Selected"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif