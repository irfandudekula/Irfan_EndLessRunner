using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 direction;
	public float speed;
	private int laneposition = 1;
	public int lanedistance = 4;
	public float Jumpspeed;
	public float Gravityforce = -20;
	public Text scoretext;
	private int count;

	void Start()
	{

		count = 0;
		scoretext.text = "Score: " + count;										// at start read score as 0 and starts counting
		controller = GetComponent<CharacterController>();							// get character controller for player
	}
	
	void Update()
	{
		direction.z = speed;													// speed of player in z direction
		if (controller.isGrounded)
		{
			direction.y = -0.5f;

			if (Swiping.SwipeUp)													// if swipe in up(y direction) jump the player and add sounds
			{
				direction.y = Jumpspeed;
				Sounds.PlaySound("jump");
			}
		}
		else
		{
			direction.y += Gravityforce * Time.deltaTime;								
		}

			
		if (Swiping.SwipeRight)													// if swipe right change position accordingly
		{
			laneposition++;
			if (laneposition == 3)
			{
				laneposition = 2;
			}
		}
		if (Swiping.SwipeLeft)													// if swipe left change position accordingly
		{
			laneposition--;
			if (laneposition == -1)
			{
				laneposition = 0;
			}
		}
		Vector3 targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;
		if (laneposition == 0)
		{
			targetposition += Vector3.left * lanedistance;
		}
		else if (laneposition == 2)
		{
			targetposition += Vector3.right * lanedistance;
		}
		transform.position = targetposition;
		controller.center = controller.center;

	}
	private void FixedUpdate()																// fixedupdate is to update player direction in fised interval of time
	{
		controller.Move(direction * Time.fixedDeltaTime);
		

	}

	private void OnTriggerEnter(Collider other)											// on trigger enter
	{
		if (other.gameObject.CompareTag("coin"))
		{																				// if tag is coin then destroy it and score count increases.  
			//other.gameObject.SetActive(false);
			Destroy(other.gameObject);
			Sounds.PlaySound("coins");
		}
		count += 1;
		scoretext.text = "Score:" + count;
		if (other.gameObject.CompareTag("Healthkit"))								
		{
			other.gameObject.SetActive(false);
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.transform.tag == "enemy")												// if tag is enemy then health bar decreases by value
		{
			//Stopgame.Gameover=true;
			HealthBar.health -= 10f;
			Sounds.PlaySound("enemy");

		}
		if (hit.transform.tag == "Healthkit")                                               // if tag is healthkit, then health value increases by value
		{
			HealthBar.health += 10f;
		}
	}
}
