using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	[SerializeField] private int power;
	[SerializeField] private int cost;
	[SerializeField] private float range;
	[SerializeField] private float radius;

	private Stamina stamina;
	private Health targetHealth;
	private CharacterPawn pawn;

	public string sentence;

	public GameObject target1;
	public GameObject target2;

	void Awake() {
		pawn = GetComponentInParent<CharacterPawn> ();
		stamina = GetComponentInParent<Stamina> ();
	}

	public bool CanUse() {
		if (stamina.GetStamina () > cost) {
			return true;
		}
		Debug.Log ("Not enough stamina for " + this.name);
		return false;
	}

	void Update() {
		if (pawn.IsFacingRight ()) {
			Debug.DrawLine (transform.position, (transform.position + transform.right * 2));
		} else {
			Debug.DrawLine (transform.position, (transform.position + -transform.right * 2));
		}
	}

	public void UseAttack() {
		Debug.Log (sentence);
		RaycastHit2D[] hits = Physics2D.RaycastAll (transform.position, (pawn.IsFacingRight() ? transform.right * range : -transform.right * range), range);
		for (int i = 0; i < hits.Length; i++) {
			if ((hits[i].collider.gameObject != pawn.gameObject) && (targetHealth = hits[i].collider.GetComponent<Health>()) != null) {
				targetHealth.TakeDamage(pawn.gameObject, power);
			}
		}
		stamina.ConsumeStamina (cost);
	}
}
