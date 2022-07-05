using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rayswapper : MonoBehaviour
{
	public Transform rightHandAnchorTransform;
	public Transform leftHandAnchorTransform;

	public OVRInputModule module;

	private bool isRight = true; // default to right hand

	private void Update()
	{

		if(isRight && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) // left
		{
			isRight = false;
			module.rayTransform = leftHandAnchorTransform;
			module.joyPadClickButton = OVRInput.Button.PrimaryIndexTrigger;

		} else if (!isRight && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) // right
		{
			isRight = true;
			module.rayTransform = rightHandAnchorTransform;
			module.joyPadClickButton = OVRInput.Button.SecondaryIndexTrigger;
		}
	}
}
