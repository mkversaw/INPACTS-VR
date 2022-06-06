using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlSlides : MonoBehaviour
{
    [SerializeField] private bool debugMode = false;
    [SerializeField] private bool disableWater = false; // save time when testing :)

    [SerializeField] private List<GameObject> slides;
    [SerializeField] private bool loopSlides;
    [SerializeField] private GameObject animControlRef;
    [SerializeField] private GameObject managerRef;
    [SerializeField] private GameObject gloveBoxRef;
    [SerializeField] private GameObject glucometerRef;
    [SerializeField] private GameObject testStripRef;
    [SerializeField] private GameObject lancetRef;
    [SerializeField] private GameObject prickSiteRef;
    [SerializeField] private GameObject sharpsBinRef;
    [SerializeField] private GameObject trashCanRef;

    
    


    [SerializeField] private Button nextRef;
    [SerializeField] private Button playExampleRef;

    public int currSlide = 0;

    private bool canMoveOn = true; // whether the user still needs to complete some action before going to next slide

    [System.NonSerialized] public bool hasGloves = false; // is user wearing gloves?
    [System.NonSerialized] public bool stripInMonitor = false; // is glucose test strip in the monitor?
    [System.NonSerialized] public bool stripTouchedBlood = false; // has the strip touched the blood?
    [System.NonSerialized] public bool lancetTouched = false; // has the lancet been prepped?
    [System.NonSerialized] public bool pricked = false; // has the patient been pricked?

    void Start()
    {
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeIn(); // start scene with a fade in effect
        slides[currSlide].SetActive(true); // enable the first slide
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
        managerRef.GetComponent<controlSound>().Play("water"); // play water sound FX
        yield return new WaitForSeconds(t2);
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeIn();
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

    public void enableNext()
    {
        managerRef.GetComponent<controlSound>().Play("completed"); // play completed task sound

        nextRef.interactable = true; // ungray the button
        canMoveOn = true;
    }


    private void slideEvent(int i) // if the given slide has an event, then play it
    {
        switch(i)
        {
            case 2:
                playExampleRef.gameObject.SetActive(true); // play voice line of example intro
                break;

            case 3: // introducing yourself to patient
                playExampleRef.gameObject.SetActive(false);
                break;

            case 4: // washing hands

                if (!disableWater)
                {
                    StartCoroutine(Water(5.0f, 3.0f)); // fade and play water SFX
                }

                gloveBoxRef.GetComponent<highlight2>().highlightObj(); // highlight the glovebox
                disableNext(); // cant move on until task is done

                break;

            case 5: // put on gloves

                
                break;

            case 6: // patient washes their hands

                if (!disableWater)
                {
                    StartCoroutine(Water(5.0f, 3.0f)); // fade and play water SFX
                }

                glucometerRef.GetComponent<highlight2>().highlightObj(); // highlight test strip and monitor
                testStripRef.GetComponent<highlight2>().highlightObj(); // highlight test strip and monitor
                disableNext(); // cant move on until task is done

                break;

            case 7: // prepare glucose monitor


                lancetRef.GetComponent<highlight2>().highlightObj();
                disableNext(); // cant move on until task is done

                break;

            case 8: // prepare lancet

                //playExampleRef.gameObject.SetActive(true); // enable example for voiceline of asking patient to position their hand

                animControlRef.GetComponent<patient2>().playArmRaise(); // play animation of arm extend
                prickSiteRef.SetActive(true);
                disableNext(); // cant move on until task is done

                break;

            case 9: // prick finger


                disableNext(); // cant move on until task is done

                break;

            case 10:

                trashCanRef.GetComponent<highlight2>().highlightObj(); // highlight the trashCan
                break;

            case 11:

                animControlRef.GetComponent<patient2>().playCottonBall(); // play animation of grabbing cotton ball
                
                sharpsBinRef.GetComponent<sharpsBin>().canDelete = true; // let sharps bin delete lancet

                break;


            case 12:

                break;

            case 13:

                break;

            case 14:

                break;

            case 15:

                break;

            case 16:

                break;

            case 17:

                break;

            case 18:

                break;

            case 19:

                break;

            default:
                playExampleRef.gameObject.SetActive(false); // by default, disable play ref button
                break;
        }
    }

    public void nextSlide()
    {
        if (canMoveOn)
        {
            managerRef.GetComponent<controlSound>().Play("click"); // play button click noise

            if (currSlide == slides.Count - 1) // if on the last slide
            {
                if (loopSlides) // loop back to first slide
                {
                    slides[currSlide].SetActive(false); // disable the current slide
                    currSlide = 0; // reset currSlide counter
                    slides[currSlide].SetActive(true);
                }

                slideEvent(currSlide);
            }
            else // base case
            {
                slides[currSlide].SetActive(false); // disable the current slide
                currSlide++;
                slides[currSlide].SetActive(true); // make the next slide active

                
                slideEvent(currSlide);
            }
        }
    }

}

