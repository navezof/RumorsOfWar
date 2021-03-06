﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Block))]
public class Stamina : MonoBehaviour {

	public Texture2D barEmpty;
	public Texture2D barFull;
	public float display;

	private Block block;

	private float stamina;
	[SerializeField] private float staminaMax;
	[SerializeField] private float staminaRecoveryRate;

	public Vector2 size;
	public Vector2 addedPosition;
	private Vector2 barPosition;

	public float GetStamina() {
		return stamina;
	}
	
	public float GetStaminaMax() {
		return staminaMax;
	}

	void Awake() {
		block = GetComponent<Block> ();
	}

	void Update () {
		Regen ();
		display = ((stamina * 100) / staminaMax) / 100;
	}

	void Regen() {
		if (!block.IsBlocking() && stamina <= staminaMax) {
			stamina += staminaRecoveryRate * Time.deltaTime;
		}
	}

	public void ConsumeStamina(float staminaValue) {
		stamina -= staminaValue;
		if (stamina <= 0) {
			stamina = 0;
		}
	}

	public void RecoverStamina(float staminaValue) {
		stamina += staminaValue;
		if (stamina > staminaMax) {
			stamina = staminaMax;
		}
	}

	public void OnGUI() {
		// draw the background:
		barPosition = Camera.main.WorldToScreenPoint (transform.position);
		
		GUI.BeginGroup (new Rect (barPosition.x + addedPosition.x, barPosition.y + addedPosition.y, size.x, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y),barEmpty);
		
		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * display, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y),barFull);
		GUI.EndGroup ();
		
		GUI.EndGroup (); 
	}
}
