using UnityEngine;
using System.Collections;

public class DebugControl : MonoBehaviour {

	public GameObject player;

	public void OnGUI() {
		if (GUI.Button(new Rect(10, Screen.height - 30, 70, 30), "damage player")) {
			player.GetComponent<Health>().TakeDamage(this.gameObject, 1);
		}
		if (GUI.Button(new Rect(90, Screen.height - 30, 70, 30), "heal player")) {
			player.GetComponent<Health>().HealDamage(this.gameObject, 1);
		}
		if (GUI.Button(new Rect(160, Screen.height - 30, 70, 30), "kill player")) {
			player.GetComponent<Health>().Die();
		}
	}
}
