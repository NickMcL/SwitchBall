using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private int _score;
	private   GameManager.TeamType _team;
	private SpriteRenderer render;


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

    void Update()
    {

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
		if (coll.gameObject.tag == "Bullet") {
			if (OddBall.Instance.BelongTo == this) {
				OddBall.Instance.Initial ();
			}
			respawn ();
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
	public void setColor(){
		if (Team == GameManager.TeamType.A)
			render.color = Color.blue;
		if (Team == GameManager.TeamType.B)
			render.color = Color.red;
		if (Team == GameManager.TeamType.C)
			render.color = Color.yellow;
		if (Team == GameManager.TeamType.D)
			render.color = Color.green;
	}
	


}
