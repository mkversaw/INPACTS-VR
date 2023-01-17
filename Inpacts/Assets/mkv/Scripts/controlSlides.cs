using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the slides, their interactions, and transitions
/// Very important class, interacts with most other components
/// </summary>
public class controlSlides : MonoBehaviour
{
    [SerializeField] private bool debugMode = false;
    [SerializeField] private bool disableWater = false; // save time when testing :)

    [SerializeField] private List<GameObject> slides;
    [SerializeField] private GameObject animControlRef;
    [SerializeField] private GameObject managerRef;
    [SerializeField] private GameObject gloveBoxRef;
    [SerializeField] private GameObject glucometerRef;
    [SerializeField] private GameObject testStripRef;
    [SerializeField] private GameObject lancetRef;
    [SerializeField] private GameObject prickSiteRef;
    [SerializeField] private GameObject sharpsBinRef;
    [SerializeField] private GameObject trashCanRef;
    [SerializeField] private GameObject tvRef;
    [SerializeField] private GameObject fadeCanvasRef;

    [SerializeField] private GameObject urineStripRef;
    [SerializeField] private GameObject urineBottleRef;
    [SerializeField] private GameObject urineSTRIPBottleRef;

    [SerializeField] private GameObject waterBottleRef;
    [SerializeField] private GameObject waterRef;

    [SerializeField] private GameObject ghostHandRef;

    [SerializeField] private Button nextRef;
    [SerializeField] private Button prevRef;
    [SerializeField] private Button playExampleRef;

    [SerializeField] private Button startRef;
    public logData logRef;

    public int currSlide = 0;
    public int backSlide = 0;
    public int lockPoint = -1;

    private bool canMoveOn = true; // whether the user still needs to complete some action before going to next slide
    private bool queuedEnable = false;

    [System.NonSerialized] public bool hasGloves = false; // is user wearing gloves?
    [System.NonSerialized] public bool stripInMonitor = false; // is glucose test strip in the monitor?
    [System.NonSerialized] public bool stripTouchedBlood = false; // has the strip touched the blood?
    [System.NonSerialized] public bool lancetTouched = false; // has the lancet been prepped?
    [System.NonSerialized] public bool pricked = false; // has the patient been pricked?

    private int sharpsTrashCount = 0;
    private int fadeTextCounter = 0;
    void Start()
    {
        backSlide = currSlide;
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeIn(); // start scene with a fade in effect
        slides[currSlide].SetActive(true); // enable the first slide

        urineStripRef.SetActive(false);
        urineSTRIPBottleRef.SetActive(false);

        slideEvent(currSlide);
    }

    private void Update() // scuffed, need to redo this later!
    {
        if(hasGloves && !canMoveOn)
        {
            if(!stripInMonitor)
            {
                if(testStripRef.GetComponent<snappable>().isSnapped) // is glucose test strip in the monitor?
                {
                    logRef.writeLine("Put test strip in glucometer");
                    stripInMonitor = true;
                    enableNext();
                }
            } else if (!lancetTouched)
            {
                if(lancetRef.GetComponent<wasGrabbed>().grabbed) // has the lancet been prepped?
                {
                    lancetTouched = true;
                    enableNext();
                }
            }
        }
    }


    IEnumerator Fade(float t) // coroutine to fade screen out for 3 seconds then back in
    {
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeOut();
        yield return new WaitForSeconds(t);
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeIn();
    }


    IEnumerator Water(float t1, float t2)
    {
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeOut();
        yield return new WaitForSeconds(t1);

        fadeCanvasRef.GetComponent<projectText>().alterText(fadeTextCounter, true);

        managerRef.GetComponent<controlSound>().Play("water"); // play water sound FX
        yield return new WaitForSeconds(t2);
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeIn();

        fadeCanvasRef.GetComponent<projectText>().alterText(fadeTextCounter++, false); // increment fade text counter here
    }

    IEnumerator UrineTransition(float t) // coroutine to fade screen out for 3 seconds then back in
    {
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeOut();
        yield return new WaitForSeconds(t);

        animControlRef.GetComponent<patient2>().playIdle();

        fadeCanvasRef.GetComponent<projectText>().alterText(fadeTextCounter, true);

        GetComponent<clearObjects>().clear(); // clear out un-needed objects from the table e.g. the glucometer

        waterBottleRef.SetActive(true);
        urineStripRef.SetActive(true); // enable the urine strip object
        urineSTRIPBottleRef.SetActive(true); // enable the urine strip bottle object

        urineBottleRef.GetComponent<urineBottle>().initial(); // enable the urine sample and urine sample bottle

        yield return new WaitForSeconds(t);

        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeIn();

        fadeCanvasRef.GetComponent<projectText>().alterText(fadeTextCounter++, false); // increment fade text counter here
    }

    IEnumerator waterBottleTransition(float t)
    {
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeOut();
        yield return new WaitForSeconds(5.0f);

        fadeCanvasRef.GetComponent<projectText>().alterText(fadeTextCounter, true);

        waterRef.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeIn();

        fadeCanvasRef.GetComponent<projectText>().alterText(fadeTextCounter++, false); // increment fade text counter here
    }

    public void disableNext()
    {
        if(debugMode)
        {
            return;
        }
        nextRef.interactable = false; // gray the button out
        canMoveOn = false;
    }

    public void enableNext(bool playSound = true)
    {
        if (playSound)
        {
            managerRef.GetComponent<controlSound>().Play("completed"); // play completed task sound
        }
        
        if(backSlide != currSlide) // need to "queue" the enable, save it for when they get back to the slide they were stopped at before
        {
            queuedEnable = true;
        }

        nextRef.interactable = true; // ungray the button
        canMoveOn = true;
    }


