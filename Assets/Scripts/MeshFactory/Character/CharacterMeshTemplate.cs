using System;
using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    [System.Serializable]
    public class CharacterMeshTemplate
    {
        [SerializeField]
        private CharacterPart skin;
        [SerializeField]
        private CharacterPart eyes;
        [SerializeField]
        private CharacterPart topClothes;
        [SerializeField]
        private CharacterPart armor;
        [SerializeField]
        private CharacterPart hair;
        [SerializeField]
        private CharacterPart headGear;
        [SerializeField]
        private CharacterPart lowerClothes;
        [SerializeField]
        private CharacterPart boots;
        [SerializeField]
        private CharacterPart gauntlet;
        [SerializeField]
        private CharacterPart tasset;

        public readonly List<CharacterPart> list;

        public CharacterPart Skin { get => skin; }
        public CharacterPart Eyes { get => eyes; }
        public CharacterPart TopClothes { get => topClothes; }
        public CharacterPart Armor { get => armor; }
        public CharacterPart Hair { get => hair;  }
        public CharacterPart HeadGear { get => headGear; }
        public CharacterPart LowerClothes { get => lowerClothes; }
        public CharacterPart Boots { get => boots;}
        public CharacterPart Gauntlet { get => gauntlet; }
        public CharacterPart Tasset { get => tasset;  }

        public CharacterMeshTemplate()
        {
            skin = new CharacterPart(CharacterPartType.SKIN);
            eyes = new CharacterPart(CharacterPartType.EYES);
            topClothes = new CharacterPart(CharacterPartType.TOP_CLOTHES);
            armor = new CharacterPart(CharacterPartType.ARMOR);
            hair = new CharacterPart(CharacterPartType.HAIR);
            headGear = new CharacterPart(CharacterPartType.HEAD_GEAR);
            lowerClothes = new CharacterPart(CharacterPartType.LOWER_CLOTHES);
            gauntlet = new CharacterPart(CharacterPartType.GAUNTLET);
            boots = new CharacterPart(CharacterPartType.BOOTS);
            tasset = new CharacterPart(CharacterPartType.TASSET);

            list = new List<CharacterPart>();
            list.Add(skin);
            list.Add(eyes);
            list.Add(topClothes);
            list.Add(armor);
            list.Add(hair);
            list.Add(headGear);
            list.Add(lowerClothes);
            list.Add(gauntlet);
            list.Add(boots);
            list.Add(tasset); 
        } 
    }

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

    public enum CharacterPartType
    {
        SKIN = 0,
        EYES = 1,
        TOP_CLOTHES = 2,
        ARMOR = 3,
        HAIR = 4,
        HEAD_GEAR = 5,
        LOWER_CLOTHES = 6,
        BOOTS = 7,
        GAUNTLET = 8,
        TASSET = 9
    }
}