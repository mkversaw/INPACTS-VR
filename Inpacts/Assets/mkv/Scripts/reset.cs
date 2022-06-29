using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
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
        }
    }
}
