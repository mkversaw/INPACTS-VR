using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    public bool enableDebug;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (enableDebug)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                print("FADING IN");
                GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeIn();
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                print("FADING OUT");
                GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeOut();
            }
        }
    }
}
