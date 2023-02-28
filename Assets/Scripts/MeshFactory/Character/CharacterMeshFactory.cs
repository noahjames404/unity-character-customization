using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    public class CharacterMeshFactory
    {
        public CharacterMeshCustomSet BuildByAssetDNA(List<CharacterMeshSet> sets, CharacterType charType, CharacterMeshBaseTemplate<string> DNA)
        {
            DNA.init();
            CharacterMeshCustomSet meshSet = ScriptableObject.CreateInstance(typeof(CharacterMeshCustomSet)) as CharacterMeshCustomSet;
            meshSet.characterType = charType;
            meshSet.customTemplate = new CharacterMeshBaseTemplate<CharacterMeshSet>();

            for (int i =0; i < meshSet.customTemplate.List.Count; i++)
            {
                meshSet.customTemplate.List[i] = GetMeshSetByAssetID(sets,i,DNA.List[i]);
                Debug.Log($"ress  {(CharacterPartType)i} {meshSet.customTemplate.List[i]?.name}");
            }

            return meshSet;
        }

        public CharacterMeshSet GetMeshSetByAssetID(List<CharacterMeshSet> sets, int partIndex, string assetID)
        {
            Debug.Log($"Looking for: {partIndex} DNA {assetID}");
            return sets.Find(e => e.template.List[partIndex].AssetID.Equals(assetID)); 
        }

        public void Migrate(CharacterMeshTemplate reference, CharacterMeshTemplate target)
        {
            for (int i = 0; i < reference.List.Count; i++)
            {
                LightCatcher(reference.List[i].Mesh, target.List[i].Mesh);
            }
        }

        void LightCatcher(SkinnedMeshRenderer reference, SkinnedMeshRenderer target)
        {
            try
            {
                MeshBoneMigrator migrator = new MeshBoneMigrator();

                migrator.MigrateMesh(reference, target);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error Handled - unable to migrate " + ex);
            }
        }

        public CharacterMeshSet Build(GameObject target, CharacterMeshTemplate referenceTemplate, CharacterMeshSet meshSet = null)
        {
            var mesh = GetTargetMeshSet(target, meshSet);

            Migrate(referenceTemplate, mesh.template);
            target.GetComponent<Animator>().Rebind();

            return mesh;
        }

        public CharacterMeshSet GetTargetMeshSet(GameObject target, CharacterMeshSet meshSet = null)
        {
            CharacterMeshSet mesh = meshSet ?? ScriptableObject.CreateInstance(typeof(CharacterMeshSet)) as CharacterMeshSet;
            mesh.characterPrefab = target;
            mesh.template = new CharacterMeshTemplate();
            mesh.ExtractMesh();

            return mesh;
        }

        public void clearClonedMesh(GameObject prefab)
        {
            var meshes = prefab.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach(var mesh in meshes)
            {
                GameObject.Destroy(mesh.gameObject);
            }
        }
    }
}