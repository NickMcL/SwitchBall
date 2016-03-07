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
    public float jump_accel;
    Vector2 platform_below_velocity;

    public int player;
    public bool useController;
    public bool has_triggered = false;
    public bool right_trigger_down = false;
    public bool jump_reset;

    BoxCollider2D player_collider;
    GamePadState pad_state;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        player_collider = GetComponent<BoxCollider2D>();
        inAir = false;
        jump_accel = rigid.gravityScale * jump_scale_factor;
        jump_reset = false;
        useController = true;

        jump_accel = 33f;
        move_accel = 100f;
        platform_below_velocity = Vector2.zero;
    }

    void Update() {
		if (SystemInfo.operatingSystem.StartsWith("Windows")) {
	        pad_state = GamePad.GetState((PlayerIndex) player);
		}

        if (this.GetComponent<PlayerManager>().death || CameraFollow.Instance.zoom) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            useController = true;
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            useController = false;
        }
        updateMovement();
        updateJump();
        moveWithPlatform();
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

        if ((rigid.velocity.magnitude - platform_below_velocity.magnitude) < max_velocity ||
                rigid.velocity.x * x_direction <= 0.0f) {
            rigid.AddForce(new Vector2(x_direction, 0f) * move_accel);
        }
        if (Mathf.Abs(rigid.velocity.x) < 1.0f) {
            rigid.velocity = new Vector2(0f, rigid.velocity.y);
        }
    }

    void updateJump() {
        if (getTerrainBelow() != null && rigid.velocity.y <= 0f) {
            inAir = false;
        }
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
        } else if (Input.GetKeyDown(JUMP_KEY) && (!inAir)) {
            jump();
        }
        right_trigger_down = false;
    }

    void jump() {
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(new Vector2(0f, 1f) * jump_accel, ForceMode2D.Impulse);
        inAir = true;
    }

    void moveWithPlatform() {
        GameObject terrainBelow = getTerrainBelow();
        if (terrainBelow != null && terrainBelow.tag == "Platform") {
            this.transform.parent = terrainBelow.transform;
        } else {
            this.transform.parent = null;
        }
    }

    GameObject getTerrainBelow() {
        RaycastHit2D right_hit, left_hit;
        Vector2 collider_right_corner = new Vector2(
            player_collider.bounds.center.x + player_collider.bounds.extents.x - 0.1f,
            player_collider.bounds.center.y - player_collider.bounds.extents.y - 0.01f);

        Vector2 collider_left_corner = new Vector2(
            player_collider.bounds.center.x - player_collider.bounds.extents.x + 0.1f,
            player_collider.bounds.center.y - player_collider.bounds.extents.y - 0.01f);

        right_hit = Physics2D.Raycast(collider_right_corner, Vector2.down, 0.1f);
        left_hit = Physics2D.Raycast(collider_left_corner, Vector2.down, 0.1f);
        Debug.DrawRay(collider_right_corner, Vector2.down * 0.1f);
        Debug.DrawRay(collider_left_corner, Vector2.down * 0.1f);
        if (right_hit.collider != null) {
            return right_hit.collider.gameObject;
        } else if (left_hit.collider != null) {
            return left_hit.collider.gameObject;
        }
        return null;
    }
}
