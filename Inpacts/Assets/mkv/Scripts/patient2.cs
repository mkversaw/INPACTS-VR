using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class patient2 : MonoBehaviour
{
    Animator anim;
    [SerializeField] private Animator cottonBallAnim;
    void Start()
    {
        anim = GetComponent<Animator>();
        playIdle(); // start by idling
    }


    void Update()
    {
        if (Input.GetKeyDown("i"))
        { // idle
            playIdle();
        }
        else if (Input.GetKeyDown("a"))
        { // arm
            playArmRaise();
        }
        else if (Input.GetKeyDown("n"))
        {
            playCottonBall();
        } else if (Input.GetKeyDown("l"))
        {
            //anim.ResetTrigger("playArm");
            //print("playing finger prick, arm must be extended for this to work");
            //if (anim.GetBool("isExtended"))
            //{
            //    anim.SetTrigger("playPrick");
            //    anim.SetBool("isIdle", false);
            //}
            //else
            //{
            //    print("arm was not already extended!");
            //}
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

        //anim.ResetTrigger("playIdle");
        anim.ResetTrigger("playArm");

        anim.SetTrigger("playCottonBall");
        cottonBallAnim.SetTrigger("playCottonBall"); // have cotton ball move with it

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
