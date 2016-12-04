using UnityEngine;
using System.Collections;

public class SlidingImage : MonoBehaviour
{
	float InitialPosition;

	// Use this for initialization
	void Start () {
		InitialPosition = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position = new Vector2(400 * Mathf.Sin(0.33f * Time.time), transform.position.y);
	}
}
