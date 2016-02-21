using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Rigidbody2D			rigid;
	public bool					inAir;
	public float				speed = 4.0f;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		inAir = false;
	}
	
	void Update () {
		if  ((Input.GetKeyDown ("space")) && (!inAir)) {
			transform.Translate(Vector3.up * 60 * Time.deltaTime, Space.World);
			inAir = true;
		} 
	}

	void FixedUpdate() {
		Move ();
	}

	void Move() {
		Vector3 vel_vec = Vector3.zero;
		bool w = false;
		bool a = Input.GetKey(KeyCode.A);
		bool s = Input.GetKey(KeyCode.S);
		bool d = Input.GetKey(KeyCode.D);

		vel_vec.x = a ? -1 : (d ? 1 : 0);
		vel_vec.y = s ? -1 : (w ? 1 : 0);

		vel_vec.Normalize();
		vel_vec *= speed;
		rigid.velocity = vel_vec;
	}

	void OnCollisionEnter(Collision other) {
		if (other.collider.tag == "LevelTerrain") {
			inAir = false;
		}
	}
}
