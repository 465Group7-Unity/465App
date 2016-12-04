using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RestaurantSetter : MonoBehaviour
{
	public ToggleButton[] cuisines;
	public ToggleButton[] restaurants;

	public string[] _American = { "McDonalds", "Murphy's", "Legend's", "Black Dog", "Panera Bread", "The Hub" };
	public string[] _Chinese = { "Lai Lai Wok", "Cravings", "South China", "Bobo China", "Golden Wok", "Chopsticks" };
	public string[] _Indian = { "Ambar", "Bombay Grill", "Sitara", "Kohinoor", "Mirsung", "Basmati" };
	public string[] _Italian = { "Mia Za's", "Olive Garden", "Biaggi's", "Azzip Pizza", "Pizza Hut", "Papa Del's" };
	public string[] _Mexican = { "Chipotle", "Maize", "Dos Reales", "Burrito King", "El Toro", "Cactus Grill" };
	public string[] _Japanese = { "Sakanaya", "Sushi Kame", "Sushi Ichiban", "Kofusion", "Oishi's", "Yellofin" };


	// Use this for initialization
	void Start ()
	{
		//cuisines = DataGrabber.cuisine_data_s;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Controller.currentScreen != "MatchScreenBG" && Controller.currentScreen != "MatchLockScreenBG")
		{
			//Debug.Log("Test...");
			// Get active types of cuisine.
			List<ToggleButton> actives = new List<ToggleButton>();
			foreach (ToggleButton ii in cuisines)
			{
				if (ii.toggled)
				{
					actives.Add(ii);
				}
			}
			if (actives.Count == 0) return;

			// Set randomly.
			for (int ii = 0; ii < 6; ii++)
			{
				int randomCuisineIdx = Random.Range(0, actives.Count);
				string type = cuisines[randomCuisineIdx].title;
				//Debug.Log(type);
				switch(type)
				{
					case "American":
						Debug.Log(_American[ii]);
						restaurants[ii].childText.text = _American[ii];
						break;
					case "Chinese":
						//Debug.Log(Chinese[ii]);
						restaurants[ii].childText.text = _Chinese[ii];
						break;
					case "Indian":
						//Debug.Log(Indian[ii]);
						restaurants[ii].childText.text = _Indian[ii];
						break;
					case "Italian":
						//Debug.Log(Italian[ii]);
						restaurants[ii].childText.text = _Italian[ii];
						break;
					case "Mexican":
						//Debug.Log(Mexican[ii]);
						restaurants[ii].childText.text = _Mexican[ii];
						break;
					case "Japanese":
						//Debug.Log(Japanese[ii]);
						restaurants[ii].childText.text = _Japanese[ii];
						break;
				}
			}

			actives.Clear();
		}
	}
}
