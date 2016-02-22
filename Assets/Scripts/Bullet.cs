using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float bullet_speed;
    public Vector2 movement_vector;
    public GameManager.TeamType bullet_team;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        this.GetComponent<SpriteRenderer>().color = TeamColors.TEAM_COLOR_MAP[bullet_team];
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = movement_vector * bullet_speed;
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Bullet" &&
                coll.gameObject.GetComponent<Bullet>().bullet_team == bullet_team) {
            return;
        }
        if (coll.gameObject.tag == "Player" &&
                coll.gameObject.GetComponent<PlayerManager>().Team == bullet_team) {
            return;
        }
        Destroy(this.gameObject);
    }
}
