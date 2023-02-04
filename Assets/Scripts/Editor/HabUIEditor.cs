using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(AttackHabilityManager))]
public class HabUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        AttackHabilityManager atkmng = (AttackHabilityManager)target;
        if (GUILayout.Button("Rote"))
        {
            atkmng.Rote();

        }

    }
}
