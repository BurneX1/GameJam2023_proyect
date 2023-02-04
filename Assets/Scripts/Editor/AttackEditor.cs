using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Attack))]
public class AttackEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        Attack atk = (Attack)target;
        if (GUILayout.Button("Atack"))
        {
            atk.Atack();
     
        }
        if (GUILayout.Button("Stop"))
        {
            atk.StopAtack();
        }
        if (GUILayout.Button("SetUp"))
        {
            atk.SetUpAttack();
        }

    }

    
}