    private void slideEvent(int i) // if the given slide has an event, then play it
    {

        

        switch (i)
        {
            case 1:
                managerRef.GetComponent<controlSound>().Play("intro"); // play the intro
                break;

            case 3:
                break;

            case 4: // introducing yourself to patient
                break;

            case 5: // washing hands

                if (!disableWater)
                {
                    StartCoroutine(Water(5.0f, 3.0f)); // fade and play water SFX
                }

                gloveBoxRef.GetComponent<highlight2>().highlightObj(); // highlight the glovebox
                gloveBoxRef.GetComponent<gloveBox>().highlighted = true; // highlight the glovebox
                disableNext(); // cant move on until task is done

                break;

            case 6: // put on gloves

                break;

            case 7: // patient washes their hands

                if (!disableWater)
                {
                    StartCoroutine(Water(5.0f, 3.0f)); // fade and play water SFX
                }

                glucometerRef.GetComponent<highlight2>().highlightObj(); // highlight test strip and monitor
                testStripRef.GetComponent<highlight2>().highlightObj(); // highlight test strip and monitor
                disableNext(); // cant move on until task is done

                break;

            case 8: // prepare glucose monitor

                glucometerRef.GetComponent<highlight2>().unhighlightObj(); 
                testStripRef.GetComponent<highlight2>().unhighlightObj(); 


                lancetRef.GetComponent<highlight2>().highlightObj();
                disableNext(); // cant move on until task is done

                break;

            case 9: // prepare lancet
                animControlRef.GetComponent<patient2>().playArmRaise(); // play animation of arm extend
                prickSiteRef.SetActive(true);
                disableNext(); // cant move on until task is done

                break;

            case 10: // prick finger
                ghostHandRef.SetActive(true);
                //canBeGrabbed
                
                FindObjectOfType<squeezePoint>().GetComponent<squeezePoint>().canBeGrabbed = true;
                
                testStripRef.GetComponent<testStrip>().canTouch = true; // !!!!!!!!!!
                disableNext(); // cant move on until task is done

                break;

            case 11:

                break;

            case 12:
                trashCanRef.GetComponent<highlight2>().highlightObj(); // highlight the trashCan

                animControlRef.GetComponent<patient2>().playCottonBall(); // play animation of grabbing cotton ball
                
                sharpsBinRef.GetComponent<sharpsBin>().canDelete = true; // let sharps bin delete lancet

                disableNext();

                break;


            case 13:

                break;

            case 14:

                StartCoroutine(UrineTransition(4.0f));
                gloveBoxRef.GetComponent<gloveBox>().highlighted = true;
                gloveBoxRef.GetComponent<gloveBox>().hasGloves = false;
                disableNext();

                break;

            case 15:


                urineBottleRef.GetComponent<urineBottle>().urineEnable();
                urineStripRef.GetComponent<highlight2>().highlightObj(1);

                disableNext();



                break;

            case 16:

                urineSTRIPBottleRef.GetComponent<highlight2>().highlightObj();
                disableNext();

                break;

            case 17:

                trashCanRef.GetComponent<trashCan>().round2Checks(); // enable urine stuff checks etc from the trash can
                trashCanRef.GetComponent<highlight2>().highlightObj(); // highlight the trashCan

                disableNext();

                break;

            case 18:

                break;

            case 19:
                StartCoroutine(waterBottleTransition(3.0f));

                tvRef.SetActive(true);
                disableNext();

                break;

            case 20:

                disableNext();

                break;

            default:
                
                break;
        }
    }

    public void nextSlide()
    {
        if (canMoveOn)
        {
            prevRef.interactable = true;
            managerRef.GetComponent<controlSound>().Play("click"); // play button click noise

                if (backSlide != currSlide) // no event should play
                {
                    if (backSlide == (lockPoint - 1))
                    {
                        if (!queuedEnable)
                        {
                            disableNext();
                        } else
                        {
                            queuedEnable = false; // "expire/empty" the queue
                        }
                    }

                    slides[backSlide].SetActive(false); // disable the current slide
                    slides[backSlide + 1].SetActive(true); // make the next slide active
                }
                else // event should play
                {
                    slides[currSlide].SetActive(false); // disable the current slide
                    currSlide++;
                    slides[currSlide].SetActive(true); // make the next slide active


                    slideEvent(currSlide);
                }
                backSlide++;
            logRef.writeLine("Moved to slide: " + currSlide);
        }
    }

    public void prevSlide()
    {
        if(backSlide > 0) // dont go past the first slide
        {

            if(backSlide == 1)
            {
                prevRef.interactable = false; // gray the button out
            }
            
            managerRef.GetComponent<controlSound>().Play("click"); // play button click noise

            if (backSlide == currSlide && !canMoveOn) // remember if progress is "locked" !!!
            {
                enableNext(false);
                lockPoint = currSlide;
            }

            slides[backSlide].SetActive(false); // disable the current slide
            backSlide--; // decrement backSlide counter
            slides[backSlide].SetActive(true); // enable the previous slide
            logRef.writeLine("Moved to slide: " + currSlide);
        }
    }

    public void sharpsTrash()
    {
        sharpsTrashCount++;
        if(sharpsTrashCount == 2)
        {
            enableNext();
        }
    }

    public void EnableButtons()
    {
        startRef.gameObject.SetActive(false);
        nextRef.gameObject.SetActive(true);
        prevRef.gameObject.SetActive(true);
        nextSlide();
    }

}

