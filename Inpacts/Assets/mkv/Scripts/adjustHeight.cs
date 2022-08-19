using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quality-of-Life tool for adjusting the player's height with the 'B' and 'A' buttons
/// </summary>

public class adjustHeight : MonoBehaviour
{
    [SerializeField] private Transform centerEyeCameraTransform;
    [SerializeField] private bool isEnabled = false;
    void Update()
    {
        if (isEnabled)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                print("moving camera down");
                centerEyeCameraTransform.localPosition += (Vector3.down * 0.05f);
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                print("moving camera up");
                centerEyeCameraTransform.localPosition += (Vector3.up * 0.05f);
            }
        }
    }
}
