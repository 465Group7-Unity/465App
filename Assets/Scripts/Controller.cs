using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{
	// Store every screen. Set in inspector.
	public GameObject[] screens;

	public static string currentScreen = "";

	float pendingTime = 0f;

	// Use this for initialization
	void Start()
	{
		foreach (GameObject ii in screens)
		{
			//ii.transform.localScale = Vector3.zero;
			ii.SetActive(false);
		}
		SwitchToScreen(0);
	}

	// Update is called once per frame
	void Update()
	{
		// For going past pending screen.
		if (currentScreen == "PendingScreenBG")
		{
			pendingTime += Time.deltaTime;
			// If we've waited long enough and there is a matching user, go to the match screen.
			if (pendingTime > 5f && checkForMatch() != null)
			{
				SwitchToScreen(4);
				pendingTime = 0f;
			}
			if (checkForMatch() == null)
			{
				currentScreen = "PendingScreenBG Fail";
			}
		}

		// For quitting.
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	User checkForMatch()
	{
		foreach (User ii in DataGrabber.users)
		{
			if (ii.MatchesWithUser())
			{
				DataGrabber.matched = ii;
				return ii;
			}
		}
		return null;
	}

	public void SwitchToScreen(int idx)
	{
		DisableAllScreens();
		EnableScreen(idx);
		currentScreen = screens[idx].name;
	}

	void DisableAllScreens()
	{
		foreach (GameObject ii in screens)
		{
			ii.SetActive(false);
			/*
			if (ii.transform.localScale != Vector3.zero)
				StartCoroutine(ScaleDown(ii));
			*/
		}
	}

	void EnableScreen(int idx)
	{
		screens[idx].SetActive(true);
		/*
		if (screen.transform.localScale != Vector3.one)
			StartCoroutine(ScaleUp(screen));
		*/
	}

	IEnumerator ScaleDown(GameObject toScale)
	{
		for (int ii = 0; ii < 10; ii++)
		{
			/*
			if (toScale.transform.localScale == Vector3.zero)
			{
				ii--;
				yield return null;
			}
			*/
			Vector3 initial = toScale.transform.localScale;
			toScale.transform.localScale = new Vector3(initial.x - 0.1f, initial.y - 0.1f, initial.z - 0.1f);
			yield return null;
		}
	}

	IEnumerator ScaleUp(GameObject toScale)
	{
		for (int ii = 0; ii < 10; ii++)
		{
			/*
			if (toScale.transform.localScale == Vector3.one)
			{
				ii--;
				yield return null;
			}
			*/
			Vector3 initial = toScale.transform.localScale;
			toScale.transform.localScale = new Vector3(initial.x + 0.1f, initial.y + 0.1f, initial.z + 0.1f);
			yield return null;
		}
	}
}
