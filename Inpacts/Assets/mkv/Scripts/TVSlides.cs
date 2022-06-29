using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVSlides : MonoBehaviour
{
	// Make sure this script is on the tv CANVAS not the tv object !!!


	[SerializeField] private List<GameObject> slides;

	[SerializeField] private Button nextRef;
	[SerializeField] private Button prevRef;

	private GameObject managerRef;

	public int currSlide = 0;
	private void Start()
	{
		gameObject.SetActive(false);
		managerRef = GameObject.FindGameObjectWithTag("Manager");
	}

	public void nextSlide()
	{
		print("next tv");
		if (currSlide < slides.Count)
		{
			managerRef.GetComponent<controlSound>().Play("click"); // play button click noise

			prevRef.interactable = true; // make PREV arrow enabled

			if (currSlide == slides.Count - 2) // last slide
			{
				nextRef.interactable = false; // gray the button out
				managerRef.GetComponent<controlSlides>().enableNext(); // update status in manager
			}


			slides[currSlide].SetActive(false); // disable CURRENT
			currSlide++; // increment position
			slides[currSlide].SetActive(true); // enable NEXT

		}
	}

	public void prevSlide()
	{
		print("prev tv");
		if (currSlide > 0)
		{
			managerRef.GetComponent<controlSound>().Play("click"); // play button click noise

			nextRef.interactable = true; // make NEXT arrow enabled

			if (currSlide == 1)
			{
				prevRef.interactable = false; // gray the button out
			}

			slides[currSlide].SetActive(false); // disable CURRENT
			currSlide--; // decrement position
			slides[currSlide].SetActive(true); // enable PREV
		}
	}

}
