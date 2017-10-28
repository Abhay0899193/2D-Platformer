using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchs : MonoBehaviour {


	public Playermovement PM;

	public void moveRight()
	{
		PM.move (1);
	}

	public void moveLeft()
	{
		PM.move (-1);
	}


	public void Jump()
	{
		if (PM.grounded == true) {
			PM.playerJump ();
		}

	}

	public void Unpressed()
	{
		PM.move (0);
	}

	public void Shoot()
	{
		PM.Shoot ();
	}
}
