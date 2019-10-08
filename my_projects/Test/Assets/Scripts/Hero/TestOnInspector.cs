using UnityEditor;
using UnityEngine;

// Creates a custom Label on the inspector for all the scripts named ScriptName
// Make sure you have a ScriptName script in your
// project, else this will not work.
[CustomEditor (typeof (Hero))]
public class TestOnInspector : Editor {
    private SerializedProperty health;
    private SerializedProperty maxHealth;
    private SerializedProperty withShield;
    private SerializedProperty shield;

    private void OnEnable () {
        health = serializedObject.FindProperty ("health");
        maxHealth = serializedObject.FindProperty ("maxHealth");
        withShield = serializedObject.FindProperty ("withShield");
        shield = serializedObject.FindProperty ("shield");
    }

    public override void OnInspectorGUI () {
        serializedObject.UpdateIfDirtyOrScript ();

        EditorGUILayout.IntSlider (health, 0, maxHealth.intValue, "Health");

        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField (maxHealth, new GUIContent ("Max Health"));
        EditorGUI.indentLevel--;

        EditorGUILayout.Space ();

        EditorGUILayout.PropertyField (withShield, new GUIContent ("With Shield"));

        if (withShield.boolValue) {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField (shield, new GUIContent ("Shield"));
            EditorGUI.indentLevel--;
        }

        serializedObject.ApplyModifiedProperties ();
    }
}
