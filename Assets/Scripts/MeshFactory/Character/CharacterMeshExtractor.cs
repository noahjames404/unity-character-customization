using Algorithms;
using System;
using UnityEngine;

namespace MeshFactory
{
    public class CharacterMeshExtractor
    {
        static StringAlts skin = new StringAlts("body", "skin");
        static StringAlts eyes = new StringAlts("eyes");
        static StringAlts topClothes = new StringAlts("topClothes", "upper clothes", "shirt");
        static StringAlts armor = new StringAlts("armor");
        static StringAlts hair = new StringAlts("hair", "hair_");
        static StringAlts headGear = new StringAlts("headGear");
        static StringAlts lowerClothes = new StringAlts("lowerClothes", "skirt","pants","short");
        static StringAlts gauntlet = new StringAlts("gauntlet", "gloves", "bracers");
        static StringAlts tasset = new StringAlts("tasset");
        static StringAlts boots = new StringAlts("boots");


        public static CharacterMeshTemplate Extract(ref CharacterMeshTemplate template, GameObject characterPrefab)
        {
            SkinnedMeshRenderer[] mesh = characterPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(true);

            template.Skin.Mesh = GetClosesCandidate(mesh, skin);
            template.Eyes.Mesh = GetClosesCandidate(mesh, eyes);
            template.TopClothes.Mesh = GetClosesCandidate(mesh, topClothes);
            template.Armor.Mesh = GetClosesCandidate(mesh, armor);
            template.Hair.Mesh = GetClosesCandidate(mesh, hair);
            template.HeadGear.Mesh = GetClosesCandidate(mesh, headGear);
            template.LowerClothes.Mesh = GetClosesCandidate(mesh, lowerClothes);
            template.Gauntlet.Mesh = GetClosesCandidate(mesh, gauntlet);
            template.Tasset.Mesh = GetClosesCandidate(mesh, tasset);
            template.Boots.Mesh = GetClosesCandidate(mesh, boots);

            template.List.ForEach(e => validateBones(e.Mesh,characterPrefab));

            return template;
        }

        public static void validateBones(SkinnedMeshRenderer mesh, GameObject owner)
        {
            if (mesh == null) return;
            if (mesh.bones.Length != 75)
            {
                Debug.LogError($"invalid count {owner.name} {mesh.name} {mesh.bones.Length}");
            }
        }

        public static SkinnedMeshRenderer GetClosesCandidate(SkinnedMeshRenderer[] mesh, StringAlts str, int tolerance = 2)
        {
            int candidate_index = -1;
            int candidate_points = -1;

            foreach (var s in str.alts)
            {
                for (int i = 0; i < mesh.Length; i++)
                {
                    int distance = LevenshteinDistance.Calculate(s, mesh[i].name);
                    //Debug.Log($"comparing {s} {mesh[i].name} - {distance}");
                    //Debug.Log($"comparison {distance} {distance < tolerance} {distance < candidate_points} {distance == -1}");
                    if (distance < tolerance && (distance < candidate_points || candidate_points == -1))
                    {
                        candidate_index = i;
                        candidate_points = distance;

                    }
                    if (candidate_points == 0) return mesh[candidate_index];
                }
            }
            //if (candidate_index != -1) Debug.Log($"candidate {mesh[candidate_index].name} {candidate_points}");
            return candidate_index == -1 ? null : mesh[candidate_index];
        }
    }
}