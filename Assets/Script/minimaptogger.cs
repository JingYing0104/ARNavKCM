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
            fullscreenMap.SetActive(false);
        }else
        {
            fullmap = true;
            fullscreenMap.SetActive(true);
        }
    }


}
