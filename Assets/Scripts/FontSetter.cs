using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FontSetter : MonoBehaviour
{
	public Font toSet;  // Set in inspector.
	Image[] retint;
	Text[] allText;

	Color currOrange = new Color(255, 211, 173, 255);

	// Use this for initialization
	void Update ()
	{
		allText = GetComponentsInChildren<Text>();
		if (toSet != null)
		{
			foreach (Text ii in allText)
			{
				ii.font = toSet;
				//ii.color = new Color(255, 255, 255);
				//ii.fontSize = 26;
			}
		}

		retint = GetComponentsInChildren<Image>();
		foreach (Image ii in retint)
		{
			if (ii.color == currOrange)
			{
				ii.color = new Color(83, 59, 38);
			}
		}
	}
}
