using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour {

	[SerializeField] private float dashSpeed = 20f;
	[SerializeField] private float dashTimeMax = 1f;
	[SerializeField] private float dashCost = 3f;
	private float dashTime;
	private bool isDashing;

	private CharacterPawn owner;

	void Awake() {
		owner = GetComponent<CharacterPawn> ();
	}
	
	void Update () {
		if (dashTime > 0) {
			dashTime -= Time.deltaTime;
		} else if (isDashing) {
			owner.RemoveMoveSpeed(dashSpeed);
			isDashing = false;
		}
	}

	public void StartDash() {
		isDashing = true;
		dashTime = dashTimeMax;
		owner.AddMoveSpeed(dashSpeed);
		owner.GetStamina().ConsumeStamina(dashCost);
	}

	public bool CanDash() {
		if (owner.GetStamina ().GetStamina () > dashCost) {
			return true;
		}
		return false;
	}

	public bool IsDashing() {
		return isDashing;
	}
}
