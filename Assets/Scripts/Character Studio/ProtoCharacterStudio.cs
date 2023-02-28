using System.Collections.Generic;
using UnityEngine;
using MeshFactory;
using UnityEngine.UI;

public partial class ProtoCharacterStudio : MonoBehaviour
{
    public Camera camera; 
    public StudioSetup male;
    public StudioSetup female;

    public List<CharacterMeshCustomSet> collection;
    public List<Image> images; 
    CharacterStudio studio;

    private void Start()
    {
        studio = new CharacterStudio(camera,male,female);
        StartCoroutine(studio.StudioCoroutine(collection, (sprite, i) => {
            images[i].sprite = sprite;
        }));
    }
}
