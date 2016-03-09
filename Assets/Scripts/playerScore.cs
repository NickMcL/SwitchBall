using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerScore : MonoBehaviour {

	public int playerid;
	[SerializeField]
	GameObject player;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		player = GameManager.Instance.playeringame [playerid];
		this.GetComponent<Text> ().text = player.GetComponent<PlayerManager> ().Score.ToString();
	}
}
