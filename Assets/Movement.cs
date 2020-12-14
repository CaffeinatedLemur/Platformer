///////////////
///name: Thomas Allen
///Date: 11/12/2020
///desc: Takes player input and passed to it and moves the player
///Credit: Shell taken from a Brackeys tutorail, was then later gutted and modified
//////////////

using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
	public float JumpForce = 400f;  //how much to jump (400 by default)                      
	public float smoothThing = .05f;  // movement smoothing


	public bool canJump;            // Whether or not the player is on the ground.
	public Rigidbody2D myRb;
	private bool DirectionFacing = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;


	// Sound manager script
	SoundPlayonEvent sound;

	//how fast you go up and down
	public float jumpVelocity;
	public float fallMultiplier = 2.5f;
	public float jumpGravity = 0.5f;


	public UnityEvent OnDash;
	//get rigidbody of player
    public void Start()
    {
		myRb = GetComponent<Rigidbody2D>();


		// Sets game object of sound source to find script on it
		GameObject soundSource = GameObject.Find("Sound Source");
		// Uses script from sound source object and sets it for use
		sound = soundSource.GetComponent<SoundPlayonEvent>();

		isDead = gameObject.GetComponent<Respawn>(); //get the respawn script

	}



    public void movePlayer(float move, bool jump)
	{
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(move * 10f, myRb.velocity.y);
		// And then smoothing it out and applying it to the character
		myRb.velocity = Vector3.SmoothDamp(myRb.velocity, targetVelocity, ref velocity, smoothThing);


		//update the direction the player is facing and flip the sprite
		if (move > 0 && !DirectionFacing)
		{
			Flip();
		}
		else if (move < 0 && DirectionFacing)
		{
			Flip();
		}
		
		//See if the player wants to jump
		if (canJump && jump)
		{

			//myRb.velocity = Vector2.up * Physics2D.gravity.y * (jumpGravity - 1) * Time.deltaTime * jumpVelocity;
			myRb.AddForce(new Vector2(0f, JumpForce));
			sound.PlaySound("Jump");
			

		}

		//update gravity on descent for a better jump feel
		if (myRb.velocity.y < 0)
		{
			myRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}

		canJump = false; //make it so that the player cannot inifnatly jump

	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		DirectionFacing = !DirectionFacing;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "canJump") //see if the player is colliding with a "ground" object
		{
			//reset booleans
			canJump = true;
			hasDashed = false;
			
			//HasJumped = false;
		}

	}

	public float dashSpeed; //how fast they dash
	public bool hasDashed; //if the palyer has already dashed
	public bool isDashing; //if the player is currently dashing
	public float currentX; //current X input
	public float CurrentY; //current Y inputs

	public float timer; //timer counting up (Unused in current iteration)
	public float duration; //duration of dash (unused in current iteration)


	public Vector2 noYSpeed; // remove Y speed of player

	Respawn isDead; // Respawn sccript

	public GameObject DashParticles; //particles for the dash

	public void Update()
	{
		currentX = Input.GetAxisRaw("Horizontal"); //get player's X input
		CurrentY = Input.GetAxisRaw("Vertical"); //get Player's Y input

		timer += Time.deltaTime; //update timer (Unused in current iteration)

		if (Input.GetButtonDown("Jump") && !hasDashed) //make sure the player has jumped
		{
			if (currentX != 0 || CurrentY != 0) //make sure the player is moving
				dash(currentX, CurrentY); //dash
			timer = 0; //reset timer (unused in current iteration)
		}

	}

	//method that makes player dash
	public void dash(float x, float y)
	{
		//make sure the player can dash
		if (!hasDashed && ! canJump && !isDead.dead)
		{
			//Update teh vector2
			noYSpeed.y = 0; 
			noYSpeed.x = 0;
			//update bools
			hasDashed = true;

			//set player velocity to 0
			myRb.velocity = Vector2.zero; 
			myRb.velocity = noYSpeed;
			//Set teh vector for player to dash
			Vector2 DashVector = new Vector2(x, y);
			DashVector.x *= dashSpeed * 2;
			DashVector.y *= dashSpeed / 1.25f;

			myRb.velocity += DashVector; //move player

			isDashing = true; // set the player to dashing

			//spawn the particles
			Instantiate(DashParticles, transform.position, Quaternion.identity);
		
		
			OnDash.Invoke(); //update unityEvent
		}
	}
}
