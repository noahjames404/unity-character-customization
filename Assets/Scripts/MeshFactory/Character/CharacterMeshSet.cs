using Algorithms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    [CreateAssetMenu(menuName = "Factory/Character Mesh Set")]
    public class CharacterMeshSet : ScriptableObject
    {
        public GameObject characterPrefab;
        public CharacterType characterType;
        public CharacterMeshTemplate template;

        public void ExtractMesh()
        {
            CharacterMeshExtractor.Extract(ref template, characterPrefab);
        }
    }

    public enum CharacterType
    {
        Female,
        Male
    }
}