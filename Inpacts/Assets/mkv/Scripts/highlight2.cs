using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight2 : MonoBehaviour
{
	private GameObject currObj;
	private Queue<Material> matQ;
	private Component[] components;
	[SerializeField] private Material highlightMat;
	public bool isHighlighted = false;

	public void highlightObj()
	{
		if (isHighlighted)
		{
			return;
		}

		isHighlighted = true;
		components = this.GetComponentsInChildren(typeof(Renderer)); // get every material obj has
		matQ = new Queue<Material>();

		print("highlighting obj");

		foreach (Renderer r in components) // iterate through those materials
		{

			matQ.Enqueue(r.material);
			r.material = highlightMat;

		}
	}

	public void unhighlightObj()
	{
		if (!isHighlighted)
		{
			//print("NO OBJECT TO UNHIGHLIGHT!");
			return;
		}
		isHighlighted = false;
		foreach (Renderer r in components) // iterate through those materials
		{
			r.material = matQ.Dequeue(); // dequeue and set r to the original material
		}
	}

}
