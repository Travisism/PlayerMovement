using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonState {
	public bool value;
	public float holdTime = 0;
}

public class InputState : MonoBehaviour {

	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();

	public void SetButtonValue(Buttons key, bool value) {
		// Add to dictionary if it doesn't already exist
		if (!buttonStates.ContainsKey (key))
			buttonStates.Add (key, new ButtonState ());


		// Get the button state
		var state = buttonStates [key];

		// Check if released or still down
		if (state.value && !value) {
			// Released
			state.holdTime = 0;
		} else if (state.value && value) {
			// Being held down when previously already held down
			state.holdTime += Time.deltaTime;
		}

		// Set the value for the button state
		state.value = value;
	}

	public bool GetButtonValue(Buttons key) {
		if (buttonStates.ContainsKey (key))
			return buttonStates [key].value;
		else
			return false;
	}
}
