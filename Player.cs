public class Player : MonoBehaviour {

	private Rigidbody2D myRigidbody2D;

	public float moveSpeed;
	public float jumpSpeed;

	private Animator anim;

	private bool grounded;

	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundDistance;

	void Start () {

		//Find the character and apply the animations and commands
		myRigidbody2D = GetComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();
	}

	void Update () {

		//Move Doggo Left (LEFT ARROW)
		if(Input.GetKey(KeyCode.LeftArrow)){
			myRigidbody2D.velocity = new Vector2(-moveSpeed,myRigidbody2D.velocity.y);
		}

		//Move Doggo Right (RIGHT ARROW)
		else if (Input.GetKey(KeyCode.RightArrow)){
			myRigidbody2D.velocity = new Vector2(moveSpeed, myRigidbody2D.velocity.y);
		}

		//Stationary Doggo --> let sleeping dogs lie
		//y still has component for jump case
		else{
			myRigidbody2D.velocity = new Vector2(0f, myRigidbody2D.velocity.y);
		}

		//Can Adjust speed in Unity Window for conditional
		anim.SetFloat("Speed", Mathf.Abs( myRigidbody2D.velocity.x));

		//Inverted Controls case:
		if(myRigidbody2D.velocity.x < 0){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		//Regular case
		else if(myRigidbody2D.velocity.x > 0){
			transform.localScale = new Vector3(1f,1f,1f);
		}

		//JUMP CONTROLS: (SPACEBAR TO JUMP)
		if(Input.GetKeyDown(KeyCode.Space)){
			myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpSpeed);
		}

		//MAKE sure doggo hits ground and jumping goes smoothly:
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, whatIsGround);
		anim.SetBool("Jump", !grounded);
	}
}
