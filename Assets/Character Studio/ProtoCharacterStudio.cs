using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshFactory;
using UnityEngine.UI;

public class ProtoCharacterStudio : MonoBehaviour
{
    public Camera camera;
    public Vector3 maleCamPos;
    public Vector3 femaleCamPos;

    public StudioSetup male;
    public StudioSetup female;

    public List<CharacterMeshCustomSet> collection;
    public List<Image> images;


    CharacterMeshSet meshSetCache = null;

    CharacterMeshFactory factory = new CharacterMeshFactory();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StudioCoroutine());
    }

    IEnumerator StudioCoroutine()
    {
        int i = 0;
        foreach (var set in collection)
        {
            meshSetCache = setupStudio(set, set.characterType == CharacterType.Male ? male : female);
            repositionCam(set.characterType);
            images[i].sprite = CaptureSystem.CaptureScreen(camera);
            factory.clearClonedMesh(meshSetCache.characterPrefab);
            yield return new WaitForFixedUpdate();
            i++;
        }
    }

    private CharacterMeshSet setupStudio(CharacterMeshCustomSet set, StudioSetup setup)
    {
        hideModels();
        setup.target.SetActive(true);
        return factory.Build(setup.target, set.getStandardizeTemplate(), meshSetCache);
    }

    void hideModels()
    {
        male.target.SetActive(false);
        female.target.SetActive(false);
    }

    [System.Serializable]
    public class StudioSetup
    {
        public Vector3 camPos;
        public GameObject target;
    }

    public void repositionCam(CharacterType characterType)
    {
        camera.transform.localPosition = CharacterType.Male == characterType ? maleCamPos : femaleCamPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
