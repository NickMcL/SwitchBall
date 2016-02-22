using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowTheWinner : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		this.GetComponent<Text>().text="player  "+(PlayerPrefs.GetInt("winner")+1)+"  wins";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
