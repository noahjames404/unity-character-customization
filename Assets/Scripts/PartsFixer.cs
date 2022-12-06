using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsFixer : MonoBehaviour
{
    [SerializeField] CharacterBody body;
    [SerializeField] PartsMapper Parts;
    public void Start()
    {
        UpdatePart();
    }

    public void UpdatePart() {
        mapParts(ref Parts.Armor, body.Armor.GetCurrentPart());
        mapParts(ref Parts.Body, body.Body.GetCurrentPart());
        mapParts(ref Parts.Boot, body.Boot.GetCurrentPart());
        mapParts(ref Parts.Eyes, body.Eyes.GetCurrentPart());
        mapParts(ref Parts.Gloves, body.Gloves.GetCurrentPart());
        mapParts(ref Parts.Hair, body.Hair.GetCurrentPart());
        mapParts(ref Parts.Top, body.Top.GetCurrentPart());
        mapParts(ref Parts.Bottom, body.Bottom.GetCurrentPart());
        mapParts(ref Parts.Accessory, body.Accessory.GetCurrentPart());
    }

    private void mapParts(ref SkinnedMeshRenderer target,PartsData data)
    {
        if (data != null && target != null)
        {
            target.sharedMesh = data.partMesh;
            target.material = data.partMaterial[data.selectedMaterial];
        }
    }


    enum partType
    {
        Armor, Body, Boot, Eyes, Gloves, Hair, Top, Bottom, Accessory
    }
}

