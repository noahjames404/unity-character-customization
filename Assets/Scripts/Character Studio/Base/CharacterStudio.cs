using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MeshFactory
{
    public class CharacterStudio
    {
        public Camera camera;
        public StudioSetup male;
        public StudioSetup female;

        public List<CharacterMeshCustomSet> collection;

        CharacterMeshFactory factory = new CharacterMeshFactory();
        CharacterMeshSet meshCache = null;

        public CharacterStudio(Camera camera, StudioSetup male, StudioSetup female)
        {
            this.camera = camera;
            this.male = male;
            this.female = female;
        }

        public IEnumerator StudioCoroutine(List<CharacterMeshCustomSet> collection, Action<Sprite, int> pictureCallback)
        {
            int i = 0;
            foreach (var set in collection)
            {
                meshCache = setupStudio(set, set.characterType == CharacterType.Male ? male : female);
                repositionCam(set.characterType);
                pictureCallback?.Invoke(CaptureSystem.CaptureScreen(camera),i);
                factory.clearClonedMesh(meshCache.characterPrefab);
                yield return new WaitForFixedUpdate();
                i++;
            }
        }

        CharacterMeshSet setupStudio(CharacterMeshCustomSet set, StudioSetup setup)
        {
            hideModels();
            setup.target.SetActive(true);
            return factory.Build(setup.target, set.getStandardizeTemplate(), meshCache);
        }

        void hideModels()
        {
            male.target.SetActive(false);
            female.target.SetActive(false);
        }

        void repositionCam(CharacterType characterType)
        {
            camera.transform.localPosition = CharacterType.Male == characterType ? male.camPos : female.camPos;
        }
    }
}