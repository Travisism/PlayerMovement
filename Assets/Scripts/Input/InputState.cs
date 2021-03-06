﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonState {
	public bool value;
	public float holdTime = 0;
}

public enum Directions {
	Right = 1,
	Left = -1
}

// This class gets added to the object that needs to move
public class InputState : MonoBehaviour {

	// All art must default to the right
	public Directions direction = Directions.Right;

	// FixedUpdate always tracks object velocity
	public float absVelX = 0f;
	public float absVelY = 0f;


	// Store Any Button States
	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();

	// Store local rigid body
	private Rigidbody2D body2d;

	void Awake() {
		body2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		absVelX = Mathf.Abs (body2d.velocity.x);
		absVelY = Mathf.Abs (body2d.velocity.y);
	}


	// Set the value of any key
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
