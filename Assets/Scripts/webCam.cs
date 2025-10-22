using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCam : MonoBehaviour

{
    WebCamTexture cameraa;
    public RawImage img;

    // Start is called before the first frame update
    void Start()
    {
        cameraa = new WebCamTexture();
        img.texture = cameraa;
        cameraa.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
