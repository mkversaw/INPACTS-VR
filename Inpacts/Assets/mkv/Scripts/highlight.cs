using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight : MonoBehaviour
{
	private GameObject currObj;
	public Queue<Material> matQ;
	public Component[] components;
	[SerializeField] private Material highlightMat;
	private bool isHighlighted = false;
	
	private void Start()
	{

	}
	
	public void highlightObj(GameObject obj)
	{
		if(isHighlighted)
		{
			print("ANOTHER OBJECT OR THIS ONE IS ALREADY HIGHLIGHTED!");
			return;
		}

		isHighlighted = true;
		components = obj.GetComponentsInChildren(typeof(Renderer)); // get every material obj has
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
		if(!isHighlighted)
		{
			print("NO OBJECT TO UNHIGHLIGHT!");
			return;
		}
		isHighlighted = false;
		print("unhighlighting");
		foreach (Renderer r in components) // iterate through those materials
		{
			print("bing");
			r.material = matQ.Dequeue(); // dequeue and set r to the original material
		}
	}

}
