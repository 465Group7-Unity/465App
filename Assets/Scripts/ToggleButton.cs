using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleButton : MonoBehaviour
{
	public bool toggled = false;

	Button ourButton;
	Image ourButtonImage;

	// Use this for initialization
	void Start ()
	{
		ourButton = GetComponent<Button>();
		ourButtonImage = GetComponent<Image>();
		ourButton.onClick.AddListener(() =>
		{
			if (toggled)
			{
				ourButtonImage.color = Color.white;
			}
			else
			{
				ourButtonImage.color = Color.green;
			}
			toggled = !toggled;
		});
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
