using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    public class Charactercustomization : MonoBehaviour
    {
        public SkinnedMeshRenderer prefab;
        public SkinnedMeshRenderer original;
        public Transform rootBone;

        // Start is called before the first frame update
        void Start()
        {
            //SkinnedMeshRenderer instance = Instantiate(prefab, transform);

            //instance.rootBone = rootBone;
            SkinnedMeshRenderer instance = Instantiate(prefab, transform);
            instance.gameObject.SetActive(true);
            //instance.sharedMesh = original.sharedMesh;
            Debug.Log($"{prefab.name} {instance.bones.Length} {original.bones.Length}");
            instance.bones = original.bones;
            instance.rootBone = original.rootBone;
            instance.ResetBounds();

        }

        Transform[] BuildBonesArray(Transform rootBone)
        {
            List<Transform> boneList = new List<Transform>();
            ExtractBonesRecursively(rootBone, ref boneList);
            return boneList.ToArray();
        }

        void ExtractBonesRecursively(Transform bone, ref List<Transform> boneList)
        {
            boneList.Add(bone);

            for (int i = 0; i < bone.childCount; i++)
            {
                var child = bone.GetChild(i);
                if (child.gameObject.activeInHierarchy)
                {
                    ExtractBonesRecursively(child, ref boneList);
                }
            }
        }


        Transform findTransform(Transform[] bones, Transform transform)
        {
            foreach (Transform bone in bones)
            {
                if (bone.name.Equals(transform.name))
                {
                    return bone;
                }
            }
            return null;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}