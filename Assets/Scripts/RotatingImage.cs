using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotatingImage : MonoBehaviour
{
	Image ourImage;
	float oldSign = 1;

	// Use this for initialization.
	void Start ()
	{
		ourImage = GetComponent<Image>();
	}

	// FixedUpdate is called 60 times per second.
	void FixedUpdate()
	{
		transform.localScale = new Vector2(Mathf.Sin(5 * Time.time), 1f);
		if (Mathf.Sign(transform.localScale.x) != oldSign)
		{
			//Debug.Log("FLIP");
			ourImage.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}
		oldSign = Mathf.Sign(transform.localScale.x);
	}
}
