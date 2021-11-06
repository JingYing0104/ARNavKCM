using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{

    private void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void level1()
    {
        AudioManager.instance.AudioClick();
        SceneManager.LoadScene("ScanqrcodeL1");
        
    }

    public void level2()
    {
        AudioManager.instance.AudioClick();
        SceneManager.LoadScene("ScanqrcodeL2");
    }

    public void level3()
    {
        AudioManager.instance.AudioClick();
        SceneManager.LoadScene("ScanqrcodeL3");
    }

    public void ARlevel1()
    {
        AudioManager.instance.AudioClick();
        SceneManager.LoadScene("ARNavL1");
    }

    public void ARlevel2()
    {
        AudioManager.instance.AudioClick();
        SceneManager.LoadScene("ARNavL2");
    }

    public void ARlevel3()
    {
        AudioManager.instance.AudioClick();
        SceneManager.LoadScene("ARNavL3");
    }

    
}
