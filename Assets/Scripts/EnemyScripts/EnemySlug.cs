using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlug : MonoBehaviour {

	public Sprite deadEnemy;	
	public AudioClip[] deathClips;	
	public float deathSpinMin = -100f;	
	public float deathSpinMax = 100f;
	public int currentHealth = 50;
	public float timing = 3f;

	private SpriteRenderer ren;	
	private bool dead = false;		
	private Animator anim;

	// Use this for initialization
	void Start () {
		ren = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}
	
	public void takeDamage(int ammount)
	{
		currentHealth -= ammount;
		if (currentHealth <= 0) {
			currentHealth = 0;
			Death ();
		}
	}

	void Update()
	{
		if (dead) 
		{
			Invoke ("DeadEffect", timing);
		}
	}

	void Death()
	{
		anim.enabled = false;
		// Find all of the sprite renderers on this object and it's children.
		SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();

		// Disable all of them sprite renderers.
		foreach(SpriteRenderer s in otherRenderers)
		{
			s.enabled = false;
		}

		// Re-enable the main sprite renderer and set it's sprite to the deadEnemy sprite.
		ren.enabled = true;
		ren.sprite = deadEnemy;

		// Increase the score by 100 points
		//score.score += 100;

		// Set dead to true.
		dead = true;

		// Allow the enemy to rotate and spin it by adding a torque.
		GetComponent<Rigidbody2D>().fixedAngle = false;
		GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin,deathSpinMax));

		// Find all of the colliders on the gameobject and set them all to be triggers.
		Collider2D[] cols = GetComponents<Collider2D>();
		foreach(Collider2D c in cols)
		{
			c.isTrigger = true;
		}

		// Play a random audioclip from the deathClips array.
		int i = Random.Range(0, deathClips.Length);
		AudioSource.PlayClipAtPoint(deathClips[i], transform.position);

		// Create a vector that is just above the enemy.
		//Vector3 scorePos;
	//	scorePos = transform.position;
		//scorePos.y += 1.5f;

		// Instantiate the 100 points prefab at this point.
		//Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
	}

	void DeadEffect()
	{
		Destroy (gameObject);
	}
}
