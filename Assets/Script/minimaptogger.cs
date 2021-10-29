using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimaptogger : MonoBehaviour
{
    public GameObject fullscreenMap;
    public GameObject offscreenArrow;
    bool fullmap;

    public void toggerFullmap()
    {
        if (fullmap)
        {
            fullmap = false;
            AudioManager.instance.AudioClick();
            fullscreenMap.SetActive(false);
            offscreenArrow.SetActive(true);
        }else
        {
            fullmap = true;
            AudioManager.instance.AudioClick();
            fullscreenMap.SetActive(true);
            offscreenArrow.SetActive(false);
        }
    }


}
