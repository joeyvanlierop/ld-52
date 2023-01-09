#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CropManager))]
public class CropEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var cropManager = (CropManager)target;
        if (GUILayout.Button("Execute Turn")) cropManager.OnTurn();
    }
}
#endif
