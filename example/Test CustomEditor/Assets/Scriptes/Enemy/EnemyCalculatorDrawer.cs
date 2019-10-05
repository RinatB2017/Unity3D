#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(EnemyBehaviour), true)]
public class EnemyCalculatorDrawer : Editor 
{
    public override void OnInspectorGUI() {
        EnemyBehaviour enemy = (EnemyBehaviour)target;
        float dps1, dps20;

        dps1 = enemy.get_dps1();
        dps20 = enemy.get_dps20();

        // GUIStyle myStyle = new GUIStyle ();
        // myStyle.richText = true;
        // myStyle.padding.left = 50;
        // EditorGUILayout.LabelField("<b>Calculator</b>", myStyle);
        // EditorGUILayout.LabelField("DPS on level 1: " + dps1.ToString("0.00"), myStyle);
        // EditorGUILayout.LabelField("DPS on level 20: " + dps20.ToString("0.00"), myStyle);
        // EditorGUILayout.Separator();

        // base.OnInspectorGUI();
    }
}
#endif
