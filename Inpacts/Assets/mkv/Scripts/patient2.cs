using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class patient2 : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        playIdle(); // start by idling
    }


    void Update()
    {
        if (Input.GetKeyDown("i"))
        { // idle
            print("playing idle animation");
            anim.SetBool("isIdle", true);
            anim.SetTrigger("playIdle");
        }
        else if (Input.GetKeyDown("a"))
        { // arm
            print("playing raise arm animation");
            anim.ResetTrigger("playIdle");
            anim.SetBool("isExtended", true);
            anim.SetTrigger("playArm");
            anim.SetBool("isIdle", false);
        }
        else if (Input.GetKeyDown("n"))
        { // nod
            print("playing cotton grab");
            anim.SetTrigger("playCottonBall");
            anim.SetBool("isIdle", false);
        } else if (Input.GetKeyDown("l"))
        {
            anim.ResetTrigger("playArm");
            print("playing finger prick, arm must be extended for this to work");
            if (anim.GetBool("isExtended"))
            {
                anim.SetTrigger("playPrick");
                anim.SetBool("isIdle", false);
            }
            else
            {
                print("arm was not already extended!");
            }
        }
        else if (Input.GetKeyDown("k"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void playIdle()
    {
        print("playing idle animation");
        anim.SetBool("isIdle", true);
        anim.SetTrigger("playIdle");
    }

    public void playArmRaise()
    {
        print("playing raise arm animation");
        anim.ResetTrigger("playIdle");
        anim.SetBool("isExtended", true);
        anim.SetTrigger("playArm");
        anim.SetBool("isIdle", false);
    }

    public void playCottonBall()
    {
        print("playing cotton grab");
        anim.SetTrigger("playCottonBall");
        anim.SetBool("isIdle", false);
    }

    public void playFingerPrick()
    {
        anim.ResetTrigger("playArm");
        print("playing finger prick, arm must be extended for this to work");
        if (anim.GetBool("isExtended"))
        {
            anim.SetTrigger("playPrick");
            anim.SetBool("isIdle", false);
        }
        else
        {
            print("arm was not already extended!");
        }
    }
}
