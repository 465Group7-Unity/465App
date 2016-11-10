using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentSnap : MonoBehaviour
{
	public int contentSize = 40; // Height of the elements in the scrollbox.
	public ScrollRect scroll;   // Set in inspector.
	public string selectedText;

	float prevPos;
	RectTransform ourTransform;
	bool correcting = false;
	Text[] children;

	void Awake()
	{
		// Initial position will be the previous position.
		ourTransform = GetComponent<RectTransform>();
		prevPos = ourTransform.localPosition.y;
		children = GetComponentsInChildren<Text>();
		selectedText = children[0].text;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Mathf.Abs(prevPos - ourTransform.localPosition.y) < 1f && !correcting && !Input.GetMouseButton(0))
		{
			// Moving, but moving slowly. Snap to nearest number.
			scroll.velocity = Vector2.zero;
			float roundedUp = RoundUp(ourTransform.localPosition.y);
			float roundedDown = RoundDown(ourTransform.localPosition.y);
			float use = 0;

			if (Mathf.Abs(roundedUp - ourTransform.localPosition.y) < Mathf.Abs(roundedDown - ourTransform.localPosition.y))
			{
				use = roundedUp;
			}
			else
			{
				use = roundedDown;
			}

			//ourTransform.localPosition = new Vector2(ourTransform.localPosition.x, use);
			StartCoroutine(Correct(use));

			// Figure out what text we have selected now.
			selectedText = children[(int)use / contentSize].text;
		}
		prevPos = ourTransform.localPosition.y;
	}

	float RoundUp (float toRound)
	{
		return contentSize * (int)((toRound + (contentSize - 1)) / contentSize);
	}
	float RoundDown (float toRound)
	{
		return contentSize * ((int)toRound / contentSize);
	}

	IEnumerator Correct(float toPosition)
	{
		correcting = true;
		float difference = toPosition - ourTransform.localPosition.y;

		for (int ii = 0; ii < 10; ii++)
		{
			ourTransform.Translate(0, difference / 10, 0);
			yield return null;
		}
		correcting = false;
	}
}
