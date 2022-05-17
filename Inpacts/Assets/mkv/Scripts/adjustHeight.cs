using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustHeight : MonoBehaviour
{
    [SerializeField] private Transform centerEyeCameraTransform;

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One)) {
            print("moving camera down");
            centerEyeCameraTransform.localPosition += (Vector3.down * 0.05f);
        } else if(OVRInput.GetDown(OVRInput.Button.Two)) {
            print("moving camera up");
            centerEyeCameraTransform.localPosition += (Vector3.up * 0.05f);
        }
    }
}
