using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {

	public float speed = 5f;
	public Buttons[] input;

	private Rigidbody2D body2d;
	private InputState inputState;

	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update () {

		// These are defined in the IDE
		var right = inputState.GetButtonValue (input [0]);
		var left = inputState.GetButtonValue (input [1]);

		var velX = speed;

		// Check if a key is held down
		if (right || left) {
			// One of them is held down, so can hack in -1 or 1
			velX *= left ? -1 : 1;
		} else {
			// Nothing held down (anymore?) so zero out
			velX = 0;
		}

		// Apply the velocity 
		body2d.velocity = new Vector2 (velX, body2d.velocity.y);
	}
}
