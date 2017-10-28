using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;

	//public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public GM gm;

	[SerializeField] private LayerMask m_WhatIsGround; 
	public bool grounded;
	private Animator anim;
	private Rigidbody2D rb;
	private float h;


	public Transform firePosition1;

	public float fireCooldown = 0.5f;
	public GameObject bullet;
	public float force = 10f;

	private bool canShoot = false;
	private float timer = 0f;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	
	// Update is called once per frame
	void Update () {
		
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, .01f, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				grounded = true;
		}
		anim.SetBool("Ground", grounded);
		if (Input.GetButtonDown ("Jump"))
			playerJump ();
		
		timer += Time.deltaTime;
		if (timer >= fireCooldown) 
		{
			timer = 0f;
			canShoot = true;

		}
	}

	void FixedUpdate()
	{
		#if UNITY_STANDALONE || UNITY_EDITOR
		move (Input.GetAxis ("Horizontal"));
		#endif
		anim.SetFloat ("Speed", Mathf.Abs (h));
		//if (h * rb.velocity.x < maxSpeed)
		//	rb.AddForce (Vector2.right * h * moveForce);
	//	if (h * rb.velocity.x > maxSpeed)
		//	rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
		rb.velocity = new Vector2(h*maxSpeed, rb.velocity.y);
		if (h > 0 && !facingRight)
			flip ();
		else if (h < 0 && facingRight)
			flip ();
		if (jump) 
		{
			jump = false;
			anim.SetBool("Ground", false);
			rb.AddForce (new Vector2 (0f, jumpForce));
			//jump = false;
		}
		if (Input.GetButtonDown ("Fire1") && canShoot) 
		{
			Shoot ();
		}
	}
	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public void move(float hori)
	{
		h = hori;
	}
	public void playerJump()
	{
		if (grounded && anim.GetBool ("Ground")) {
			grounded = false;
			jump = true;
			//grounded = false;
		}
			
	}
	public void Shoot()
	{
		if (gm.powerLevel > 0f) {
			canShoot = false;

			GameObject B;
			B = (GameObject)Instantiate (bullet, firePosition1.position, firePosition1.rotation);
			Rigidbody2D Brb = B.GetComponent<Rigidbody2D> ();
			if (facingRight) {
				Brb.AddForce (new Vector2 (1, 0) * force, ForceMode2D.Impulse);
			} else if (!facingRight) {
				Brb.AddForce (new Vector2 (-1, 0) * force, ForceMode2D.Impulse);
			}
		} else
			return;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("MovingPlatform"))
		{
			gameObject.transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("MovingPlatform"))
		{
			gameObject.transform.parent = null;
		}
	}
}
