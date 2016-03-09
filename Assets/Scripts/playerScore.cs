using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerScore : MonoBehaviour {
	public static int maxscore = 0;
	public int playerid;
	[SerializeField]
	GameObject player;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		player = GameManager.Instance.playeringame [playerid];
		int score = player.GetComponent<PlayerManager> ().Score;
		this.GetComponent<Text> ().text =score.ToString();
		if (score > maxscore)
			maxscore = score;
		if (score == maxscore && score > 80) {
			StartCoroutine (blink ());
		} else
			StopCoroutine (blink ());
	


	}

	IEnumerator blink(){
		
		while(true){
			float alpha = Mathf.Abs (Mathf.Sin (Time.realtimeSinceStartup*10));
			Vector4 color = Vector4.one;
			color.w = alpha;
			this.transform.parent.gameObject.GetComponentInChildren<Image> ().color = color;
			yield return null;
			}
	}
}
