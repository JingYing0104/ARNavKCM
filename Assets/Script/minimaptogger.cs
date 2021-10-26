using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimaptogger : MonoBehaviour
{
    public GameObject fullscreenMap;
    bool fullmap;

    public void toggerFullmap()
    {
        if (fullmap)
        {
            fullmap = false;
            AudioManager.instance.AudioClick();
            fullscreenMap.SetActive(false);
        }else
        {
            fullmap = true;
            AudioManager.instance.AudioClick();
            fullscreenMap.SetActive(true);
        }
    }


}
