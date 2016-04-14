using UnityEngine;
using System.Collections;

public class ThrowConc : AbstractBehavior {

	public GameObject concPrefab;

	private bool canThrowConc = true;
	private float timeSinceLastLaunch = 0f;
	private GameObject conc;

	// Use this for initialization
	void Start () {
		Debug.Log ("Started thing");
	}
	
	// Update is called once per frame
	void Update () {
		var fire = inputState.GetButtonValue (inputButtons [0]);

		if (canThrowConc && fire) {
			Vector3 mousePos = Input.mousePosition;
			Vector3 grenadePos = Camera.main.ScreenToWorldPoint (mousePos);
			grenadePos.z = -5;

			Debug.Log (grenadePos);

			conc = Instantiate (concPrefab, grenadePos, Quaternion.identity) as GameObject;
			canThrowConc = false;
		}

		if (conc) {
			timeSinceLastLaunch += Time.deltaTime;

			if (timeSinceLastLaunch > 1f) {
				conc = null;
				canThrowConc = true;
				timeSinceLastLaunch = 0f;
				print ("can throw again");
			}
		}
	}
}
