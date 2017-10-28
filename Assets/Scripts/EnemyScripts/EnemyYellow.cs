using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellow : MonoBehaviour {

	public float coolDownTime = 2f;
	public float force = 10f;
	public GameObject bullet;
	public Transform firePosition1;

	private bool canShoot = false;
	private Transform player;
	private bool facingLeft = true;
	private bool FL = true;
	private float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;

	}

	void FixedUpdate () {
		if (!canShoot)
			return;
		if (transform.position.x > player.position.x) 
		{
			facingLeft = true;
		}
		if (transform.position.x < player.position.x) 
		{
			facingLeft = false;
		}
		if (FL != facingLeft)
		{
			flip ();
		}
		if (timer >= coolDownTime) 
		{
			timer = 0f;
			Shoot ();
		}

	}

	void OnTriggerEnter2D(Collider2D Other)
	{
		if (Other.gameObject.CompareTag ("Player")) 
		{
			
			player = Other.transform;
			canShoot = true;
		}
	}
	void OnTriggerExit2D(Collider2D Other)
	{
		if (Other.gameObject.CompareTag ("Player")) 
		{
			
			canShoot = false;
		}
	}

	void flip()
	{
		FL = !FL;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void Shoot()
	{
		GameObject B;
		B = (GameObject)Instantiate (bullet, firePosition1.position, firePosition1.rotation);
		Rigidbody2D Brb = B.GetComponent<Rigidbody2D> ();
		if (facingLeft) {
			Brb.AddForce(new Vector2(-1,0) * force, ForceMode2D.Impulse);
		} 
		else if (!facingLeft) 
		{
			Brb.AddForce(new Vector2(1,0) * force, ForceMode2D.Impulse);
		}
	}
}
