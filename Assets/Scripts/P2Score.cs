using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P2Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = PlayerPrefs.GetInt("p2score").ToString();
    }
}
