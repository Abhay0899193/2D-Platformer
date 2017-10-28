using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public GameObject Explostion;
	public int DamageCreated = 50;
	public bool IsThisHero = true;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2f);
	}
	
	void OnCollisionEnter2D(Collision2D Other)
	{
		Instantiate (Explostion, transform.position, Quaternion.identity);
		if (Other.gameObject.CompareTag ("Enemy") && IsThisHero) {
			EnemyHealth eh = Other.gameObject.GetComponent<EnemyHealth> ();
			eh.takeDamage (DamageCreated);
		}

		else if (Other.gameObject.CompareTag ("Player") && !IsThisHero)
		{
			PlayerHealth ph = Other.gameObject.GetComponent<PlayerHealth> ();
			ph.takeDamage (DamageCreated);
		}

		else if (Other.gameObject.CompareTag ("GreenWall") && IsThisHero) 
		{
			wall w = Other.gameObject.GetComponent<wall> ();
			w.DestroyWall ();
		}
		else if (Other.gameObject.CompareTag ("EnemySlug") && IsThisHero) {
			EnemySlug eh = Other.gameObject.GetComponent<EnemySlug> ();
			eh.takeDamage (DamageCreated);
		}

		Destroy (gameObject);
	}
}
