using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {
    const KeyCode FIRE_LEFT_KEY = KeyCode.LeftArrow;
    const KeyCode FIRE_DOWN_KEY = KeyCode.DownArrow;
    const KeyCode FIRE_RIGHT_KEY = KeyCode.RightArrow;
    const KeyCode FIRE_UP_KEY = KeyCode.UpArrow;
    const KeyCode SWAP_ATTACK_KEY = KeyCode.W;

    public float fire_bullet_delay = 0.3f;
    float stop_bullet_fire_time;
    bool fired_swap;
	int player;

    Object bullet_prefab;
    Object swap_attack_prefab;
    Vector2 fire_bullet_vector;
    Coroutine fire_bullets;

    // Use this for initialization
    void Start () {
        fire_bullets = null;
        bullet_prefab = Resources.Load("Bullet");
        swap_attack_prefab = Resources.Load("Swap");
        stop_bullet_fire_time = -fire_bullet_delay;
        fired_swap = false;
        player = this.GetComponent<Player>().player;
	}

    // Update is called once per frame
    void Update() {
        updateFireDirection();
        updateSwapAttack();
    }

	void updateFireDirection() {
		fire_bullet_vector = Vector2.zero;
		//controller bullet fire
		float x_look_val;
		float y_look_val;

		x_look_val = Input.GetAxis (Controls.axes_codes[player, Controls.axis_right_joy_hor]);
		y_look_val = Input.GetAxis (Controls.axes_codes[player, Controls.axis_right_joy_vert]);

		if (this.GetComponent<Player>().useController) {
			fire_bullet_vector.x += x_look_val;
			fire_bullet_vector.y += y_look_val;

		}  else {
			if (Input.GetKey(FIRE_LEFT_KEY)) {
				fire_bullet_vector.x -= 1;
			}
			if (Input.GetKey(FIRE_DOWN_KEY)) {
				fire_bullet_vector.y -= 1;
			}
			if (Input.GetKey(FIRE_RIGHT_KEY)) {
				fire_bullet_vector.x += 1;
			}
			if (Input.GetKey(FIRE_UP_KEY)) {
				fire_bullet_vector.y += 1;
			}
		}
		if (.5 <= Mathf.Abs(x_look_val) || (.5 <= Mathf.Abs(y_look_val))) {
			if (fire_bullet_vector != Vector2.zero && fire_bullets == null &&
				(Time.time - stop_bullet_fire_time) >= fire_bullet_delay) {
				print (x_look_val);
				print (y_look_val);

				fire_bullets = StartCoroutine(fireBullets ());
			}
		}
		else if (fire_bullets != null) {
			StopCoroutine(fire_bullets);
			fire_bullets = null;
			stop_bullet_fire_time = Time.time;
		}

	}


    IEnumerator fireBullets() {
        while (true) {
            GameObject new_bullet = Instantiate(bullet_prefab) as GameObject;
            new_bullet.GetComponent<Bullet>().source_player_id = this.GetComponent<PlayerManager>().player_id;
            new_bullet.GetComponent<Bullet>().movement_vector = fire_bullet_vector;
            new_bullet.transform.position = this.transform.position;
            new_bullet.GetComponent<Bullet>().bullet_team = this.GetComponent<PlayerManager>().Team;
            yield return new WaitForSeconds(fire_bullet_delay);
        }
    }

    void updateSwapAttack() {
        if ((!Input.GetKey(SWAP_ATTACK_KEY) &&
                true) || //!(Input.GetAxis(Controls.axes_codes[player, Controls.axis_left_trigger]) > 0.0f)) ||
                fired_swap) {
            return;
        }

        GameObject new_swap_attack = Instantiate(swap_attack_prefab) as GameObject;
        new_swap_attack.GetComponent<swapAttack>().source_player_id = this.GetComponent<PlayerManager>().player_id;
        new_swap_attack.GetComponent<swapAttack>().movement_vector = fire_bullet_vector;
        new_swap_attack.transform.position = this.transform.position;
        fired_swap = true;
    }
}
