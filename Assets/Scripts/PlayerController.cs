using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private CharacterPawn pawn;

	private Combat combat;
	private Dash dash;
	private Block block;
	private PersonaManager personaManager;

	private bool bJump;

	private float horizontal;

	void Awake() {
		pawn = GetComponent<CharacterPawn> ();
		dash = GetComponent<Dash> ();
		block = GetComponent<Block> ();
		personaManager = GetComponent<PersonaManager> ();
	}
	
	// Update is called once per frame
	private void Update () {
		if (!bJump) {
			bJump = Input.GetButtonDown("Jump");
		}
		if (Input.GetButtonDown("Fire1")) {
			pawn.GetPersonaManager().GetCurrentPersona().Attack(0);
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (dash.CanDash()) {
				dash.StartDash();
			}
		}
		if (Input.GetKey (KeyCode.LeftControl)) {
			if (block.CanBlock ()) {
				block.StartBlock ();
			}
		} else {
			block.StopBlock();
		}
		if (Input.GetKeyDown ("r")) {
			if (personaManager.CanChange ())
				personaManager.ChangePersona (false);
		}
		if (Input.GetKeyDown ("t")) {
			if (personaManager.CanChange ())
				personaManager.ChangePersona (true);
		}
	}

	private void FixedUpdate() {
		horizontal = Input.GetAxis ("Horizontal");
		pawn.Move (horizontal, bJump);
		bJump = false;
	}
}
