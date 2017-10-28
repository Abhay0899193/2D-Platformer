using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public Slider slider;
	public int startingHealth = 100;

	private int currentHealth;
	private float timer = 0f;

	// Use this for initialization
	void Start () {
		slider.gameObject.SetActive (false);
		currentHealth = startingHealth;
		slider.value = currentHealth;
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= 5f)
		{
			slider.gameObject.SetActive (false);
		}
	}

	public void takeDamage(int ammount)
	{
		currentHealth -= ammount;
		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			dead ();
		}
		slider.gameObject.SetActive (true);
		slider.value = currentHealth;
		timer = 0f;
	}

	void dead()
	{
		slider.value = currentHealth;
		Destroy (gameObject, 1f);
	}
}
