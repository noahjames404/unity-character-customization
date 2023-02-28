namespace MeshFactory
{
    [System.Serializable]
    public class MeshBoneCountRow
    {
        public CharacterPartType partType;
        public int baseCount;
        public int referenceCount;

        public MeshBoneCountRow(CharacterPartType partType, int baseCount, int referenceCount)
        {
            this.partType = partType;
            this.baseCount = baseCount;
            this.referenceCount = referenceCount;
        }
    }
}