using System;
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
            instance.gameObject.layer = target.gameObject.layer;
            instance.bones = MigrateBone(target,reference);
            instance.rootBone = target.rootBone;
            instance.ResetBounds();
        }

        private Transform[] MigrateBone(SkinnedMeshRenderer target, SkinnedMeshRenderer reference)
        {
            if (target.bones.Length < reference.bones.Length) 
                throw new Exception($"Bone Mismatch: the bone of base model is less than reference model! {target.name} {target.bones.Length} {reference.bones.Length}");

            Transform[] bones = new Transform[reference.bones.Length];
            for(int i = 0; i < reference.bones.Length; i++)
            {
                bones[i] = Array.Find(target.bones, e => e.name.Equals(reference.bones[i].name));
                if (bones[i] == null) 
                    throw new Exception($"Bone Mismatch: the bone of base model & reference model did not match! {target.name} {target.bones.Length} {reference.bones.Length}");
            }

            return bones;
        }

        public bool CheckBoneEquality(SkinnedMeshRenderer a, SkinnedMeshRenderer b)
        {
            Debug.Log($"comparison: {a.name} {a.bones.Length} - {b.name} {b.bones.Length}");
            return a.bones.Length == b.bones.Length;
        }
    }
}