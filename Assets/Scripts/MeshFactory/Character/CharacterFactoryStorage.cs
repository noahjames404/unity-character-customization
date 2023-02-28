using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    [CreateAssetMenu(menuName = "Factory/Character Mesh Storage")]
    public class CharacterFactoryStorage : ScriptableObject
    {
        public List<CharacterMeshSet> storage;
    }
}