using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parts")]
public class PartsData : ScriptableObject
{
    public Mesh partMesh;
    public int selectedMaterial;
    public Material[] partMaterial;
}
