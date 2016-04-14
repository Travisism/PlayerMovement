using UnityEngine;
using System.Collections;

public class ThrowConc : AbstractBehavior {

	public GameObject concPrefab;


	private Grenade conc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var fire = inputState.GetButtonValue (inputButtons [0]);

		if (conc == null && fire) {
			Vector3 mousePos = Input.mousePosition;
			Vector3 grenadePos = Camera.main.ScreenToWorldPoint (mousePos);
			grenadePos.z = -5;

			Debug.Log (grenadePos);

			conc = Instantiate (concPrefab, grenadePos, Quaternion.identity) as Grenade;



			Debug.Log ("Created thing");
		}
	}
}
