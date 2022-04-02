using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class patient : MonoBehaviour
{
    Animator anim; 
    void Start()
    {
        anim = GetComponent<Animator>();
        print("anim script started");
    }

    
    void Update()
    {
        if (Input.GetKeyDown("i")) { // idle
            print("playing idle animation");
            anim.SetBool("isIdle", true);
            anim.SetTrigger("playIdle");      
        } else if (Input.GetKeyDown("a")) { // arm
            print("playing raise arm animation");
            anim.SetTrigger("playArm");
            anim.SetBool("isIdle", false);
        } else if (Input.GetKeyDown("n")) { // nod
            print("playing head nod animation");
            anim.SetTrigger("playNod");
            anim.SetBool("isIdle", false);
        } else if (Input.GetKeyDown("k"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
