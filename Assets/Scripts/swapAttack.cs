using UnityEngine;
using System.Collections;

public class SwapAttack : MonoBehaviour {
    public float bullet_speed;
    public Vector2 movement_vector;
    public int source_player_id;
    public GameManager.TeamType bullet_team;
    public float rotations_per_minute = 20f;

    Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = movement_vector * bullet_speed;
        transform.Rotate(0, 0, 6.0f * rotations_per_minute * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Boundary") {
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Player" &&
                coll.gameObject.GetComponent<PlayerManager>().player_id != source_player_id) {
            print("Hit player " + coll.gameObject.GetComponent<PlayerManager>().player_id);
			coll.gameObject.GetComponent<PlayerManager>().swapTeam();
			AudioSource Swap = coll.GetComponent<AudioSource> ();
			Swap.Play ();
        }
    }
}
