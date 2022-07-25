using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urineBottle : MonoBehaviour
{
	[SerializeField] private GameObject urineStripRef;
	[SerializeField] private GameObject urineBottleRef;
	[SerializeField] private GameObject parentRef;

	private bool touchedUrine = false;
	public bool canTouch = false;

	private void Start()
	{
		parentRef.SetActive(false);
		gameObject.SetActive(false);
	}

	public void initial()
	{
		parentRef.SetActive(true);
		gameObject.SetActive(true);
	}
	public void urineEnable()
	{
		canTouch = true;
		parentRef.SetActive(true);
		gameObject.SetActive(true);
		urineBottleRef.GetComponent<highlight2>().highlightObj();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == urineStripRef && !touchedUrine && canTouch)
		{
			print("urine strip touched urine!");

			urineStripRef.GetComponent<basemapSequencer>().startSequence();
			touchedUrine = true;

			urineBottleRef.GetComponent<highlight2>().unhighlightObj();

			GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager
		}


	}

}