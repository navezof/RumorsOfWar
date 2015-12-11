using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

	private bool isUnbalanced;
	private bool isStaggered;

	public bool IsUnbalanced() {
		return isUnbalanced;
	}

	public bool IsStaggered() {
		return isStaggered;
	}

}
