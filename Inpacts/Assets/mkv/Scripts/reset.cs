using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    public GameObject oculusRef;
    private bool easyOn = false;
    public logData logRef;
    void Update()
    {
        if ( // if all of these buttons are held
            OVRInput.Get(OVRInput.Button.PrimaryThumbstick) && // left stick press
            OVRInput.Get(OVRInput.Button.SecondaryThumbstick) && // right stick press
            OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && // left trigger
            OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && // right trigger
            OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && // left grip
            OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) // right grip
        ) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single); // reset scene
        } else if ( // enable easy movement
            OVRInput.Get(OVRInput.Button.PrimaryThumbstick) && // left stick press
            OVRInput.Get(OVRInput.Button.SecondaryThumbstick) // right stick press
        ) {
            if(!easyOn)
            {
                oculusRef.GetComponent<OVRPlayerController>().EnableLinearMovement = true;
                oculusRef.GetComponent<OVRPlayerController>().EnableRotation = true;
                easyOn = true;
            } else
            {
                oculusRef.GetComponent<OVRPlayerController>().EnableLinearMovement = false;
                oculusRef.GetComponent<OVRPlayerController>().EnableRotation = false;
                easyOn = false;
            }

        }

    }

    public void resetScene()
    {
        logData.writeLine("Reset Scene");
        //logRef.eventWriter.Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single); // reset scene
    }

    public void QuitApplication()
    {
        logData.writeLine("SESSION ENDED");
        Application.Quit();
    }

    public void prevScene()
    {
        SceneManager.LoadScene("Lobby Scene");
    }
    public void nextScene()
    {
        SceneManager.LoadScene("PEDI Scenario");
    }
}
