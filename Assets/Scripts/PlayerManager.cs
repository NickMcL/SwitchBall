using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private int _score;
	private   GameManager.TeamType _team;


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
	public void output(){
		Debug.Log ("Team:" + Team + "Score" + Score);
	}

	public void ChangeTeam(GameManager.TeamType teamtype){
		Team = teamtype;
	}

}
