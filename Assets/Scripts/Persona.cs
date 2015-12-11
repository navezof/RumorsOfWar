using UnityEngine;
using System.Collections;

public class Persona : MonoBehaviour {

	private Stats stats;
	private Combat combat;

	public void Awake() {
		stats = GetComponent<Stats> ();
		combat = GetComponent<Combat> ();
	}

	public void Equip (CharacterPawn pawn) {
		Debug.Log ("Persona : " + name + " equiped");
		pawn.GetStats ().AddStats (stats);
	}
	
	public void UnEquip (CharacterPawn pawn) {
		Debug.Log ("Persona : " + name + " unequiped");
		pawn.GetStats ().RemoveStats (stats);
	}

	public void Attack(int comboType) {
		combat.Attack (comboType);
	}
}
