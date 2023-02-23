using MeshFactory;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterMeshSet))]
internal class CustomButtonEditor : Editor
{
    public CustomButtonEditor()
    {
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var script = target as CharacterMeshSet;
        if (GUILayout.Button("Extract"))
        {
            script.ExtractMesh();
        }
    }
}