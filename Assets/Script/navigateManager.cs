using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class navigateManager : MonoBehaviour
{
   
     public Transform[] destinations;
     public Transform person;
     public NavMeshPath Path;

    public Transform target;
    public Transform targetpin;
    public Transform targetminimapPin;
    public ParticleSystem particleSystem;

    private string QRresult;
    public Transform[] startingpoints;
    public Transform start;
    public Transform arsessionorigin;
    public Vector3 startpos;
  

    [SerializeField]
    Camera topdownCamera;
    [SerializeField]
    LinePool topdownlinepool;

    [SerializeField]
    Camera arCamera;
    [SerializeField]
    LinePool arLinePool;
    
    [SerializeField]
    float distancetoEndNavigation;
    [SerializeField]
    float arlineHeight;
   
  
    bool isDestinationSet = false;

    public Transform[] arPin;
    public Transform[] minimapPin;
    public ParticleSystem[] particleSystems;

   


    private void Awake()
    {
        QRresult = PlayerPrefs.GetString("QRResult");
    }



    void Start()
    {
        Path = new NavMeshPath();   
        arLinePool.LineHeight = arlineHeight;
        targetminimapPin.gameObject.SetActive(false);
        targetpin.gameObject.SetActive(false);
        
    }

    void Update()
    {
        Screen.sleepTimeout = (int)0f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (QRresult == "Starting Point 1")
        {
            start = startingpoints[0];
            topdownCamera.transform.eulerAngles = new Vector3(90, 0, 0);

        }
        else if (QRresult == "Starting Point 2")
        {
            start = startingpoints[1];

        }
        else if (QRresult == "Starting Point 3")
        {
            start = startingpoints[2];

        }
        else if (QRresult == "Starting Point 4")
        {
            start = startingpoints[3];
        }
        startpos = new Vector3(start.position.x, start.position.y, start.position.z);
        arsessionorigin.transform.position = startpos;




        if (isDestinationSet)
        {
            if (Vector3.Distance(person.position, target.position) < distancetoEndNavigation)
            {
                EndNavigation();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("NavMain");
        }


    }

    public void OnClickDest0Btn()
        {
            AudioManager.instance.AudioClick();
            if (isDestinationSet)
            {
                targetpin.gameObject.SetActive(false);
                targetminimapPin.gameObject.SetActive(false);
            }
            setDestination(0,0,0,0);
    
        }
    
        public void OnClickDest1Btn()
        {
            AudioManager.instance.AudioClick();
            if (isDestinationSet)
            {
                targetpin.gameObject.SetActive(false);
                targetminimapPin.gameObject.SetActive(false);
            }

            setDestination(1,1,1,1);
        }

        public void OnClickDest2Btn()
        {
            AudioManager.instance.AudioClick();
            if (isDestinationSet)
            {
                targetpin.gameObject.SetActive(false);
                targetminimapPin.gameObject.SetActive(false);
            }
            setDestination(2,2,2,2);
        }

        public void OnClickDest3Btn()
        {
            AudioManager.instance.AudioClick();
            if (isDestinationSet)
            {
                targetpin.gameObject.SetActive(false);
                targetminimapPin.gameObject.SetActive(false);
            }
            setDestination(3,3,3,3);
        }

        public void OnClickDest4Btn()
        {
            AudioManager.instance.AudioClick();
            if (isDestinationSet)
            {
                targetpin.gameObject.SetActive(false);
                targetminimapPin.gameObject.SetActive(false);
            }
            setDestination(4,4,4,4);
        }
 
    public void setDestination(int index, int pinindex, int minimapindex, int psindex)
    {
         
          isDestinationSet = true;
          target = destinations[index];
          targetpin = arPin[pinindex];
          targetminimapPin = minimapPin[minimapindex];
          particleSystem = particleSystems[psindex];
         
          targetpin.gameObject.SetActive(true);
          targetminimapPin.gameObject.SetActive(true);

        
        NavMesh.CalculatePath(person.position, target.position, NavMesh.AllAreas, Path);
        arLinePool.SetLinePositions(Path.corners);
        topdownlinepool.SetLinePositions(Path.corners);

       
    }

   
    public void EndNavigation()
    {
        if (! isDestinationSet) return;

        isDestinationSet = false;

       
            targetpin.transform.GetComponent<Animator>().SetTrigger("Arrived");
            particleSystem.Play();

            Invoke("Deactivate", 5.0f);
     
        topdownlinepool.HideLine();
        arLinePool.HideLine();
   
        
    }

    private void Deactivate()
    {
        targetpin.gameObject.SetActive(false);
        targetminimapPin.gameObject.SetActive(false);

    }
}