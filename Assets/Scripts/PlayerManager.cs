using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private int _score;
	private   GameManager.TeamType _team;


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


}
