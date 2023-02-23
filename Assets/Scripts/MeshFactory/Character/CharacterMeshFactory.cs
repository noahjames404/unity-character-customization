using MeshFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMeshFactory 
{
    public void build(CharacterMeshTemplate reference, CharacterMeshTemplate target)
    {
        for(int i =0; i < reference.list.Count; i++)
        {
            lightCatcher(reference.list[i].Mesh, target.list[i].Mesh);   
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
            Debug.LogError("Error Handled: " + ex);    
        }
    }
}

