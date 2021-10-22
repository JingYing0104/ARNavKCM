using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public void level1()
    {
        SceneManager.UnloadSceneAsync("NavMain");
        SceneManager.LoadScene("ScanqrcodeL1");
        
    }

    public void level2()
    {
        SceneManager.LoadScene("ScanqrcodeL2");
    }

    public void level3()
    {
        SceneManager.LoadScene("ScanqrcodeL3");
    }

    public void ARlevel1()
    {
        SceneManager.LoadScene("ARNavL1");
    }

    public void ARlevel2()
    {
        SceneManager.LoadScene("ARNavL2");
    }

    public void ARlevel3()
    {
        SceneManager.LoadScene("ARNavL3");
    }

    
}
