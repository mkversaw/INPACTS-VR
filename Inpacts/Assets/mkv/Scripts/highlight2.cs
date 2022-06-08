using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight2 : MonoBehaviour
{
	private List<Renderer> rends;
	private List<Material> oldMats;
	private Color target = new Vector4(1.5f, 1.5f, 0, 1);
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

		rends = new List<Renderer>();
		oldMats = new List<Material>();

		//print("highlighting obj");

		foreach (Renderer r in components) // iterate through those materials
		{
			rends.Add(r);
			Material r2 = new Material(r.material);
			oldMats.Add(r2);

		}
		StartCoroutine(FlashObj());
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
			r.material = oldMats[0]; // dequeue and set r to the original material
			oldMats.RemoveAt(0);
		}
		rends.Clear();
	}

	IEnumerator FlashObj()
	{
		//print("flashing obj");
		while (true)
		{
			for (int i = 0; i < rends.Count; i++) // for each renderer material
			{
				rends[i].material.color = Color.Lerp(oldMats[i].color, target, Mathf.PingPong(Time.time, 1.5f)); // linear interpolate between original color and highlighted color
			}

			yield return new WaitForSeconds(0.05f);
		}
	}

}
