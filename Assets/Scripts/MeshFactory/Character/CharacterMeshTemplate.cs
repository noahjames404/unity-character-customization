using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    [System.Serializable]
    public class CharacterMeshTemplate : CharacterMeshBaseTemplate<CharacterPart>
    {
        public override void preInit()
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
        }

        public CharacterPart getPart(CharacterPartType type)
        {
            return List.Find(e => e.PartType == type);
        }
    }
}