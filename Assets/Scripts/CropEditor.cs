using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CropManager))]
public class CropEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CropManager cropManager = (CropManager)target;
        if (GUILayout.Button("Execute Turn"))
        {
            cropManager.OnTurn();
        }
    }
}
