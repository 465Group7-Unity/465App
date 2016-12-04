using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Disappear : MonoBehaviour
{
	public Text txt;
	public Image arrow;

	public ToggleButton[] cuisines;
	bool alive = true;
	
	// Update is called once per frame
	void Update ()
	{
		if (alive)
		{
			foreach (ToggleButton ii in cuisines)
			{
				if (ii.toggled)
				{
					alive = false;
					txt.enabled = false;
					arrow.enabled = false;
					break;
				}
			}
         }
	}
}
