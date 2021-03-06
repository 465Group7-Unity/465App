﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class DataGrabber : MonoBehaviour
{
	// All important data can be found here. Set in inspector.
	// Main screen.
	public ContentSnap start_time_hour_data;
	public ContentSnap start_time_minute_data;
	public ContentSnap start_time_ampm_data;

	public ContentSnap end_time_hour_data;
	public ContentSnap end_time_minute_data;
	public ContentSnap end_time_ampm_data;

	// Settings screen.
	public ContentSnap radius_data;
	public ContentSnap price_data;
	public ToggleButton[] cuisine_data;
	public ContentSnap gender_data;
	public ContentSnap age_data;
	public ContentSnap push_notifications_data;
	// plus static versions of settings for cheaty access...
	public static ContentSnap radius_data_s;
	public static ContentSnap price_data_s;
	public static ToggleButton[] cuisine_data_s;
	public static ContentSnap gender_data_s;
	public static ContentSnap age_data_s;

	// Match Screen
	public ToggleButton[] chosen_places_data;

	// Places where data needs to be sent. Set in inspector.
	// Main screen.
	public Text radius;
	public Text price;
	public Text cuisine;
	public Text gender;
	public Text age;

	// Match screen.
	public Text name_match;
	public Text time_match;
	public Text[] places;
	public Image match_image;

	// Match Locked screen.
	public Text meet_text;
	public Text time_locked;
	public Text place;
	public Text address;
	public Text city;
	public Image lock_image;

	// Other things.
	// The user we have matched with.
	public static User matched = null;

	// Fake user data.
	// Pickier users should be higher up in this list.
	public static User[] users = new User[] 
	{
        new User(
		"Bob Smith",				// Name
		"d_male",						// Picture path
		"3",						// Distance
		"10",						// Price range
		new string[] {"American,Italian"},	// Array of cuisine types
		"Male",						// Gender
		"2"),						// Age difference

        new User(
		"Alice Smith",				// Name
		"d_female",						// Picture path
		"3",						// Distance
		"15",						// Price range
		new string[] {"Mexican"},	// Array of cuisine types
		"Female",						// Gender
		"3"),						// Age difference

        new User(
		"Joe Smith",				// Name
		"face1",						// Picture path
		"3",						// Distance
		"20",						// Price range
		new string[] {"Japanese"},	// Array of cuisine types
		"Male",						// Gender
		"4"),						// Age difference

        new User(
		"Dan Smith",				// Name
		"face2",						// Picture path
		"3",						// Distance
		"25",						// Price range
		new string[] {"Japanese, Chinese"},	// Array of cuisine types
		"Male",						// Gender
		"5"),						// Age difference

        new User(
		"Tony Smith",				// Name
		"face3",						// Picture path
		"3",						// Distance
		"10",						// Price range
		new string[] {"American, Indian, Italian"},	// Array of cuisine types
		"Male",						// Gender
		"1"),						// Age difference

        new User(
		"Sam Smith",				// Name
		"face4",						// Picture path
		"3",						// Distance
		"5",						// Price range
		new string[] {"Japanese"},	// Array of cuisine types
		"Male",						// Gender
		"2"),						// Age difference

        new User(
		"David Smith",				// Name
		"face5",						// Picture path
		"3",						// Distance
		"15",						// Price range
		new string[] {"American, Chinese"},	// Array of cuisine types
		"Male",						// Gender
		"3"),						// Age difference

        new User(
		"Chris Smith",				// Name
		"face6",						// Picture path
		"3",						// Distance
		"20",						// Price range
		new string[] {"Indian, American"},	// Array of cuisine types
		"Male",						// Gender
		"4"),						// Age difference

         new User(
		"Emily Smith",				// Name
		"d_female",						// Picture path
		"25",						// Distance
		"10",						// Price range
		new string[] {"Chinese"},	// Array of cuisine types
		"Female",						// Gender
		"5")						// Age difference
	};

	// Use this for initialization
	void Start ()
	{
		radius_data_s = radius_data;
		price_data_s = price_data;
		cuisine_data_s = cuisine_data;
		gender_data_s = gender_data;
		age_data_s = age_data;
}
	
	// Update is called once per frame
	void Update ()
	{
		// Keep all text up to date.
		radius.text = "Radius:	" + radius_data.selectedText;
		price.text = "Price:	" + price_data.selectedText;

		string cuis = "";
		foreach (ToggleButton ii in cuisine_data)
		{
			if (ii.toggled)
			{
				cuis += ii.GetComponentInChildren<Text>().text + ", ";
			}
		}
		if (cuis != "")
		{
			StringBuilder cuis2 = new StringBuilder(cuis);
			cuis2[cuis.LastIndexOf(',')] = ' ';
			cuisine.text = "Cuisine:	" + cuis2;
		}
		else
		{
			cuisine.text = "Cuisine:	";
		}

		gender.text = "Gender Preference:	" + gender_data.selectedText;
		age.text = "Age Preference:	+/- " + age_data.selectedText;

		time_match.text = start_time_hour_data.selectedText + ":" + start_time_minute_data.selectedText + " " + start_time_ampm_data.selectedText;
		time_locked.text = start_time_hour_data.selectedText + ":" + start_time_minute_data.selectedText + " " + start_time_ampm_data.selectedText;


		// This data comes from whatever person you're matched to.
		if (matched != null)
		{
			match_image.sprite = Resources.Load<Sprite>(matched.picture_path);
			lock_image.sprite = Resources.Load<Sprite>(matched.picture_path);
			name_match.text = matched.name;
			meet_text.text = "Meet " + matched.name + "!";
		}

		// This data comes from the places you have selected.
		place.text = "Potential Location 1";
		foreach(ToggleButton ii in chosen_places_data)
		{
			if (ii.toggled)
			{
				place.text = ii.GetComponentInChildren<Text>().text;
				break;
			}
		}
	}
}

