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
	public int player = Controls.player1;
	public bool useController;
	const KeyCode kMicrosoftAButton = KeyCode.Joystick1Button0;
	public bool has_triggered = false;
	public bool right_trigger_down = false;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		inAir = false;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			useController = true;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			useController = false;
		}
		updateMovement();
        updateJump();
	}

	void updateMovement() {
		Vector3 vel_vec = Vector3.zero;
		if (useController) {
			vel_vec.x = speed * Input.GetAxis (Controls.axes_codes [player, Controls.axis_left_joy_hor]);
		} 
		else {
			bool w = false;
			bool a = Input.GetKey (MOVE_LEFT_KEY);
			bool s = Input.GetKey (MOVE_DOWN_KEY);
			bool d = Input.GetKey (MOVE_RIGHT_KEY);

			vel_vec.x = a ? -1 : (d ? 1 : 0);
			vel_vec.y = s ? -1 : (w ? 1 : 0);

			vel_vec.Normalize ();
			vel_vec *= speed;
		}
		rigid.velocity = vel_vec;
	}

    void updateJump() {
		if (Input.GetAxis (Controls.axes_codes [player, Controls.axis_right_trigger]) > 0.0f) {
			right_trigger_down = true;
		}
		if (useController) {
			if (!has_triggered && right_trigger_down && (!inAir)) {
				has_triggered = true;
				transform.Translate (new Vector3 (0, 1));
				inAir = true;
				print ("jump!");
			} else if (has_triggered && right_trigger_down && (!inAir)) {
				transform.Translate (new Vector3 (0, 1));
				inAir = true;
				print ("jump!");
			}
		}
		else {
			if (Input.GetKeyDown (JUMP_KEY) && (!inAir)) {
				transform.Translate (new Vector3 (0, 1));
				inAir = true;
				print ("jump!");
			}
		}
    }

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag == "LevelTerrain") {
			inAir = false;
			right_trigger_down = false;
		}
	}
}
