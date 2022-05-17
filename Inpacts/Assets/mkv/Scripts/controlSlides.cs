using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlSlides : MonoBehaviour
{

    [SerializeField] List<GameObject> slides;
    [SerializeField] bool loopSlides;
    [SerializeField] GameObject managerRef;
    [SerializeField] GameObject gloveBoxRef;
    [SerializeField] GameObject testObj2;

    [SerializeField] Button playExampleRef;

    private int currSlide = 0;

    private bool canMoveOn = true; // whether the user still needs to complete some action before going to next slide

    private bool hasGloves = false;
    private bool snappedToMonitor = false; // if test strip is in monitor
    void Start()
    {
        //managerRef.GetComponent<highlight>().highlightObj(testObj);

        slides[currSlide].SetActive(true); // enable the first slide
        slideEvent(currSlide);
    }

    
    void Update()
    {
        //if(Input.GetKeyUp(KeyCode.Y))
        //{
        //    managerRef.GetComponent<highlight>().highlightObj(testObj2);
        //}
        //
        //if(Input.GetKeyUp(KeyCode.X))
        //{
        //    print("test");
        //    managerRef.GetComponent<highlight>().unhighlightObj();
        //}
    }

    private void slideEvent(int i) // if the given slide has an event, then play it
    {
        switch(i)
        {
            case 4: // introducing yourself to patient
                playExampleRef.gameObject.SetActive(true);
                break;
            case 5: // washing hands

                // fade screen to white and play water sound FX

                break;

            case 6: // put on gloves

                managerRef.GetComponent<highlight>().highlightObj(gloveBoxRef); // highlight the glovebox

                break;

            case 7: // patient washes their hands

                // fade screen to white again and player water sound FX

                break;

            case 8: // prepare glucose monitor

                // highlight test strip and monitor

                break;

            case 9: // prepare lancet

                // highlight lancet

                playExampleRef.gameObject.SetActive(true); // enable example for voiceline of asking patient to position their hand

                break;

            case 10: // prick finger


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
            if (currSlide == slides.Count - 1) // if on the last slide
            {
                if (loopSlides) // loop back to first slide
                {
                    slides[currSlide].SetActive(false); // disable the current slide
                    currSlide = 0; // reset currSlide counter
                    slides[currSlide].SetActive(true);
                }
            }
            else // base case
            {
                slides[currSlide].SetActive(false); // disable the current slide
                currSlide++;
                slides[currSlide].SetActive(true); // make the next slide active
            }
        }
    }
}

