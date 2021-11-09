using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    Target targetpoint;
     
  [SerializeField]
    Text distancetext;
    [SerializeField]
    Text destinationtext;

    [SerializeField]
    private GameObject directionGuide;

    [SerializeField]
    private GameObject destinationLabel;

    [SerializeField]
    private GameObject scroll;

    [SerializeField]
    private GameObject endNavBtn;

    [SerializeField]
    private GameObject continueNavBtn;

    [SerializeField]
    Image directionImage;
    [SerializeField]
    Text directionText;
    [SerializeField]
    Text directiondistanceText;

    [SerializeField]
    Sprite[] directionImages;

    [SerializeField]
    float distancetoEndNavigation;
    [SerializeField]
    float arlineHeight;
    [SerializeField]
    float distanceToIncreaseTargetPoint;

    bool PlayedAudio = false;
    bool isDestinationSet = false;
    int targetpointindex = -1;
    Vector3[] currentPathPoints;
  
    bool isOffScreen;

    public Transform[] arPin;
    public Transform[] minimapPin;
    public ParticleSystem[] particleSystems;

    public GameObject PanelMenu;


    private void Awake()
    {
        QRresult = PlayerPrefs.GetString("QRResult");
        directionGuide.SetActive(false);
        endNavBtn.SetActive(false);
        continueNavBtn.SetActive(false);
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
            topdownCamera.transform.eulerAngles = new Vector3(90, 0, 0);

        }
        else if (QRresult == "Starting Point 3")
        {
            start = startingpoints[2];
            topdownCamera.transform.eulerAngles = new Vector3(90, 0, 0);

        }
        else if (QRresult == "Starting Point 4")
        {
            start = startingpoints[3];
            topdownCamera.transform.eulerAngles = new Vector3(90, 0, 0);

        }
        startpos = new Vector3(start.position.x, start.position.y, start.position.z);
        arsessionorigin.transform.position = startpos;




        if (isDestinationSet)
        {
            destinationtext.text = target.name;

            UpdateCurrentPoint();
            UpdateOffScreenPointerVisibility();

            
            distancetext.text = Mathf.Floor(Vector3.Distance(person.position, target.position)).ToString() + " m to";

            
            if (!isOffScreen)
            {
                if (Vector3.Distance(person.position, target.position) <= distancetoEndNavigation)
                {
                    EndNavigation();
                }

                directionGuide.SetActive(true);

                directiondistanceText.text = "in "+ Mathf.RoundToInt(Vector3.Distance(person.transform.position,
                    targetpoint.transform.position)).ToString() + "m";


                Vector3 direction = currentPathPoints[targetpointindex+1] - targetpoint.transform.position;
                Vector3 forward = arLinePool.transform.forward;
                float angle = Vector3.SignedAngle(direction, forward, arLinePool.transform.up);

                if (angle < -40.0f)
                {
                    directionImage.sprite = directionImages[2];
                    directionText.text = "Turn Right";

                    if (!PlayedAudio)
                    {
                        AudioManager.instance.AudioTurnRight();
                        PlayedAudio = true;
                    }
                }
                else if (angle > 40.0f)
                {
                    directionImage.sprite = directionImages[1];
                    directionText.text = "Turn Left";

                    if (!PlayedAudio)
                    {
                        AudioManager.instance.AudioTurnLeft();
                        PlayedAudio = true;
                    }
                }
                else
                {
                    directionImage.sprite = directionImages[0];
                    directionText.text = "Go Straight";
                    if (!PlayedAudio)
                    {
                        AudioManager.instance.AudioGoStraight();
                        PlayedAudio = true;
                    }
                }
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
          endNavBtn.SetActive(true);
          continueNavBtn.SetActive(true);
          destinationLabel.SetActive(false);
          scroll.SetActive(false);

          PlayedAudio = false;

          target = destinations[index];
          targetpin = arPin[pinindex];
          targetminimapPin = minimapPin[minimapindex];
          particleSystem = particleSystems[psindex];

        destinationtext.text = target.name;

        
        targetpin.gameObject.SetActive(true);
        targetminimapPin.gameObject.SetActive(true);

        
        NavMesh.CalculatePath(person.position, target.position, NavMesh.AllAreas, Path);
        arLinePool.SetLinePositions(Path.corners);
        topdownlinepool.SetLinePositions(Path.corners);

        currentPathPoints = Path.corners;
        targetpointindex = 1;
        targetpoint.enabled = true;
        targetpoint.transform.position = currentPathPoints[targetpointindex];

        

    }

   
    public void EndNavigation()
    {
        if (!isDestinationSet)
        {
            directionGuide.SetActive(false);
            distancetext.text = "Select";
            destinationtext.text = "Destination";
            return;
        }
            

        isDestinationSet = false;
        PlayedAudio = false;

        AudioManager.instance.Audioreached();
        distancetext.text = "You  are";
        destinationtext.text = "reached";
       
        targetpin.transform.GetComponent<Animator>().SetTrigger("Arrived");
        particleSystem.Play();

        AudioManager.instance.AudioYouAreReached();

        Invoke("Deactivate", 5.0f);
     
        topdownlinepool.HideLine();
        arLinePool.HideLine();
       

        currentPathPoints = null;
        targetpointindex = -1;
        targetpoint.enabled = false;

        Animator animator = PanelMenu.GetComponent<Animator>();
        if (animator != null)
        {
            bool isOpen = animator.GetBool("show");
            animator.SetBool("show", !isOpen);
        }

        continueNavBtn.SetActive(false);
        directionGuide.SetActive(false);


    }

    private void UpdateOffScreenPointerVisibility()
    {
        Vector3 targetPositionScreenPoint = arCamera.WorldToScreenPoint(targetpoint.transform.position);
        isOffScreen = targetPositionScreenPoint.x <= 0 || targetPositionScreenPoint.x >= Screen.width ||
            targetPositionScreenPoint.y <= 0 || targetPositionScreenPoint.y >= Screen.height;

        targetpoint.enabled = isOffScreen;
    }

    private void UpdateCurrentPoint()
    {
        if (targetpointindex < currentPathPoints.Length)
        {
            if (Vector3.Distance(person.position, currentPathPoints[targetpointindex]) <= distanceToIncreaseTargetPoint)
            {
                targetpointindex++;
                targetpoint.transform.position = currentPathPoints[targetpointindex];
                PlayedAudio = false;    
            }
        }
        else
        {
            directionImage.sprite = directionImages[0];
            directionText.text = "Go Straight";
            if (!PlayedAudio)
            {
                AudioManager.instance.AudioGoStraight();
                PlayedAudio = true;
            }
        }
    }

    private void Deactivate()
    {
        targetpin.gameObject.SetActive(false);
        targetminimapPin.gameObject.SetActive(false);

    }

    public void stopNavigate()
    {
        AudioManager.instance.AudioClick();
        isDestinationSet = false;

        topdownlinepool.HideLine();
        arLinePool.HideLine();
       

        destinationLabel.SetActive(true);
        scroll.SetActive(true);
        endNavBtn.SetActive(false);
        continueNavBtn.SetActive(false);

       
        targetpin.gameObject.SetActive(false);
        targetminimapPin.gameObject.SetActive(false);

        directionGuide.SetActive(false);
        distancetext.text = "Select";
        destinationtext.text = "Destination";

        target = null;
        targetpin = null;
        targetminimapPin = null;
        particleSystem = null;

        currentPathPoints = null;
        targetpointindex = -1;
        targetpoint.enabled = false;

    }
}