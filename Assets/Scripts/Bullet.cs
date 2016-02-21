using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Vector2 movement_vector;
    public float bullet_speed;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = movement_vector * bullet_speed;
	}
}
