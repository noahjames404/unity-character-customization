using MeshFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoCharacterFactory : MonoBehaviour
{
    public CharacterType characterType;
    public CharacterMeshSet reference;
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
        template = factory.Build(target, reference.template).template;

        boneComparison = CharacterMeshDebugger.GetMeshBoneComparison(factory.GetTargetMeshSet(target).template, reference.template);
    }

}
