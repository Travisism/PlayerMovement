using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	public AudioClip explode;

	private Rigidbody2D body2d;
	public float Power;
	public float Radius;

	private GameObject player;

	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();

		player = GameObject.FindWithTag ("Player");

		Physics2D.IgnoreCollision (GetComponent<BoxCollider2D> (), player.GetComponent<CircleCollider2D> ());

		StartCoroutine (ExplodeAfterDelay ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ExplodeAfterDelay() {
		yield return new WaitForSeconds (4);

//		Vector3 mousePos = Input.mousePosition;
//		mousePos.z = 10;
//		Vector3 objPos1 = Camera.main.ScreenToWorldPoint(mousePos);
		AddExplosionForce(player.GetComponent<Rigidbody2D>(), Power * 100, body2d.transform.position, Radius);

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = explode;

		audio.Play ();

		Destroy (gameObject);
	}

	public static void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
	{
		var dir = (body.transform.position - expPosition);
		float calc = 1 - (dir.magnitude / expRadius);
		if (calc <= 0) {
			calc = 0;		
		}

		body.AddForce (dir.normalized * expForce * calc);

		Debug.Log ("Exploded");
	}
}
