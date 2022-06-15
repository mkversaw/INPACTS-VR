using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urineBottle : MonoBehaviour
{
	[SerializeField] private GameObject urineStripRef;
	[SerializeField] private GameObject urineBottleRef;

	private bool touchedUrine = false;

	private void Start()
	{
		gameObject.SetActive(false);
	}

	public void urineEnable()
	{
		urineBottleRef.GetComponent<highlight2>().highlightObj();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == urineStripRef && !touchedUrine)
		{
			print("urine strip touched urine!");

			urineStripRef.GetComponent<basemapSequencer>().startSequence();
			touchedUrine = true;

			urineBottleRef.GetComponent<highlight2>().unhighlightObj();

			GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager
		}


	}

}