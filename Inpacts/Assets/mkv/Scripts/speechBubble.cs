using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speechBubble : MonoBehaviour
{
	public GameObject speechBubbleRef;
	public void enableBubble()
	{
		StartCoroutine(bubble());
	}

	IEnumerator bubble()
	{
		print("ENABLING THE BUBBLE");
		yield return new WaitForSeconds(4.2f);
		speechBubbleRef.GetComponent<Image>().enabled = true;
		yield return new WaitForSeconds(18.5f);
		speechBubbleRef.GetComponent<Image>().enabled = false;
	}
}
