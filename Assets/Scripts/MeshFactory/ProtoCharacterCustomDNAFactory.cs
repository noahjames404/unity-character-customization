using MeshFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoCharacterCustomDNAFactory : MonoBehaviour
{
    public CharacterType characterType;
    public CharacterMeshBaseTemplate<string> DNA;
    public List<CharacterMeshSet> sets;
    public GameObject target;
    public CharacterMeshTemplate template;
    // Start is called before the first frame update

    void Start()
    {
        CharacterMeshFactory factory = new CharacterMeshFactory();
        var reference = factory.BuildByAssetDNA(sets, characterType, DNA);
        var refTemp = reference.getStandardizeTemplate();
        foreach(var f in reference.customTemplate.List)
        {
            Debug.Log("==== " + f?.name);
        }
        template = factory.Build(target, reference.getStandardizeTemplate()).template;
    }
}
