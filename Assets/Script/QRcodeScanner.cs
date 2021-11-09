using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QRcodeScanner : MonoBehaviour
{ 
    [SerializeField]
    private RawImage rawImageBackground;

    [SerializeField]
    private AspectRatioFitter aspectRatioFitter;

    [SerializeField]
    private TextMeshProUGUI textout;

    [SerializeField]
    private TextMeshProUGUI level;

    [SerializeField]
    private GameObject youarehere;

    [SerializeField]
    private GameObject wrongplace;

    [SerializeField]
    private RectTransform scanzone;

    private bool isCamAvailable;
    private WebCamTexture CamTexture;

    [SerializeField]
    private GameObject GoBtn;

    [SerializeField]
    private GameObject scanBtn;

    [SerializeField]
    private GameObject ScanAgainBtn;



    private void Awake()
    {
        textout.SetText("");
        GoBtn.SetActive(false);
        scanBtn.SetActive(true);
        youarehere.SetActive(false);
        wrongplace.SetActive(false);
        ScanAgainBtn.SetActive(false);
    }

    void Start()
    {
        setupCamera();
    }

    void Update()
    {
        UpdateCamRender();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("NavMain");
         }
}


    private void setupCamera()
        {
            WebCamDevice[] devices = WebCamTexture.devices;

            if(devices.Length == 0)
            {
                isCamAvailable = false;
                return;
            }

            for(int i =0; i<devices.Length; i++)
            {
                if(devices[i].isFrontFacing == false)
                {
                    CamTexture = new WebCamTexture(devices[i].name, (int)scanzone.rect.width, (int)scanzone.rect.height);
                }
            }

            CamTexture.Play();
            rawImageBackground.texture = CamTexture;
            isCamAvailable = true;
        

        }


        private void UpdateCamRender()
        {
            if(isCamAvailable == false)
        {
            return;
        }
            float ratio = (float)CamTexture.width / (float)CamTexture.height;
            aspectRatioFitter.aspectRatio = ratio;

            int orientation = -CamTexture.videoRotationAngle;
            rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
       
        }

        public void OnClickScan()
        {
            AudioManager.instance.AudioClick();
            Scan();
        }

    public void OnClickScanAgain()
    {
        AudioManager.instance.AudioClick();
        ScanAgainBtn.SetActive(false);
        wrongplace.SetActive(false);
        scanBtn.SetActive(true);
        textout.text = "";
       
    }


    private void Scan()
        {
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode(CamTexture.GetPixels32(), CamTexture.width, CamTexture.height);
                if(result != null)
                {
                    if(result.Text.Substring(0,7).Equals(level.text))
                    {
                        textout.text = result.Text;
                        youarehere.SetActive(true);
                        scanBtn.SetActive(false);
                        GoBtn.SetActive(true);
                        PlayerPrefs.SetString("QRResult", result.Text);
                    }
                    else
                     {
                        wrongplace.SetActive(true);
                        ScanAgainBtn.SetActive(true);
                        textout.text = " Please go to the level that you selected.";
                        
                     }

                }
                else
                {
                    textout.text = "FAILED TO READ QRCODE";
                }
            }
            catch
            {
                textout.text = "FAILED IN TRY";
            }
        }
}
    

