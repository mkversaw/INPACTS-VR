using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimations : MonoBehaviour
{
    [SerializeField] private GameObject animControlRef;
    int count = 0;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            if(count == 0)
            {
                animControlRef.GetComponent<patient2>().playIdle();
            } else if (count == 1)
            {
                animControlRef.GetComponent<patient2>().playArmRaise();
            }
            else if (count == 2)
            {
                animControlRef.GetComponent<patient2>().playFingerPrick();
            }
            else if (count == 3)
            {
                animControlRef.GetComponent<patient2>().playCottonBall();
                count = -1; // loop back
            }
            count++;
        } else if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (count == 0)
            {
                animControlRef.GetComponent<patient2>().playIdle();
                count = 4; // loop front
            }
            else if (count == 1)
            {
                animControlRef.GetComponent<patient2>().playArmRaise();
            }
            else if (count == 2)
            {
                animControlRef.GetComponent<patient2>().playFingerPrick();
            }
            else if (count == 3)
            {
                animControlRef.GetComponent<patient2>().playCottonBall();
            }
            count--;
        }
    }
}
