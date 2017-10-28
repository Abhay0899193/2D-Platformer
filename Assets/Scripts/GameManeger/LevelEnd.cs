using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public FadeInOut FIO;
	public float t = 1f;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			FIO.FadeToBlack ();
			Invoke ("LoadUI", t);
		}
	}
	void LoadUI()
	{
		Application.LoadLevel(1);
	}
}
