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

			
			//Material temp = c.GetComponent<Renderer>().material;
			matQ.Enqueue(r.material);
			r.material = highlightMat;
			//if(c.TryGetComponent(out Material mat))
			//{
			//	print(c.name);
			//	matQ.Enqueue(mat); // enqueue the ORIGINAL material
			//	c.GetComponent<Renderer>().material = highlightMat; // change the material to the highlighted version
			//	print("bingus");
			//}

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
