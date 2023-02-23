using MeshFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMeshFactory 
{
    public void Migrate(CharacterMeshTemplate reference, CharacterMeshTemplate target)
    {
        for(int i =0; i < reference.List.Count; i++)
        {
            lightCatcher(reference.List[i].Mesh, target.List[i].Mesh);   
        }
    }

    void lightCatcher(SkinnedMeshRenderer reference, SkinnedMeshRenderer target)
    {
        try
        {
            MeshBoneMigrator migrator = new MeshBoneMigrator();

            migrator.migrateMesh(reference, target);
        }
        catch(Exception ex)
        {
            Debug.LogError($"Error Handled - unable to migrate " + ex );    
        }
    }

    public CharacterMeshSet Build(GameObject target, CharacterMeshTemplate referenceTemplate)
    {
        CharacterMeshSet mesh = ScriptableObject.CreateInstance(typeof(CharacterMeshSet)) as CharacterMeshSet;
        mesh.characterPrefab = target;
        mesh.template = new CharacterMeshTemplate();
        mesh.ExtractMesh();

        Migrate(referenceTemplate, mesh.template);
        target.GetComponent<Animator>().Rebind();

        return mesh;
    }
}

