using UnityEngine;
using System.Collections;

public class CharacterPawn : MonoBehaviour {

	[SerializeField] private float moveSpeed = 10f;

	[SerializeField] private float blockingSpeed = .5f;
	[SerializeField] private float jumpForce = 400f;
	[SerializeField] private float jumpCost = 2;
	[SerializeField] private bool bAirControl = false;
	[SerializeField] private LayerMask groundLayer;

	private Transform groundCheck;
	const float groundedRadius = .2f;
	private bool bGrounded;

	private Rigidbody2D rigidBody;

	private bool bFacingRight = true;

	private Block block;
	private Dash dash;
	private Stamina stamina;
	private Stats stats;
	private Status status;
	private PersonaManager personaManager;

	/*******************
	 * 
	 * GETTER AND SETTER
	 * 
	 *******************/

	public Stats GetStats() {
		return stats;
	}

	public PersonaManager GetPersonaManager() {
		return personaManager;
	}

	public Status GetStatus() {
		return status;
	}

	public Stamina GetStamina() {
		return stamina;
	}

	public bool IsFacingRight() {
		return bFacingRight;
	}

	private void Awake()
	{
		groundCheck = transform.Find ("GroundCheck");
		rigidBody = GetComponent<Rigidbody2D> ();
		block = GetComponent<Block> ();
		dash = GetComponent<Dash> ();
		stamina = GetComponent<Stamina> ();
		stats = GetComponent<Stats> ();
		status = GetComponent<Status> ();
		personaManager = GetComponent<PersonaManager> ();

		personaManager.GetCurrentPersona ().Equip (this);
	}

	private void FixedUpdate()
	{
		bGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll (groundCheck.position, groundedRadius, groundLayer);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject)
				bGrounded = true;
		}
	}

	public void Move(float move, bool jump) {

		if (block.IsBlocking ()) {
			move = move * blockingSpeed;
		}
		if (bGrounded || bAirControl) {
			rigidBody.velocity = new Vector2 (move * moveSpeed, rigidBody.velocity.y);

			if (!dash.IsDashing()) {
				if (move > 0 && !bFacingRight)
				{
					Flip();
				}
				else if (move < 0 && bFacingRight)
				{
					Flip();
				}
			}

			if (bGrounded && jump) {
				Jump();
			}
		}
	}

	private void Jump() {
		bGrounded = false;
		rigidBody.AddForce (new Vector2 (0f, jumpForce));
		stamina.ConsumeStamina (jumpCost);
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		bFacingRight = !bFacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void AddMoveSpeed(float addedSpeed) {
		moveSpeed += addedSpeed;
	}

	public void RemoveMoveSpeed(float removedSpeed) {
		moveSpeed -= removedSpeed;
	}

	public void OnGUI()	{
		GUI.Label (new Rect (10, 50, 100, 20), "Persona : " + personaManager.GetCurrentPersona().name);
		GUI.Label (new Rect (10, 70, 100, 20), "Power : " + stats.GetPower());
		GUI.Label (new Rect (10, 90, 100, 20), "Defense : " + stats.GetDefense());
	}
}
