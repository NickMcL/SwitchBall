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
    public float respawn_time;
    public int winning_score;
    public int score_per_tick = 2;
	AudioSource sound;

    //for test
    public GameObject swap;

    //container for players
    private gameType _mode;
    private List<TeamType> teams;
    public List<GameObject> playergo;
    public List<PlayerManager> players;
	[SerializeField]
	public List<GameObject> playeringame;
    //Which team holds the ball

    // Use this for initialization

    public gameType Mode {
        get { return _mode; }
        set { _mode = value; }
    }

    //teamtypes
    public enum TeamType { A, B, C, D, NONE }
    public enum gameType { FFA, TvT, OvT }

    void Awake() {
        Instance = this;
        players = new List<PlayerManager>();
        teams = new List<TeamType>();
        Mode = startType;
        string OperatingSystem = SystemInfo.operatingSystem;
        if (OperatingSystem.StartsWith("Windows")) {
            Controls.SetMicrosoftMappings();
        }
        Debug.Log(SystemInfo.operatingSystem);
    }

    void Start() {
        InitiateTeams();
        InitiatePlayers(startType);
        InvokeRepeating("UpdateScore", 1f, 1f);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            foreach (PlayerManager pm in players) {
                pm.output();
            }
        }
    }


    //Initializing the teamtypes
    void InitiateTeams() {
        teams.Add(TeamType.A);
        teams.Add(TeamType.B);
        teams.Add(TeamType.C);
        teams.Add(TeamType.D);
        teams.Add(TeamType.NONE);
    }

    //Initializing the players, random or 1v1v1v1
    void InitiatePlayers(gameType gmtype) {
        if (gmtype == gameType.FFA) {
            for (int i = 0; i < playergo.Capacity; i++) {
                GameObject go = Instantiate(playergo[i]);
                go.transform.position = startPosition[i];
                PlayerManager team = go.GetComponent<PlayerManager>();
                team.Team = teams[i];
                team.StartPosition = startPosition[i];
                team.player_id = i;
                //Debug.Log (team.Team);
                players.Add(team);
				playeringame.Add (go);
            }
        }
        else if (gmtype == gameType.TvT) {
            int teamA = 0;
            int teamB = 0;
            for (int i = 0; i < playergo.Capacity; i++) {
                GameObject go = Instantiate(playergo[i]);
                go.transform.position = startPosition[i];
                PlayerManager team = go.GetComponent<PlayerManager>();
                team.StartPosition = startPosition[i];
                team.player_id = i;
                if (teamA == 2) {
                    team.Team = TeamType.B;
                    teamB++;
                }
                else if (teamB == 2) {
                    team.Team = TeamType.A;
                    teamA++;
                }
                else {
                    int teamX = Mathf.RoundToInt(Random.Range(0f, 1f));

                    if (teamX == 0) {
                        team.Team = TeamType.A;
                        teamA++;
                    }
                    else {
                        team.Team = TeamType.B;
                        teamB++;
                    }
                }
                players.Add(team);
				playeringame.Add (go);
            }
        }
        else if (gmtype == gameType.OvT) {
            int teamA = 0;
            int teamB = 0;
            for (int i = 0; i < playergo.Capacity; i++) {
                GameObject go = Instantiate(playergo[i]);
                go.transform.position = startPosition[i];
                PlayerManager team = go.GetComponent<PlayerManager>();
                team.StartPosition = startPosition[i];
                team.player_id = i;
                if (teamA == 1) {
                    team.Team = TeamType.B;
                    teamB++;
                }
                else if (teamB == 3)
                    team.Team = TeamType.A;
                else {
                    int teamX = Mathf.RoundToInt(Random.Range(0f, 1f));
                    if (teamX == 0) {
                        team.Team = TeamType.A;
                        teamA++;
                    }
                    else {
                        team.Team = TeamType.B;
                        teamB++;
                    }
                }

                players.Add(team);
				playeringame.Add (go);
            }

        }
    }

    //Update the score
    void UpdateScore() {
        if (OddBall.Instance.BelongTo == null) {
            return;
        }

        foreach (PlayerManager pm in players) {
			if (pm == OddBall.Instance.BelongTo) {
				pm.Score += score_per_tick;
				pm.currentStreak += score_per_tick;
				Announcer.
			} else {
				pm.currentStreak = 0;
			}
            if (pm.Score >= winning_score) {
                pm.Score = winning_score;
                winTheGame(pm);
            }
        }
    }

    public void changeToOvT(PlayerManager input) {
        foreach (PlayerManager pm in players) {
            if (pm == input) {
                pm.Team = GameManager.TeamType.A;
                pm.gameObject.layer = LayerMask.NameToLayer("TeamAPlayer");
            }
            else {
                pm.Team = GameManager.TeamType.B;
                pm.gameObject.layer = LayerMask.NameToLayer("TeamBPlayer");
            }
        }
        Mode = GameManager.gameType.OvT;
    }

    public void changeToFFA() {
        for (int i = 0; i < playergo.Capacity; i++) {
            PlayerManager player_manager = players[i].GetComponent<PlayerManager>();
            player_manager.Team = teams[i];
            player_manager.gameObject.layer = LayerMask.NameToLayer("Player");
        }
        Mode = GameManager.gameType.FFA;
    }

    public bool returnToFFA() {
        for (int i = 1; i < playergo.Capacity; i++) {
            if (players[i].GetComponent<PlayerManager>().Team != players[0].GetComponent<PlayerManager>().Team) {
                return false;
            }
        }
        changeToFFA();
        return true;
    }

    public void winTheGame(PlayerManager pm) {
        PlayerPrefs.SetInt("winner", pm.player_id);
        PlayerPrefs.SetInt("p1score", players[0].Score);
        PlayerPrefs.SetInt("p2score", players[1].Score);
        PlayerPrefs.SetInt("p3score", players[2].Score);
        PlayerPrefs.SetInt("p4score", players[3].Score);
        SceneManager.LoadScene("_Scene_End");
    }

    public int getTeammateTotal(PlayerManager player) {
        int teammate_total = -1;
        foreach (PlayerManager pm in players) {
            if (pm.Team == player.Team) {
                ++teammate_total;
            }
        }
        return teammate_total;
    }
}
