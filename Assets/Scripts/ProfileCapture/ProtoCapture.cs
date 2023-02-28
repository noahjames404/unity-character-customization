using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoCapture : MonoBehaviour
{
    public Camera camera;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        CaptureSystem c = new CaptureSystem();
        image.sprite = CaptureSystem.CaptureScreen(camera);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
