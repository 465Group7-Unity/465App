using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleButton : MonoBehaviour
{
	public bool toggled = false;
	public string title;
	public Text childText;

	Button ourButton;
	Image ourButtonImage;
	Color ourButtonInitialColor;

	// Use this for initialization
	void Start ()
	{
		ourButton = GetComponent<Button>();
		ourButtonImage = GetComponent<Image>();
		ourButtonInitialColor = ourButtonImage.color;
		ourButton.onClick.AddListener(() =>
		{
			if (toggled)
			{
				ourButtonImage.color = ourButtonInitialColor;
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