public class User
{
	public string name;             // Their name which will show up in the app.
	public string picture_path;     // The path to their profile picture.
	public string distance_to_you;  // Their distance to the app user. Used for radius.
	public string price_range;      // Their price range. Should be equal or less than yours.
	public string[] cuisine;        // List of their preferred cuisine types.
	public string gender;           // Their gender, used in gender preference of user.
	public string age_range;        // How far away they are from the app user's age.

	public User(string new_name, string new_picpath, string new_dist, string new_price, string[] new_cuisine, string new_gender, string new_age_range)
	{
		name = new_name;
		picture_path = new_picpath;
		distance_to_you = new_dist;
		price_range = new_price;
		cuisine = new_cuisine;
		gender = new_gender;
		age_range = new_age_range;
	}

	public bool MatchesWithUser()
	{
		// Check distance.
		int myDist = int.Parse(distance_to_you);
		int yourDist = int.Parse(DataGrabber.radius_data_s.selectedText);

		if (myDist > yourDist)
			return false;

		// Check price.
		int myPrice = int.Parse(price_range);
		int yourPrice = int.Parse(DataGrabber.price_data_s.selectedText);

		if (myPrice > yourPrice)
			return false;

		// Check cuisine.
		bool okay = false;
		string cuisineList = "";
		foreach (string ii in cuisine)
		{
			cuisineList += ii;
		}
		//Debug.Log(cuisineList);

		foreach (ToggleButton ii in DataGrabber.cuisine_data_s)
		{
			if (ii.toggled)
			{
				if (cuisineList.Contains((ii.GetComponentInChildren<Text>().text)))
				{
					okay = true;
				}
			}
		}

		if (!okay)
			return false;

		// Check gender.
		if (DataGrabber.gender_data_s.selectedText != "N/A")
		{
			if (DataGrabber.gender_data_s.selectedText != gender)
				return false;
		}

		// Check age.
		int myAge = int.Parse(age_range);
		int yourAge = int.Parse(DataGrabber.age_data_s.selectedText);

		if (yourAge < myAge)
		{
			return false;
		}

		// We're good!
		return true;
	}
}