using UnityEngine;
using System.Collections;

public class showWinnerSprite : MonoBehaviour {
    public Sprite[] winner;
    private SpriteRenderer render;
    // Use this for initialization
    void Start() {
        render = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        render.sprite = winner[PlayerPrefs.GetInt("winner")];
    }
}
