using UnityEngine;
using System.Collections;

public class FireSwap : MonoBehaviour {
    const KeyCode FIRE_LEFT_KEY = KeyCode.LeftArrow | KeyCode.LeftShift;
    const KeyCode FIRE_DOWN_KEY = KeyCode.DownArrow | KeyCode.LeftShift;
    const KeyCode FIRE_RIGHT_KEY = KeyCode.RightArrow | KeyCode.LeftShift;
    const KeyCode FIRE_UP_KEY = KeyCode.UpArrow | KeyCode.LeftShift;

    public float fire_bullet_delay = 0.3f;
    float stop_bullet_fire_time;

    Object bullet_prefab;
    Vector2 fire_bullet_vector;
    Coroutine fire_bullets;

    // Use this for initialization
    void Start () {
        fire_bullets = null;
        bullet_prefab = Resources.Load("Swap");
        stop_bullet_fire_time = -fire_bullet_delay;
	}

    // Update is called once per frame
    void Update() {
        updateFireDirection();
    }

    void updateFireDirection() {
        fire_bullet_vector = Vector2.zero;
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
        
        if (fire_bullet_vector == Vector2.zero && fire_bullets != null) {
            StopCoroutine(fire_bullets);
            fire_bullets = null;
            stop_bullet_fire_time = Time.time;
        } else if (fire_bullet_vector != Vector2.zero && fire_bullets == null &&
                (Time.time - stop_bullet_fire_time) >= fire_bullet_delay) {
            fire_bullets = StartCoroutine(fireBullets());
        }
    }

    IEnumerator fireBullets() {
        while (true) {
            GameObject new_bullet = Instantiate(bullet_prefab) as GameObject;
            new_bullet.GetComponent<Bullet>().source_player_id = this.GetComponent<PlayerManager>().player_id;
            new_bullet.GetComponent<Bullet>().movement_vector = fire_bullet_vector;
            new_bullet.transform.position = this.transform.position;
            yield return new WaitForSeconds(fire_bullet_delay);
        }
    }
}
