using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    [SerializeField]
     IndicatorType indicatorType;

    private Image indicatorImage;
    [SerializeField] Text distanceText;

    private void Awake()
    {
        indicatorImage = transform.GetComponent<Image>();
      
    }

    public bool Active
    {
        get
        {
            return transform.gameObject.activeInHierarchy;
        }
    }

    public IndicatorType Type
    {
        get
        {
            return indicatorType;
        }
    }

   
    public void SetDistanceText(float value)
    {
        distanceText.text = value >= 0 ? Mathf.Floor(value) + " m" : "";
    }

  
    public void SetTextRotation(Quaternion rotation)
    {
        distanceText.rectTransform.rotation = rotation;
    }

   
    public void Activate(bool value)
    {
        transform.gameObject.SetActive(value);
    }
}

public enum IndicatorType
{
    BOX,
    ARROW
}

