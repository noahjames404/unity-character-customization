using System;
using System.Collections.Generic;
using UnityEngine;

namespace MeshFactory
{
    [System.Serializable]
    public class CharacterMeshBaseTemplate<T>
    {
        [SerializeField]
        protected T skin;
        [SerializeField]
        protected T eyes;
        [SerializeField]
        protected T topClothes;
        [SerializeField]
        protected T armor;
        [SerializeField]
        protected T hair;
        [SerializeField]
        protected T headGear;
        [SerializeField]
        protected T lowerClothes;
        [SerializeField]
        protected T boots;
        [SerializeField]
        protected T gauntlet;
        [SerializeField]
        protected T tasset;

        public T Skin { get => skin; }
        public T Eyes { get => eyes; }
        public T TopClothes { get => topClothes; }
        public T Armor { get => armor; }
        public T Hair { get => hair; }
        public T HeadGear { get => headGear; }
        public T LowerClothes { get => lowerClothes; }
        public T Boots { get => boots; }
        public T Gauntlet { get => gauntlet; }
        public T Tasset { get => tasset; }
        public List<T> List { get => list; set => list = value; }

        private List<T> list;

        public CharacterMeshBaseTemplate()
        {
            preInit();
            init();
        }

        public virtual void preInit() { }

        public void init()
        { 
            //List must be added in order to match the CharacterPartType index
            List = new List<T>();
            List.Add(skin);
            List.Add(eyes);
            List.Add(topClothes);
            List.Add(armor);
            List.Add(hair);
            List.Add(headGear);
            List.Add(lowerClothes);
            List.Add(boots);
            List.Add(gauntlet);
            List.Add(tasset);
        }
    }
}