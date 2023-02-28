using System;
using UnityEngine;

namespace MeshFactory
{
    [Serializable]
    public class CharacterPart
    {
        [SerializeField]
        private string assetID;
        [SerializeField]
        private readonly CharacterPartType partType;
        [SerializeField]
        private string name;
        [SerializeField]
        private string description;
        [SerializeField]
        private SkinnedMeshRenderer mesh;

        public string AssetID { get => assetID;}
        public CharacterPartType PartType => partType;
        public string Name { get => name; }
        public string Description { get => description; }
        public SkinnedMeshRenderer Mesh { get => mesh; set => mesh = value; }

        public CharacterPart(CharacterPartType partType)
        {
            this.partType = partType;
        }
    } 
}