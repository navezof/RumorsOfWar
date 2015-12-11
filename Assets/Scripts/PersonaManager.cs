using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonaManager : MonoBehaviour {

	[SerializeField] List<Persona> personas = new List<Persona>();

	private CharacterPawn owner;

	public int personaIndex;

	void Awake() {
		owner = GetComponent<CharacterPawn> ();
	}
	
	public Persona GetCurrentPersona() {
		return personas [personaIndex];
	}

	public bool CanChange() {
		if (owner.GetStamina ().GetStamina () >= owner.GetStamina ().GetStaminaMax () / 2) {
			return true;
		} else {
			Debug.LogError("Not enough stamina to change persona");
		}
		return false;
	}

	public void ChangePersona( bool next) {
		personas[personaIndex].UnEquip(owner);
		if (next) {
			personaIndex++;
			if (personaIndex >= personas.Count) {
				personaIndex = 0;
			}
		} else {
			personaIndex--;
			if (personaIndex < 0) {
				personaIndex = personas.Count - 1;
			}
		}
		personas[personaIndex].Equip(owner);
		owner.GetStamina ().ConsumeStamina (owner.GetStamina ().GetStaminaMax () / 2);
	}
}
