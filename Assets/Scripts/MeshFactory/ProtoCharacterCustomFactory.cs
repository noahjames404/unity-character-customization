using MeshFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoCharacterCustomFactory : MonoBehaviour
{
    public CharacterType characterType;
    public CharacterMeshCustomSet reference;
    public GameObject target;
    public CharacterMeshTemplate template;
    public List<MeshBoneCountRow> boneComparison;

    // Start is called before the first frame update

    void Start()
    {
        CharacterMeshFactory factory = new CharacterMeshFactory();
        if (characterType != reference.characterType)
        {
            Debug.LogError($"Incompatible Character Type: using {reference.characterType} on a {characterType} builder");
            return;
        }
        var referenceMesh = reference.getStandardizeTemplate();
        template = factory.Build(target, referenceMesh).template;

        boneComparison = CharacterMeshDebugger.GetMeshBoneComparison(factory.GetTargetMeshSet(target).template, referenceMesh);
    }

    
}

public class CharacterMeshDebugger
{
    public static List<MeshBoneCountRow> GetMeshBoneComparison(CharacterMeshTemplate a, CharacterMeshTemplate b)
    {
        var list = new List<MeshBoneCountRow>();
        Debug.Log($"counter {a.List.Count} {b.List.Count}");
        for (int i =0; i < a.List.Count; i++)
        {
            int al = 0;
            int bl = 0;

            if (a.List[i] != null && a.List[i].Mesh != null) al = a.List[i].Mesh.bones.Length;
            if (b.List[i] != null && b.List[i].Mesh != null) bl = b.List[i].Mesh.bones.Length;

            list.Add(new MeshBoneCountRow(
                (CharacterPartType)i,
                al,bl
            ));
        }
        Debug.Log("counterr" + list.Count);
        return list;
    }
}
