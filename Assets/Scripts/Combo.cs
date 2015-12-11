using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combo : MonoBehaviour {
	[SerializeField] List<Attack> combo = new List<Attack>();
	[SerializeField] float comboChainDuration;
	[SerializeField] float comboChainDurationMax;
	[SerializeField] int comboIndex;

	public bool CanAttack() {
		return combo [comboIndex].CanUse ();
	}

	public void StartAttack() {
		combo [comboIndex].UseAttack ();
		comboIndex++;
		if (comboIndex >= combo.Count) 
			comboIndex = 0;
		comboChainDuration = comboChainDurationMax;
	}

	void Update() {
		if (comboChainDuration > 0) {
			comboChainDuration -= Time.deltaTime;
		} else {
			comboIndex = 0;
		}
	}
}
