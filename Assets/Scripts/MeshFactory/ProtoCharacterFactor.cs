using MeshFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoCharacterFactor : MonoBehaviour
{
    public CharacterType characterType;
    public CharacterMeshSet reference;
    public GameObject target;
    public CharacterMeshTemplate template;
    // Start is called before the first frame update

    void Start()
    {
        CharacterMeshFactory factory = new CharacterMeshFactory();
        if (characterType != reference.characterType)
        {
            Debug.LogError($"Incompatible Character Type: using {reference.characterType} on a {characterType} builder");
            return;
        }
        template = factory.Build(target, reference).template;
    }
}
