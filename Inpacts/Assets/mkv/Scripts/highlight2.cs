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

	private int specialVar = 0;

	public void highlightObj(int special = 0)
	{
		specialVar = special;
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
			Material r2;
			if (special == 0)
			{
				print(gameObject.name);
				r2 = new Material(r.material);
			} else
			{
				print("special!");
				print(r.materials.Length);
				print(gameObject.name);
				r2 = new Material(r.materials[1]);
			}
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
			if (specialVar == 0)
			{
				r.material = oldMats[0]; // dequeue and set r to the original material
				oldMats.RemoveAt(0);
			} else
			{
				r.materials[1] = oldMats[0]; // dequeue and set r to the original material
				oldMats.RemoveAt(0);
			}
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
				if(specialVar == 0)
				{
					rends[i].material.color = Color.Lerp(oldMats[i].color, target, Mathf.PingPong(Time.time, 1.5f)); // linear interpolate between original color and highlighted color
				} else
				{
					rends[i].materials[1].color = Color.Lerp(oldMats[i].color, target, Mathf.PingPong(Time.time, 1.5f)); // linear interpolate between original color and highlighted color
				}
				
			}

			yield return new WaitForSeconds(0.05f);
		}
	}

}
