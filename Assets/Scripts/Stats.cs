using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	[SerializeField] private int power;
	[SerializeField] private int defense;

	public int GetPower() {
		return power;
	}

	public int GetDefense() {
		return defense;
	}

	public void AddStats(Stats statsToAdd) {
		power += statsToAdd.power;
		defense += statsToAdd.defense;
	}

	public void RemoveStats(Stats statsToRemove) {
		power -= statsToRemove.power;
		defense -= statsToRemove.defense;
	}
}
