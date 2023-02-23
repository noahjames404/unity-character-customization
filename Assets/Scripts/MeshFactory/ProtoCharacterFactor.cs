using MeshFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoCharacterFactor : MonoBehaviour
{
    public CharacterType characterType;
    public CharacterMeshSet reference;
    public CharacterMeshSet _target;
    public CharacterMeshTemplate target;
    public Animator targetAnimator;
    // Start is called before the first frame update
    void Start()
    {
        CharacterMeshFactory factory = new CharacterMeshFactory();
        factory.build(reference.template, target);
        targetAnimator.Rebind();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
