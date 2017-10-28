using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public Slider slider;
	public int startingHealth = 100;

	private int currentHealth;


	// Use this for initialization
	void Start () {
		
		currentHealth = startingHealth;
		slider.value = currentHealth;
	}


	public void takeDamage(int ammount)
	{
		currentHealth -= ammount;
		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			dead ();
		}

		slider.value = currentHealth;

	}

	void dead()
	{
		slider.value = currentHealth;
		Application.LoadLevel (2);
		Destroy (gameObject, 1f);

	}
}
