using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	[SerializeField] private bool isBlocking;

	private CharacterPawn owner;

	void Awake() {
		owner = GetComponent<CharacterPawn> ();
	}

	public void StartBlock() {
		isBlocking = true;
	}

	public void StopBlock() {
		isBlocking = false;
	}

	public bool CanBlock() {
		return true;
	}

	public bool IsBlocking() {
		return isBlocking;
	}
}
