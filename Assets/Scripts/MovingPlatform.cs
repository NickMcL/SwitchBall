using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    Vector2 startPos;
    Rigidbody2D rigid;
    Vector2 change, direction;
    float u = 0f;
    float offset = 0f;

    public bool horizontal = true;
    public bool reverseDirection = false;
    Vector2 forwardDirection;
    public float speed = 1.0f;
    public float maxOffset = 2.0f;

    // Use this for initialization
    void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
        startPos = rigid.position;

        if (horizontal)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            forwardDirection = Vector2.right;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            forwardDirection = Vector2.up;
        }

        if (reverseDirection)
        {
            forwardDirection = -forwardDirection;
        }

        direction = forwardDirection;
        change = direction * speed / 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        offset = (rigid.position - startPos).magnitude;

        if (offset >= maxOffset)
        {
            Vector3 currentDirection = rigid.velocity.normalized;
            Vector3 directionToStart = (startPos - rigid.position).normalized;
            // change direction
            if (Vector3.Dot(currentDirection,directionToStart) < 0)
            {
                change = -change;
            }
        }
        
        u = offset / maxOffset;

        if (u <= 0.5f) // keep constant speed near the center of the path
        {
            u = 0.5f;
        }

        // slow down near the edges
        rigid.velocity = change * (1.25f - u);
    }

    public Vector2 getCurrentVelocity() {
        return rigid.velocity;
    }
}