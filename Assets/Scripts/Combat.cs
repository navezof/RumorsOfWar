using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combat : MonoBehaviour {
	[SerializeField] private List<Combo> combos = new List<Combo> ();
	private CharacterPawn pawn;

	void Awake() {
		pawn = GetComponentInParent<CharacterPawn> ();
	}

	void Update() {
	}

	public void Attack(int comboType) {
		if (combos[comboType].CanAttack()) {
			combos[comboType].StartAttack();
		}
	}
}
