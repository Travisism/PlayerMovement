using UnityEngine;
using System.Collections;


// Helpful Names
public enum Buttons {
	Right,
	Left,
	Up,
	Down,
	A,
	B
}

// To check -1, 0, 1 in axis
public enum Condition {
	GreaterThan,
	LessThan
}

[System.Serializable]
public class InputAxisState {
	public string axisName; // Horizontal, Vertical, etc
	public float offValue; // usually 0 or near 0 for damping joystick
	public Buttons button; // The enum for which button
	public Condition condition; // If its greater than or less than 0. ex: Horizontal axis is -1 for left, 0 for off, 1 for right

	// Read only
	public bool value {
		get {
			// Get the Axis name configured in the IDE
			var val = Input.GetAxis (axisName);

			// Check to see if its currently on or off
			// It'll be on based on the -1, 0, 1 thing above
			switch (condition) {
			case Condition.GreaterThan:
				return val > offValue;
			case Condition.LessThan:
				return val < offValue;
			}

			return false;
		}
	}
}


public class InputManager : MonoBehaviour {

	public InputAxisState[] inputs;
	public InputState inputState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Loop through the inputs set in the IDE
		foreach (var input in inputs) {
			// Set the state for all the buttons
			// If any buttons are being pressed, they will be > or < 0
			// If they aren't being pressed, they will be 0
			inputState.SetButtonValue (input.button, input.value);
		}
	}
}
