using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimaptogger : MonoBehaviour
{
    public GameObject fullscreenMap;
    bool fullmap;
    public GameObject offscreenarrow;

    public void toggerFullmap()
    {
        if (fullmap)
        {
            fullmap = false;
            AudioManager.instance.AudioClick();
            fullscreenMap.SetActive(false);
            offscreenarrow.SetActive(true);
        }else
        {
            fullmap = true;
            AudioManager.instance.AudioClick();
            fullscreenMap.SetActive(true);
            offscreenarrow.SetActive(false);
        }
    }


}
