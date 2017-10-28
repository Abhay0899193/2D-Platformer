using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
	public float fadeSpeed = 1.5f;			// Speed that the screen fades to and from black.

	public float invokeTime = 2f;


	private bool sceneStarting = true;		// Whether or not the scene is still fading in.
	private Image img;
	private Color startingColor;


	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		//GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);

		img = GetComponent<Image> ();
	
	}

	void Start()
	{
		startingColor = img.color;
	}

	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			Invoke("StartScene",invokeTime);
		//	StartScene();
	}


	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		//GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);

		img.color = Color.Lerp(img.color, Color.clear, fadeSpeed * Time.deltaTime);

	}


	public void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		//GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
		img.enabled = true;
		img.color = Color.Lerp(img.color, startingColor, fadeSpeed * Time.deltaTime);


	}


	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();

		// If the texture is almost clear...
		/*if(GetComponent<GUITexture>().color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;

			// The scene is no longer starting.
			sceneStarting = false;
		}*/

		if(img.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			img.color = Color.clear;
			img.enabled = false;

			// The scene is no longer starting.
			sceneStarting = false;
		}

	}


	public void EndScene ()
	{
		// Make sure the texture is enabled.
		//GetComponent<GUITexture>().enabled = true;

		img.enabled = true;

		// Start fading towards black.
		//FadeToBlack();

		// If the screen is almost black...
		//if(GetComponent<GUITexture>().color.a >= 0.95f)
			// ... reload the level.

		if(img.color.a >= 0.95f)
					Application.LoadLevel(0);
	}
}
