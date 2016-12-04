using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RestaurantSetter : MonoBehaviour
{
	ToggleButton[] cuisines;
	public ToggleButton[] restaurants;

	public string[] American = { "", "", "", "", "", "" };
	public string[] Chinese = { "", "", "", "", "", "" };
	public string[] Indian = { "", "", "", "", "", "" };
	public string[] Italian = { "", "", "", "", "", "" };
	public string[] Mexican = { "", "", "", "", "", "" };
	public string[] Japanese = { "", "", "", "", "", "" };


	// Use this for initialization
	void Start ()
	{
		cuisines = DataGrabber.cuisine_data_s;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Controller.currentScreen != "MatchScreenBG")
		{
			// Get active types of cuisine.
			List<ToggleButton> actives = new List<ToggleButton>();
			foreach (ToggleButton ii in cuisines)
			{
				if (ii.toggled)
				{
					actives.Add(ii);
				}
			}

			// Set randomly.
			foreach (ToggleButton ii in restaurants)
			{
				int randomCuisineIdx = Random.Range(0, actives.Count);

			}

			actives.Clear();
		}
	}
}
