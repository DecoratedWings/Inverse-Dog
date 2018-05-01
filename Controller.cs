using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour{


public float moveSpeed;
public float jumpSpeed;
	private bool grounded;


	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundDistance;

private Animator anim;

private Rigidbody2D myRigidbody2D; 



void Start () {

	//Find the character and apply the animations and commands
	myRigidbody2D = GetComponent<Rigidbody2D>();

	anim = GetComponent<Animator>();


}

void Update () {

		bool moveLeft = Input.GetKey(KeyCode.LeftArrow);
		bool moveRight = Input.GetKey(KeyCode.RightArrow);

	float moveHorizontal = Input.GetAxis ("Horizontal");
	float moveVertical = Input.GetAxis ("Vertical");

	Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
	
	
	myRigidbody2D.AddForce (movement * moveSpeed);

		//Inverted Controls case: 
		if (moveLeft) {
			myRigidbody2D.MoveRotation (myRigidbody2D.rotation + moveSpeed * Time.deltaTime);
		} 

		else if (moveRight) {
			myRigidbody2D.MoveRotation (myRigidbody2D.rotation + moveSpeed * Time.deltaTime);
		}

		//JUMP CONTROLS: (SPACEBAR TO JUMP)
		if(Input.GetKeyDown(KeyCode.Space)){
			myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpSpeed);
			anim.SetTrigger ("Jump");
			StartCoroutine ("wait");
			//anim.ResetTrigger ("Jump");
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)){
			anim.ResetTrigger ("Jump");
		}

	anim.SetFloat("Speed", Mathf.Abs( myRigidbody2D.velocity.x));
	

		//MAKE sure doggo hits ground and jumping goes smoothly:
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, whatIsGround);
		anim.SetBool("Jump", !grounded);
	}

	IEnumerator wait(){

		yield return new WaitForSeconds (1);
		Debug.Log ("Wait done successfully");
		anim.ResetTrigger ("Jump");

	}

		
}
