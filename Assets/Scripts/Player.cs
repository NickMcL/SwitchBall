using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Player : MonoBehaviour {
    const KeyCode MOVE_LEFT_KEY = KeyCode.A;
    const KeyCode MOVE_DOWN_KEY = KeyCode.S;
    const KeyCode MOVE_RIGHT_KEY = KeyCode.D;
    const KeyCode JUMP_KEY = KeyCode.Space;
    const KeyCode kMicrosoftAButton = KeyCode.Joystick1Button0;

    public Rigidbody2D rigid;
    public bool inAir;
    public float move_accel = 4.0f;
    public float max_velocity = 7.0f;
    public float jump_scale_factor = 3.0f;

    public int player;
    public bool useController;
    public bool has_triggered = false;
    public bool right_trigger_down = false;
    public bool jump_reset;

    public float jump_accel;

    GamePadState pad_state;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        inAir = false;
        jump_accel = rigid.gravityScale * jump_scale_factor;
        jump_reset = false;
        useController = true;

        jump_accel = 33f;
        move_accel = 100f;
    }

    void Update() {
        pad_state = GamePad.GetState((PlayerIndex) player);
        if (this.GetComponent<PlayerManager>().death == true)
            return;
        if (Input.GetKeyDown(KeyCode.Q)) {
            useController = true;
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            useController = false;
        }
        updateMovement();
        updateJump();
    }

    void updateMovement() {
        float x_direction = 0f;
        if (useController) {
            x_direction = pad_state.ThumbSticks.Left.X;
            if (Mathf.Abs(x_direction) < 0.5f) {
                x_direction = 0.0f;
            }
        }
        else {
            bool a = Input.GetKey(MOVE_LEFT_KEY);
            bool d = Input.GetKey(MOVE_RIGHT_KEY);
            x_direction = a ? -1 : (d ? 1 : 0);
        }

        if (rigid.velocity.magnitude < max_velocity || rigid.velocity.x * x_direction <= 0.0f) {
            rigid.AddForce(new Vector2(x_direction, 0f) * move_accel);
        }
        if (Mathf.Abs(rigid.velocity.x) < 2.0f) {
            rigid.velocity = new Vector2(0f, rigid.velocity.y);
        }
    }

    void updateJump() {
        if (pad_state.Triggers.Right < 0.1f) {
            jump_reset = true;
        }
		if (pad_state.Triggers.Right > 0.1f) {
			right_trigger_down = true;
		}

		if ((useController && jump_reset && right_trigger_down) && (!inAir)) {
            jump();
            has_triggered = true;
            jump_reset = false;
        }
        else if (Input.GetKeyDown(JUMP_KEY) && (!inAir)) {
            jump();
        }
        right_trigger_down = false;
    }

    void jump() {
        //rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y + jump_speed);
        rigid.AddForce(new Vector2(0f, 1f) * jump_accel, ForceMode2D.Impulse);
        inAir = true;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "LevelTerrain" || other.collider.tag == "Player") {
            inAir = false;
        }
    }

    public void knockback(Vector2 direction) {

    }
}
