using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {


	public static GameManager Instance;
	//references for initializing the game
	public GameObject player;
	public gameType startType;
	public List<Vector3> startPosition;

	//for test
	public GameObject swap;

	//container for players
	private gameType _mode;
	private List<TeamType> teams;
	public List<GameObject> playergo;
	private List<PlayerManager> players;

	//Which team holds the ball

	// Use this for initialization

	public gameType Mode{
		get{return _mode;}
		set{ _mode = value;}
	}

	//teamtypes
	public enum TeamType {A,B,C,D,NONE}
	public enum gameType {FFA,TvT,OvT}

	void Awake(){
		Instance = this;
		players =new List<PlayerManager>();
		teams = new List<TeamType> ();
		Mode = startType;
	}
	void Start () {
		InitiateTeams ();
		InitiatePlayers (startType);
		InvokeRepeating ("UpdateScore", 1f, 1f);

		//test
		swap.GetComponent<swapAttack>().FromPlayer=players[0];
	
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetKeyDown (KeyCode.Return)) {
			foreach (PlayerManager pm in players) {
				pm.output ();
			}
		}
	}


	//Initializing the teamtypes
	void InitiateTeams(){
		teams.Add (TeamType.A);
		teams.Add (TeamType.B);
		teams.Add (TeamType.C);
		teams.Add (TeamType.D);
		teams.Add (TeamType.NONE);
	}
	//Initializing the players, random or 1v1v1v1
	void InitiatePlayers(gameType gmtype){
		if (gmtype == gameType.FFA) {
			for (int i = 0; i < 4; i++) {
				GameObject go = Instantiate (playergo[i]);
				go.transform.position = startPosition[i];
				PlayerManager team = go.GetComponent<PlayerManager> ();
				team.Team = teams [i];
				team.StartPosition = startPosition [i];
                team.player_id = i;
				//Debug.Log (team.Team);
				players.Add (team);
			}
		} else if (gmtype == gameType.TvT) {
			int teamA = 0;
			int teamB = 0;
			for (int i = 0; i < 4; i++) {
				GameObject go = Instantiate (playergo[i]);
				go.transform.position = startPosition[i];
				PlayerManager team = go.GetComponent<PlayerManager> ();
				team.StartPosition = startPosition [i];
				if (teamA == 2) {
					team.Team = TeamType.B;
					teamB++;
				} else if (teamB == 2) {
					team.Team = TeamType.A;
					teamA++;
				} else {
					int teamX = Mathf.RoundToInt (Random.Range (0f, 1f));
				
					if (teamX == 0) {
						team.Team = TeamType.A;
						teamA++;
					} else {
						team.Team = TeamType.B;
						teamB++;
					}
				}
				players.Add (team);
			}
		} else if (gmtype == gameType.OvT) {
			int teamA = 0;
			int teamB = 0;
			for (int i = 0; i < 4; i++) {
				GameObject go = Instantiate (playergo[i]);
				go.transform.position =startPosition[i];
				PlayerManager team = go.GetComponent<PlayerManager> ();
				team.StartPosition = startPosition [i];
				if (teamA == 1) {
					team.Team = TeamType.B;
					teamB++;
				} else if (teamB ==3)
					team.Team = TeamType.A;
				else {
					int teamX = Mathf.RoundToInt (Random.Range (0f, 1f));
					if (teamX == 0) {
						team.Team = TeamType.A;
						teamA++;
					} else {
						team.Team = TeamType.B;
						teamB++;
					}
				}

				players.Add (team);
			}

		}
	}

	//Update the score
	void UpdateScore(){
		foreach (PlayerManager pm in players) {
			if (OddBall.Instance.BelongTo == null)
				return;
            if (pm == OddBall.Instance.BelongTo)
                pm.Score += 2;
            else if (pm.Team == OddBall.Instance.BelongTo.Team)
                pm.Score += 1;
			
		}
	}

	public void changeToOvT(PlayerManager input){
		foreach (PlayerManager pm in players) {
			if (pm == input) {
				pm.Team = GameManager.TeamType.A;
			} else
				pm.Team = GameManager.TeamType.B;
		}
		Mode = GameManager.gameType.OvT;
	}

	public void changeToFFA(){
		for (int i = 0; i < 4; i++) {
			
			PlayerManager team = players[i].GetComponent<PlayerManager> ();
			team.Team = teams [i];

		}
		Mode = GameManager.gameType.FFA;

	}

	public bool returnToFFA(){
		for (int i = 1; i < 4; i++) {
			if (players [i].GetComponent<PlayerManager> ().Team != players [0].GetComponent<PlayerManager> ().Team)
				return false;
			else
				continue;
		}
		changeToFFA ();
		return true;
	}

}
