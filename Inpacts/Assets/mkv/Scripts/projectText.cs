using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class projectText : MonoBehaviour
{

	public TextMeshProUGUI[] textboxes;
	public void Start()
	{
		for (int i = 0; i < textboxes.Length; i++) // make all textboxes invisible at the start
		{
				textboxes[i].gameObject.SetActive(false);
		}
	}
	public void alterText(int n, bool show = true)
	{
		if(n > 0 && n < textboxes.Length)
		{
			for(int i = 0; i < textboxes.Length; i++)
			{
				if(i != n) // make all other textboxes invisible (just in case)
				{
					textboxes[i].gameObject.SetActive(false);

				} else
				{
					if (show)
					{
						textboxes[i].gameObject.SetActive(true);
					}
					else
					{
						textboxes[i].gameObject.SetActive(false);
					}
				}
			}
		}
	}

}
