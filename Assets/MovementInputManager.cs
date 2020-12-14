///////////////
///name: Thomas Allen
///Date: 11/12/2020
///desc: Takes player input and passes them to the movement script
///Credit: Shell taken from a Brackeys tutorail, was then later gutted and modified
//////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MovementInputManager : MonoBehaviour
{
	//movement script to pass input to
	public Movement controller;

	public float speed = 40f; //how fast the player moves

	public float XMovement = 0f; //horizontal movement axis
	public bool jump = false; //wether or not to jump

	Respawn isDead; // Respawn sccript
	public void Start()
	{
		isDead = gameObject.GetComponent<Respawn>(); //get the respawn script

	}
	// Update is called once per frame
	void Update()
	{
		if (!isDead.dead) //make sure the player is not dead
		{
			XMovement = Input.GetAxisRaw("Horizontal") * speed; // Use defualt unity inputs to get the player's X movement input

			//check if the player wants to jump
			if (Input.GetKeyDown(KeyCode.W))
			{
				jump = true; 
			}
		}
		
	}
    void FixedUpdate()
    {
		// Move our character
		controller.movePlayer(XMovement * Time.deltaTime, jump); //pass inputs to Movement script method
		//reset jump
		jump = false;
	}
}