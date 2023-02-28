using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    public class MeshBoneMigrator : MonoBehaviour
    {
        public void MigrateMesh(SkinnedMeshRenderer reference, SkinnedMeshRenderer target)
        {
            SkinnedMeshRenderer instance = Instantiate(reference, target.rootBone);
            instance.gameObject.SetActive(true);

            if (!CheckBoneEquality(reference, target))
            {
                Debug.LogError($"Unable to properly view mesh - invalid bone count between {instance.name}, {instance.bones.Length} & {target.name}, {target.bones.Length} ");
            }

            instance.gameObject.layer = target.gameObject.layer;
            instance.bones = target.bones;
            instance.rootBone = target.rootBone;
            instance.ResetBounds();
        }

        public bool CheckBoneEquality(SkinnedMeshRenderer a, SkinnedMeshRenderer b)
        {
            Debug.Log($"comparison: {a.name} {a.bones.Length} - {b.name} {b.bones.Length}");
            return a.bones.Length == b.bones.Length;
        }
    }
}