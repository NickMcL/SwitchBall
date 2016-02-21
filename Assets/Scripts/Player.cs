using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    const KeyCode MOVE_LEFT_KEY = KeyCode.A;
    const KeyCode MOVE_DOWN_KEY = KeyCode.S;
    const KeyCode MOVE_RIGHT_KEY = KeyCode.D;
    const KeyCode JUMP_KEY = KeyCode.Space;

	public Rigidbody2D			rigid;
	public bool					inAir;
	public float				speed = 4.0f;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		inAir = false;
	}
	
	void Update () {
		updateMovement();
        updateJump();
	}

	void updateMovement() {
		Vector3 vel_vec = Vector3.zero;
		bool w = false;
		bool a = Input.GetKey(MOVE_LEFT_KEY);
		bool s = Input.GetKey(MOVE_DOWN_KEY);
		bool d = Input.GetKey(MOVE_RIGHT_KEY);

		vel_vec.x = a ? -1 : (d ? 1 : 0);
		vel_vec.y = s ? -1 : (w ? 1 : 0);

		vel_vec.Normalize();
		vel_vec *= speed;
		rigid.velocity = vel_vec;
	}

    void updateJump() {
		if  ((Input.GetKeyDown(JUMP_KEY)) && (!inAir)) {
			transform.Translate(Vector3.up * 60 * Time.deltaTime, Space.World);
			inAir = true;
		} 
    }

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag == "LevelTerrain") {
			inAir = false;
		}
	}
}
