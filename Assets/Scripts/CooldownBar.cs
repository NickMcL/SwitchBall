using UnityEngine;
using System.Collections;

public class CooldownBar : MonoBehaviour {

    public Vector2 start_position;
    public float max_y;
    public Color bar_color;

    Vector2 start_scale = new Vector2(1f, 0f);

	// Use this for initialization
	void Start () {
        this.transform.localPosition = start_position;
        this.transform.localScale = start_scale;
        this.GetComponent<SpriteRenderer>().color = bar_color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setProgress(float progress_percent) {
        this.transform.localPosition = new Vector2(start_position.x,
            start_position.y + ((max_y * progress_percent) / 2f));
        this.transform.localScale = new Vector2(1f, max_y * progress_percent);
    }
}
