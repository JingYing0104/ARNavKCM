using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    private AudioSource audioSourcebtn;
 
    private void Awake()
    {
        audioSourcebtn = GetComponent<AudioSource>();
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

    IEnumerator Wait(float cliplength)
    {
        yield return new WaitForSeconds(cliplength);
    }
}
