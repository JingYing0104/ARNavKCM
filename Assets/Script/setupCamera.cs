using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setupCamera : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImageBackground;

    [SerializeField]
    private AspectRatioFitter aspectRatioFitter;

    private bool isCamAvailable;
    private WebCamTexture CamTexture;

    void Start()
    {
        setup();
    }

    void Update()
    {
        UpdateCamRender();

    }


    private void setup()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            isCamAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing == false)
            {
                CamTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        CamTexture.Play();
        rawImageBackground.texture = CamTexture;
        isCamAvailable = true;


    }


    private void UpdateCamRender()
    {
        if (isCamAvailable == false)
        {
            return;
        }
        float ratio = (float)CamTexture.width / (float)CamTexture.height;
        aspectRatioFitter.aspectRatio = ratio;

        int orientation = -CamTexture.videoRotationAngle;
        rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);

    }

}
