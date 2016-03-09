using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

	private int  _score;
    private GameManager.TeamType _team;
    private SpriteRenderer render;
    public int player_id;
    public Sprite noteam, redteam, blueteam;
	public bool visible;
    public bool death;
    public bool change;

    public Vector3 StartPosition { get; set; }


    public int Score {
        get { return _score; }
        set { _score = value; }
    }
    public GameManager.TeamType Team {
        get { return _team; }
        set { _team = value; }
    }

    void Start() {
        death = false;
        render = this.GetComponent<SpriteRenderer>();
        change = true;
		visible = true;
    }

    void Update() {
        setColor();
    }

    

    void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Boundary") {
			if (OddBall.Instance.BelongTo == this) {
				OddBall.Instance.Initial();

			}
			visible = false;
			death = true;
			Invoke("respawn", GameManager.Instance.respawn_time);
		}
		if (coll.gameObject.tag == "CameraBoundary")
			visible = false;
        if (coll.gameObject.tag == "OddBall") {
            OddBall.Instance.OnHitPlayer(this);
			Camera.main.GetComponent<CameraFollow>().onHitOddBall(this);
        }
        if (coll.gameObject.tag == "Bullet") {
            Bullet hit_bullet = coll.gameObject.GetComponent<Bullet>();
            if (hit_bullet.source_player_id == player_id ||
                    (GameManager.Instance.Mode != GameManager.gameType.FFA && hit_bullet.bullet_team == Team)) {
                return;
            }

            if (OddBall.Instance.BelongTo == this) {
                OddBall.Instance.Initial();
            }
            this.GetComponent<Rigidbody2D>().AddForce(coll.gameObject.GetComponent<Bullet>().movement_vector * 10f, ForceMode2D.Impulse);
        }
    }

    public void output() {
        Debug.Log("Team:" + Team + "Score" + Score + "id" + player_id);
    }

    public void swapTeam() {
        int team_a_players = 0;
        int team_b_players = 0;

        if (Team == GameManager.TeamType.A) {
            Team = GameManager.TeamType.B;
            this.gameObject.layer = LayerMask.NameToLayer("TeamBPlayer");
        } else if (Team == GameManager.TeamType.B) {
            Team = GameManager.TeamType.A;
            this.gameObject.layer = LayerMask.NameToLayer("TeamAPlayer");
        }

        if (GameManager.Instance.returnToFFA()) {
            return;
        } else if (GameManager.Instance.Mode == GameManager.gameType.FFA) {
            GameManager.Instance.changeToOvT(this);
            return;
        }
        
        foreach (PlayerManager pm in GameManager.Instance.players) {
            if (pm.Team == GameManager.TeamType.A) {
                ++team_a_players;
            } else if (pm.Team == GameManager.TeamType.B) {
                ++team_b_players;
            }
        }

        if (team_a_players == team_b_players) {
            GameManager.Instance.Mode = GameManager.gameType.TvT;
        } else {
            GameManager.Instance.Mode = GameManager.gameType.OvT;
        }
        //Invoke("resetChange", 1.5f);
    }

    public void respawn() {
        this.transform.position = StartPosition;
        death = false;
		visible = true;
    }

    public void setColor() {
        if (GameManager.Instance.Mode == GameManager.gameType.FFA)
            render.sprite = noteam;
        else if (Team == GameManager.TeamType.A) {
            render.sprite = redteam;
        }
        else {
            render.sprite = blueteam;
        }
    }

    //void resetChange() {
    //    change = true;
    //}
}
