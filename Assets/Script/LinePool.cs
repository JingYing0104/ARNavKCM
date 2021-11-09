using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinePool : MonoBehaviour
{
    [SerializeField]
    LineRenderer arlinePrefab;
    [SerializeField]
    GameObject cornerPrefab;
    [SerializeField]
    int amountToPool;

    List<LineRenderer> linePool;
    List<GameObject> cornerPool;

    float lineHeight = 0;

    public float LineHeight
    {
        get => lineHeight;
        set => lineHeight = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        linePool = new List<LineRenderer>();
        cornerPool = new List<GameObject>();
        for(int i = 0; i < amountToPool; i++)
        {
            AddLine();
            AddCorner();

        }
        AddCorner();
    }

   private void AddCorner()
    {
        if(cornerPrefab != null)
        {
            GameObject endCorner = Instantiate(cornerPrefab, transform.position,transform.rotation);
            endCorner.SetActive(false);
            cornerPool.Add(endCorner);
        }
    }

    private void AddLine()
    {
        LineRenderer line = Instantiate(arlinePrefab, this.transform);
        line.gameObject.SetActive(false);
        linePool.Add(line);
    }

    public void SetLinePositions(Vector3[] positionArray)
    {
        HideLine();

        if(cornerPrefab != null)
        {
            Vector3 startcornerPosition = new Vector3(positionArray[0].x, positionArray[0].y + lineHeight, positionArray[0].z);
            cornerPool[0].transform.position = startcornerPosition;
            cornerPool[0].SetActive(true);
        }

        for(int i = 0; i < positionArray.Length-1; i++)
        {
            if(i > linePool.Count)
            {
                AddLine();
                AddCorner();
            }

            Vector3 positionA = new Vector3(positionArray[i].x, positionArray[i].y + lineHeight, positionArray[i].z);
            linePool[i].SetPosition(0, positionA);


            Vector3 positionB = new Vector3(positionArray[i+1].x, positionArray[i+1].y + lineHeight, positionArray[i+1].z);
            linePool[i].SetPosition(1, positionB);

            linePool[i].gameObject.SetActive(true);
           

            if(cornerPrefab != null)
            {
                cornerPool[i + 1].transform.position = positionB;
                cornerPool[i + 1].SetActive(true);
            }


        }

        
    }

    public void HideLine()
    {
        foreach(var item in linePool)
        {
            item.gameObject.SetActive(false);
        }

        if(cornerPrefab != null)
        {
            foreach (var item in cornerPool)
            {
                item.SetActive(false);
            }
        }
    }
}
