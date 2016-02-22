using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private int _score;
	private GameManager.TeamType _team;
	private SpriteRenderer render;
    public int player_id;


	public Vector3 StartPosition{ get; set;}

    
	public int Score{
		get{ return _score;}
		set{ _score = value;}
	}
	public GameManager.TeamType Team{
		get{ return _team;}
		set{ _team = value;}
	}

	void Start(){
		render = this.GetComponent<SpriteRenderer> ();
	}


	void Update(){
		setColor ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "OddBall") {
			OddBall.Instance.OnHitPlayer (this);
		}
		if (coll.gameObject.tag == "Boundary") {
			if (OddBall.Instance.BelongTo == this) {
				OddBall.Instance.Initial ();
			}
			Invoke ("respawn", 3f);
		}
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            if (coll.gameObject.GetComponent<Bullet>().bullet_team == Team)
            {
                return;
            }
            if (OddBall.Instance.BelongTo == this)
            {
                OddBall.Instance.Initial();
            }
            respawn();
        }
    }

	public void output(){
		Debug.Log ("Team:" + Team + "Score" + Score);
	}

	public void ChangeTeam(GameManager.TeamType teamtype){
		Team = teamtype;
	}
	public void respawn(){
		this.transform.position = StartPosition;

	}
    public void setColor()
    {   if (GameManager.Instance.Mode == GameManager.gameType.FFA)
            render.color = TeamColors.NO_TEAM;
        else  render.color = TeamColors.TEAM_COLOR_MAP[Team];
    }
	


}
