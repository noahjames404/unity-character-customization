using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    [CreateAssetMenu(menuName = "Factory/Character Custom Set")]
    public class CharacterMeshCustomSet : ScriptableObject
    {
        public CharacterType characterType;
        public CharacterMeshBaseTemplate<CharacterMeshSet> customTemplate;

        public CharacterMeshTemplate getStandardizeTemplate()
        {
            var temp = new CharacterMeshTemplate();

            if(customTemplate.List == null) customTemplate.init();

            Debug.Log($"Mesh Count: {temp.List.Count}");
            for (int i =0; i < temp.List.Count; i++)
            {
                if (customTemplate.List[i] == null || customTemplate.List[i].template.getPart((CharacterPartType)i) == null) continue;
                temp.List[i] = customTemplate.List[i].template.getPart((CharacterPartType)i);
            } 

            return temp;
        }
    }
}